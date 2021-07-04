using UnityEngine;

public class BinaryNode : ProjectedObject
{
    [SerializeField]
    private int value;
    public BinaryNode leftChild { get; set; }
    public BinaryNode rightChild { get; set; }
    public TreeEdge leftEdge { get; set; }
    public TreeEdge rightEdge { get; set; }

    [SerializeField]
    private GameObject prefab;

        [SerializeField]
    private GameObject edgePrefab;

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

        if( this.value > value ){
            //draw left
            leftEdge = createTreeEdge(this.coordinates, coordinates);
        }else{
            //draw right
            rightEdge = createTreeEdge(this.coordinates, coordinates);
        }
        return bNode;
    }
    public bool addChild(int value)
    {
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
                leftChild = createNode(value);
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
                rightChild = createNode(value);
                added = true;
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
    public TreeEdge createTreeEdge(Vector3 from, Vector3 to)
    {
        GameObject edge = DrawObject.drawEdge(edgePrefab, from , to, "TestTree");
        TreeEdge bEdge = edge.GetComponent<TreeEdge>();
        bEdge.from = from;
        bEdge.to = to;
        return bEdge;
    }
}
