using System;
using System.Linq;

namespace Backpropagation.Nodes
{
    public class Pattern
    {
        public double[] Input { get; private set; }
        public double[] Output { get; private set; }
        public bool Trained { get; set; }

        public Pattern(double[] input, double[] output)
        {
            Input = (double[])input.Clone();
            Output = (double[])output.Clone();
            Trained = false;
        }

        public override string ToString()
        {
            string result = "trained:" + Trained;

            result += " input ";
            if (Input == null)
            {
                result += " null ";
            }
            else
            {
                for (int ii = 0; ii < Input.Count(); ii++)
                {
                    result += Input[ii] + " ";
                }
            }

            result += " output ";
            if (Output == null)
            {
                result += " null ";
            }
            else
            {
                for (int ii = 0; ii < Output.Count(); ii++)
                {
                    result += Output[ii] + " ";
                }
            }

            return result;
        }

        public void DumpPattern()
        {
            Console.WriteLine("output pattern");
            for (int ii = 0; ii < Output.Length; ii++)
            {
                Console.WriteLine(ii + " " + Output[ii]);
            }

            Console.WriteLine("input pattern");
            for (int ii = 0; ii < Input.Length; ii++)
            {
                Console.WriteLine(ii + " " + Input[ii]);
            }
        }
    }
}
