using System.Runtime.CompilerServices;

namespace Backpropagation.Nodes
{
    public class SequenceGenerator
    {
        private static int id = 1;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static int GetId()
        {
            return (id++);
        }
    }
}
