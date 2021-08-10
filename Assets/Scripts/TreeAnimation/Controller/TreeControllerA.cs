using System;
public class TreeControllerA{
    private TreeA tree;

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
    }
}