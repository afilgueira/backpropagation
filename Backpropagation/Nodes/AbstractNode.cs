using System.Collections.Generic;

namespace Backpropagation.Nodes
{
    public abstract class AbstractNode : AbstractArcNode
    {
        public double Error { get; set; }
        public double Value { get; set; }

        public List<Arc> InputArcs { get; private set; }
        public List<Arc> OutputArcs { get; private set; }

        protected AbstractNode()
        {
            OutputArcs = new List<Arc>();
            InputArcs = new List<Arc>();
        }

        public void Connect(AbstractNode destination, Arc arc)
        {
            OutputArcs.Add(arc);
            destination.InputArcs.Add(arc);

            arc.In = this;
            arc.Out = destination;
        }


        public string DumpConnections()
        {

            string result = "id:" + Id;
            
            result += ":input:";
            foreach (Arc arc in InputArcs)
            {
                result += arc + ":";
            }

            result += "output:";
            foreach (Arc arc in OutputArcs)
            {
                result += arc + ":";
            }

            return result;
        }

        public override string ToString()
        {
            return Id + " error:" + Error + " value:" + Value + " input:" + InputArcs.Count + " output:" + OutputArcs.Count;
        }
    }
}
