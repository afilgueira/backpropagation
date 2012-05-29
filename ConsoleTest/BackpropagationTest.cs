using System;
using Backpropagation.Nodes;

namespace ConsoleTest
{
    class BackpropagationTest
    {
        private static int inputSize = 5;
        private static int outputSize = 1;

        static void Main()
        {
            // To know how to use correctly the learning rate and momentum you can read some information about them.
            // But the best you can do is to play with them :)
            var model = new BackProp(inputSize, 10, outputSize, 0.15, 0.9);
            
            model.TrainNetwork(CreatePatternList(), -1, 10000, 0.5, true);
            
            Console.WriteLine("The result is: " + model.RunNetwork(CreateInput())[0]);
            Console.WriteLine(model.Print());
            Console.ReadKey();
        }

        // A sample input
        private static double[] CreateInput()
        {
            return new double[] { zero, one, one, zero, one };
        }


        private static double one = 0.999999999999999;
        private static double zero = 0.0000000000000001;

        // A sample pattern list
        static PatternList CreatePatternList()
        {
            var patterns = new PatternList();

            var input = new double[] { one, one, one, one, one };
            var output = new double[] { one };
            patterns.Add(input, output);

            input = new double[] { one, one, one, one, zero };
            output = new double[] { one };
            patterns.Add(input, output);

            input = new double[] { one, zero, one, one, one };
            output = new double[] { one };
            patterns.Add(input, output);

            input = new double[] { one, one, one, zero, one };
            output = new double[] { one };
            patterns.Add(input, output);

            input = new double[] { one, zero, one, one, one };
            output = new double[] { one };
            patterns.Add(input, output);

            input = new double[] { zero, one, one, one, one };
            output = new double[] { one };
            patterns.Add(input, output);

            input = new double[] { one, one, zero, one, zero };
            output = new double[] { zero };
            patterns.Add(input, output);

            input = new double[] { zero, one, zero, one, one };
            output = new double[] { zero };
            patterns.Add(input, output);

            input = new double[] { zero, one, zero, one, one };
            output = new double[] { zero };
            patterns.Add(input, output);

            input = new double[] { zero, one, zero, one, one };
            output = new double[] { zero };
            patterns.Add(input, output);

            input = new double[] { zero, one, zero, one, one };
            output = new double[] { zero };
            patterns.Add(input, output);

            input = new double[] { one, one, one, zero, zero };
            output = new double[] { zero };
            patterns.Add(input, output);

            input = new double[] { one, one, zero, one, one };
            output = new double[] { one };
            patterns.Add(input, output);

            input = new double[] { one, zero, one, zero, one };
            output = new double[] { zero };
            patterns.Add(input, output);

            input = new double[] { one, one, one, one, one };
            output = new double[] { one };
            patterns.Add(input, output);

            input = new double[] { zero, one, one, one, zero };
            output = new double[] { zero };
            patterns.Add(input, output);

            input = new double[] { zero, one, zero, one, one };
            output = new double[] { one };
            patterns.Add(input, output);

            input = new double[] { one, one, zero, one, one };
            output = new double[] { one };
            patterns.Add(input, output);

            input = new double[] { zero, one, zero, one, zero };
            output = new double[] { zero };
            patterns.Add(input, output);

            input = new double[] { zero, zero, zero, zero, zero };
            output = new double[] { zero };
            patterns.Add(input, output);

            return patterns;
        }
    }
}
