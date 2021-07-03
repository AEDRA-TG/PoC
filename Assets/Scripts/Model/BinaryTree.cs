using UnityEngine;

public class BinaryTree : MonoBehaviour
{
    [SerializeField]
    private BinaryNode root;
    
    public BinaryTree()
    {
        //this.root = null;
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
