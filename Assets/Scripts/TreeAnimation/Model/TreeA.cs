using System;
using TreeAnimation.View;

namespace TreeAnimation.Model
{
    public class TreeA
    {
        private NodeA root;
        public static event Action<IAnimationStrategy> OperationNotifier;

        public TreeA()
        {
            root = null;
        }

        public NodeA AddNode(int value)
        {
            NodeA created = null;
            if (root != null)
            {
                created = root.AddNode(value);
            }
            else
            {
                created = new NodeA(value);
                root = created;
                OperationNotifier?.Invoke(new CreateObjectAnimation(root.ID));
            }
            return created;
        }
    }
}