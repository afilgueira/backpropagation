using System;
using System.Runtime.CompilerServices;

namespace Backpropagation.Nodes
{
    public class MathHelper
    {
        private static readonly Random random = new Random();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static double GetBoundedRandom(double lower, double upper)
        {
            double range = upper - lower;
            double result = random.NextDouble() * range + lower;

            return result;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static double GetRandomDouble()
        {
            return random.NextDouble();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static int[] ThresholdArray(double threshold, double[] candidates)
        {
            double upperThreshold = 1.0 - threshold;
            double lowerThreshold = threshold;

            int[] result = new int[candidates.Length];

            for (int i = 0; i < candidates.Length; i++)
            {
                if (candidates[i] > upperThreshold)
                {
                    result[i] = 1;
                }
                else if (candidates[i] < lowerThreshold)
                {
                    result[i] = 0;
                }
                else
                {
                    result[i] = -1;
                }
            }

            return result;
        }
    }
}
