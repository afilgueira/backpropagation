using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backpropagation.Nodes
{
    public class OutputNode : AbstractNode
    {
        public double LearningRate { get; private set; }
        public double Momentum { get; private set; }

        public OutputNode(double learningRate, double momentum)
        {
            LearningRate = learningRate;
            Momentum = momentum;
        }

        public void RunNode()
        {
            double total = InputArcs.Sum(arc => arc.GetWeightedInputValue());
            Value = SigmoidTransfer(total);
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

        private double SigmoidTransfer(double value)
        {
            return (1.0 / (1.0 + Math.Exp(-value)));
        }

        private double ComputeError()
        {
            return (Value * (1.0 - Value) * (Error - Value));
        }

        public override string ToString()
        {
            return ToString("OutputNode:");
        }

        public string ToString(string prefix)
        {
            return prefix + base.ToString() + " learning rate:" + LearningRate + " momentum:" + Momentum;
        }
    }
}
