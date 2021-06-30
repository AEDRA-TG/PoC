using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField]
    private BinaryNode root;
    
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
            root = new BinaryNode(value, null);
        }
    }

}
