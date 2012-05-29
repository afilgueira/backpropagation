using System.Collections.Generic;

namespace Backpropagation.Nodes
{
    public class PatternList
    {
        private List<Pattern> list = new List<Pattern>();
        
        public void Add(Pattern pp)
        {
            list.Add(pp);
        }

        public void Add(double[] input, double[] output)
        {
            list.Add(new Pattern(input, output));
        }

        public Pattern Get(int index)
        {
            return list[index];
        }

        public int Count()
        {
            return list.Count;
        }
    }
}
