using UnityEngine;

public class Tree : MonoBehaviour
{
    public Node root { get; set; }

    public Tree()
    {
        this.root = null;
    }
    //
    public void addChild(int value)
    {
        if( root != null)
        {
            root.addChild(value);
        }
        else
        {
            root = new Node(value);
        }
    }

    public void loadTree()
    {

    }
}
