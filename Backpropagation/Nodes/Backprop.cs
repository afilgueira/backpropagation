using System;
using System.Text;

namespace Backpropagation.Nodes
{
    public class BackProp
    {
        private NetWork network;

        public BackProp(int inputPopulation, int middlePopulation, int outputPopulation, double learningRate, double momentum)
        {
            network = new NetWork(inputPopulation, middlePopulation, outputPopulation, learningRate, momentum);
        }
        
        public double[] RunNetwork(double[] arg)
        {
            return network.RunNetwork(arg);
        }

        public int TrainNetwork(PatternList patterns, int maxMatch, int maxCycles, double threshold, bool verbose)
        {
            int counter = 0;
            int maxSuccess = 0;
            int limit = patterns.Count();
            int success;
            bool whileFlag;

            if (maxMatch < 0)
            {
                maxMatch = limit;
            }
            
            do
            {
                success = 0;

                for (int i = 0; i < limit; i++)
                {
                    var pattern = patterns.Get(i);

                    network.RunNetwork(pattern.Input);

                    double[] rawResults = network.TrainNetWork(pattern.Output);

                    int[] truth = MathHelper.ThresholdArray(threshold, pattern.Output);
                    int[] results = MathHelper.ThresholdArray(threshold, rawResults);

                    pattern.Trained = true;
                    
                    for (int j = 0; j < results.Length; j++)
                    {
                        if (results[j] != truth[j])
                        {
                            pattern.Trained = false;
                        }
                    }

                    if (pattern.Trained)
                    {
                        ++success;
                    }
                }

                if (maxSuccess < success)
                {
                    maxSuccess = success;
                }

                if ((++counter % 10000) == 0)
                {
                    if (verbose)
                    {
                        Console.WriteLine(counter + " success:" + success + " needed:" + patterns.Count() + " best run:" + maxSuccess);
                    }
                }

                whileFlag = success < limit;

                if ((maxCycles > -1 && counter >= maxCycles) || success >= maxMatch)
                {
                    whileFlag = false;
                }

            } while (whileFlag);

            if (verbose)
            {
                Console.WriteLine("Training was completed in " + counter + " cycles. " + maxSuccess + " patterns were learned.");
            }

            return success;
        }
        
        public string Print()
        {
            var buffer = new StringBuilder();

            buffer.Append("Input layer: \n");
            foreach (var node in network.Inputs)
            {
                buffer.Append("Node: " + node.Id + "\n");
            }

            buffer.Append("\nMiddle layer: \n");
            foreach (var node in network.Middles)
            {
                buffer.Append("\nNode: " + node.Id + "\n");

                foreach (Arc arc in node.InputArcs)
                {
                    buffer.Append("--> " + arc + "\n");
                }

                foreach (Arc arc in node.OutputArcs)
                {
                    buffer.Append("--> " + arc + "\n");
                }
            }

            buffer.Append("\nOutput layer: \n");
            foreach (var node in network.Outputs)
            {
                buffer.Append("Node: " + node.Id + "\n");
            }

            return buffer.ToString();
        }
    }
}
