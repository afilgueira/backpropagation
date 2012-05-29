using System.Linq;

namespace Backpropagation.Nodes
{
    public class MiddleNode : OutputNode
    {

        public MiddleNode(double learningRate, double momentum)
            : base(learningRate, momentum)
        {
        }

        private double ComputeError()
        {
            double total = OutputArcs.Sum(arc => arc.GetWeightedOutputError());
            return Value * (1.0 - Value) * total;
        }

        public void TrainNode()
        {
            Error = ComputeError();

            foreach (var arc in InputArcs)
            {
                double delta = LearningRate * Error * arc.GetInputValue();
                arc.UpdateWeight(delta);
            }
        }

        public override string ToString()
        {
            return ToString("MiddleNode:");
        }
    }
}
