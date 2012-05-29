namespace Backpropagation.Nodes
{
    public abstract class AbstractArcNode
    {
        public int Id { get; private set; }

        internal AbstractArcNode()
        {
            Id = SequenceGenerator.GetId();
        }
    }
}
