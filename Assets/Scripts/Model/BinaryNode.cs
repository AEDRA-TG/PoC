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
        calculateCoordinates(parent);
        //TODO: get parent name
        DrawObject.draw(this, "TestTree");
        
    }
    public bool addChild(int value)
    {
        Debug.Log("XXXXXXXXXXXXXXXXXXXXXXXXX");
        bool added = false;
        // Left
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
        // Right 
        else if( value > this.value )
        {
            if( rightChild != null )
            {
                added = rightChild.addChild(value);
            }
            else
            {
                //rightChild = new BinaryNode(value, this);
                added = true;
            }
        }
        return added;
    }
    
    
    public void calculateCoordinates(BinaryNode parent){
        Vector3 pCoordinates = parent.transform.position;
        Vector3 cCoordinates; 
        if( parent.value > this.value ){
            //draw left
            cCoordinates = new Vector3 ( (float)pCoordinates.x-1.0f , pCoordinates.y , (float)pCoordinates.z-2.0f);
        }else{
            //draw right
            cCoordinates = new Vector3 ( pCoordinates.x+1.0f , pCoordinates.y , pCoordinates.z-2.0f);
        }
        this.coordinates = cCoordinates;
    }
}
