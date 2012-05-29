
namespace Backpropagation.Nodes
{
    public class Arc : AbstractArcNode
    {
        public AbstractNode In { get; set; }
        public AbstractNode Out { get; set; }
        private double weight = MathHelper.GetBoundedRandom(-1.0, 1.0);
        private double delta;

        public double GetInputValue()
        {
            return In.Value;
        }

        public double GetWeightedInputValue()
        {
            return In.Value * weight;
        }

        public double GetWeightedOutputError()
        {
            return Out.Error * weight;
        }

        public void UpdateWeight(double arg)
        {
            var on = (OutputNode) Out;
            weight += arg + on.Momentum * delta;
            delta = arg;
        }
        
        public override string ToString()
        {
            string result = "Arc: " + Id + " --> Links the nodes ";

            if (In == null)
            {
                result += "X";
            }
            else
            {
                result += In.Id;
            }

            result += " and ";

            if (Out == null)
            {
                result += "X";
            }
            else
            {
                result += Out.Id;
            }

            result += " --> Weight: " + weight;
            return result;
        }
    }
}
