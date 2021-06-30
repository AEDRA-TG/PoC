using UnityEngine;

public class BinaryNode : ProjectedObject
{
    [SerializeField]
    private int value;
    public BinaryNode leftChild { get; set; }
    public BinaryNode rightChild { get; set; }
    
    public int getValue(){
        return this.value;
    }
    public void setValue(int value){
        this.value = value;
    }

    public BinaryNode(int value, BinaryNode parent )
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
                leftChild = new BinaryNode(value, this);
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
                rightChild = new BinaryNode(value, this);
                added = true;
            }
        }
        return added;
    }
    /*
    public Vector3 getCoordinates(BinaryNode parent){
        Vector3 pCoordinates = parent.transform.position;
        if( parent.value > this.value ){
            //draw left

        }else{
            //draw right
        }

    }*/
}
