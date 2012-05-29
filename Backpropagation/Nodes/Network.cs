using System.Linq;

namespace Backpropagation.Nodes
{
    public class NetWork
    {
        public Arc[] Arcs { get; private set; }
        public InputNode[] Inputs { get; private set; }
        public MiddleNode[] Middles { get; private set; }
        public OutputNode[] Outputs { get; private set; }


        public NetWork(int inputPopulation, int middlePopulation, int outputPopulation, double learningRate, double momentum)
        {
            Inputs = new InputNode[inputPopulation];
            for (int i = 0; i < Inputs.Count(); i++)
            {
                Inputs[i] = new InputNode();
            }

            Middles = new MiddleNode[middlePopulation];
            for (int j = 0; j < Middles.Count(); j++)
            {
                Middles[j] = new MiddleNode(learningRate, momentum);
            }

            Outputs = new OutputNode[outputPopulation];
            for (int h = 0; h < Outputs.Count(); h++)
            {
                Outputs[h] = new OutputNode(learningRate, momentum);
            }

            Arcs = new Arc[(inputPopulation * middlePopulation) + (middlePopulation * outputPopulation)];
            for (int k = 0; k < Arcs.Count(); k++)
            {
                Arcs[k] = new Arc();
            }

            int ii = 0;
            for (int jj = 0; jj < Inputs.Count(); jj++)
            {
                for (int kk = 0; kk < Middles.Count(); kk++)
                {
                    Inputs[jj].Connect(Middles[kk], Arcs[ii++]);
                }
            }

            for (int jj = 0; jj < Middles.Count(); jj++)
            {
                for (int kk = 0; kk < Outputs.Count(); kk++)
                {
                    Middles[jj].Connect(Outputs[kk], Arcs[ii++]);
                }
            }
        }

        public double[] RunNetwork(double[] input)
        {
            for (int ii = 0; ii < input.Count(); ii++)
            {
                Inputs[ii].Value = input[ii];
            }

            for (int ii = 0; ii < Middles.Count(); ii++)
            {
                Middles[ii].RunNode();
            }

            for (int ii = 0; ii < Outputs.Count(); ii++)
            {
                Outputs[ii].RunNode();
            }

            var result = new double[Outputs.Count()];
            for (int ii = 0; ii < Outputs.Count(); ii++)
            {
                result[ii] = Outputs[ii].Value;
            }

            return result;
        }


        public double[] TrainNetWork(double[] truth)
        {
            for (int ii = 0; ii < truth.Count(); ii++)
            {
                Outputs[ii].Error = truth[ii];
            }

            for (int ii = Outputs.Count() - 1; ii >= 0; ii--)
            {
                Outputs[ii].TrainNode();
            }

            for (int ii = Middles.Count() - 1; ii >= 0; ii--)
            {
                Middles[ii].TrainNode();
            }

            var result = new double[Outputs.Count()];
            for (int ii = 0; ii < Outputs.Count(); ii++)
            {
                result[ii] = Outputs[ii].Value;
            }

            return result;
        }
    }
}
