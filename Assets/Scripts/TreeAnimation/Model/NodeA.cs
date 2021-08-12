using System;

namespace TreeAnimation.Model
{
    public class NodeA
    {
        public int value { set; get; }
        private NodeA leftChild;
        private NodeA rightChild;
        public int ID { set; get; }

        //----------- Actions -----------
        public static event Action<int> OperationNotifier;

        public NodeA(int value)
        {
            this.value = value;
            this.ID = value;
            OperationNotifier?.Invoke(this.ID);
            //OperationNotifier?.Invoke(new CreateNodeAnimation(this.ID));
        }

        public NodeA AddNode(int value)
        {
            NodeA added = null;
            // Left
            if (value < this.value)
            {
                if (leftChild != null)
                {
                    added = leftChild.AddNode(value);
                }
                else
                {
                    leftChild = new NodeA(value);
                    added = leftChild;
                }

            }
            // Right 
            else if (value > this.value)
            {
                if (rightChild != null)
                {
                    added = rightChild.AddNode(value);
                }
                else
                {
                    rightChild = new NodeA(value);
                    added = rightChild;
                }
            }
            OperationNotifier?.Invoke(this.ID);
            //OperationNotifier?.Invoke(new PaintNodeAnimation(this.ID));
            return added;
        }
    }
}