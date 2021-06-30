using UnityEngine;

public class Node : ProjectedObject
{
    public Node leftChild { get; set; }
    public Node rightChild { get; set; }
    public int value { get; set; }

    public Node(int value)
    {
        this.value = value;
        leftChild = null;
        rightChild = null;
        //TODO: create visual object from father to current node
    }
    public bool addChild(int value)
    {
        bool added = false;
        if( value < this.value )
        {
            if( leftChild != null )
            {
                added = leftChild.addChild(value);
            }
            else
            {
                leftChild = new Node(value);
                added = true;
            }

        }
        else if( value > this.value )
        {
            if( rightChild != null )
            {
                added = rightChild.addChild(value);
            }
            else
            {
                rightChild = new Node(value);
                added = true;
            }
        }
        return added;
    }
}
