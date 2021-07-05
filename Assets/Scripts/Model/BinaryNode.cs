using UnityEngine;

public class BinaryNode : ProjectedObject
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private GameObject edgePrefab;
    [SerializeField]
    private int value;
    public BinaryNode leftChild { get; set; }
    public BinaryNode rightChild { get; set; }
    public TreeEdge parentEdge { get; set; }
    public int level { get; set; }


    public int getValue(){ 
        return this.value;
    }
    public void setValue(int value){
        this.value = value;
    }

    public void Start()
    {
        this.coordinates = transform.position;
    }

    public BinaryNode createNode(int value){
        //TODO: get parent name
        Vector3 coordinates = calculateCoordinates(value);
        GameObject node = DrawObject.draw(prefab, coordinates, "TestTree");
        //TODO draw edge between parent and child
        BinaryNode bNode = node.GetComponent<BinaryNode>();
        bNode.value = value;
        bNode.leftChild = null;
        bNode.rightChild = null;
        bNode.coordinates = coordinates; 
        bNode.level = this.level +1;
        bNode.parentEdge = createTreeEdge(this, bNode);

        return bNode;
    }
    public BinaryNode addChild(int value)
    {
        BinaryNode added = null;
        // Left
        if( value < this.value )
        {
            if( leftChild != null )
            {
                added = leftChild.addChild(value);
            }
            else
            {
                leftChild = createNode(value);
                added = leftChild;
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
                rightChild = createNode(value);
                added = rightChild;
            }
        }
        return added;
    }
    
    
    public Vector3 calculateCoordinates(int value){
        Vector3 pCoordinates = this.transform.position;
        Vector3 cCoordinates; 
        //we are in the parent
        if( this.value > value ){
            //draw left
            cCoordinates = new Vector3 ( pCoordinates.x-0.5f , pCoordinates.y , pCoordinates.z-0.5f);
        }else{
            //draw right
            cCoordinates = new Vector3 ( pCoordinates.x+0.5f , pCoordinates.y , pCoordinates.z-0.5f);
        }
        return cCoordinates;
    }
    public TreeEdge createTreeEdge(BinaryNode from, BinaryNode to)
    {
        GameObject edge = DrawObject.drawEdge(edgePrefab, from.coordinates , to.coordinates, "TestTree");
        TreeEdge bEdge = edge.GetComponent<TreeEdge>();
        bEdge.from = from;
        bEdge.to = to;
        return bEdge;
    }
}
