using System;
using TreeAnimation.Model;

namespace TreeAnimation.Controller
{
    public class TreeControllerA
    {
        private TreeA tree;
        private int id;

        //----------- Actions -----------
        public static event Action OperationNotifier;

        public TreeControllerA()
        {
            tree = new TreeA();
        }

        public void AddNode(int value)
        {
            NodeA added = tree.AddNode(value);
            OperationNotifier?.Invoke();
            //OperationNotifier?.Invoke();
        }
    }
}