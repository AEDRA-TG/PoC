using System;
using TreeAnimation.View;
using TreeAnimation.Utils;
using UnityEngine;

namespace TreeAnimation.Model
{
    public class NodeA
    {
        public int value { set; get; }
        private NodeA leftChild;
        private NodeA rightChild;
        public int ID { set; get; }

        //----------- Actions -----------
        public static event Action<IAnimationStrategy> OperationNotifier;

        public NodeA(int value)
        {
            this.value = value;
            this.ID = value;
        }

        public NodeA AddNode(int value)
        {
            NodeA added = null;
            OperationNotifier?.Invoke(new PaintObjectAnimation(this.ID, ConstansA.PaintObjectColor));
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
                    OperationNotifier?.Invoke(new CreateObjectAnimation(added.ID, this.ID));
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
                    OperationNotifier?.Invoke(new CreateObjectAnimation(added.ID, this.ID));
                }
            }
            return added;
        }
    }
}