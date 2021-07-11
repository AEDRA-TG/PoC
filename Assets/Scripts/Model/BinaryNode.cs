using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using DG.Tweening;
public class BinaryNode : ProjectedObject
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private GameObject edgePrefab;
    [SerializeField]
    private int value;
    [SerializeField]
    private Color color = Color.white;
    public BinaryNode leftChild { get; set; }
    public BinaryNode rightChild { get; set; }
    public TreeEdge parentEdge { get; set; }
    public int level { get; set; }
    
    private Sequence colorSequence;

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

    public BinaryNode createNode(int value, List<BinaryNode> nodes){
        //TODO: get parent name
        Vector3 coordinates = calculateCoordinates(value);
        //--FOR PARA PINTAR EL CAMINO--
        Debug.Log("SIZE: " + nodes.Count);
        //colorSequence = DOTween.Sequence();
        updateNodesColor(nodes, this.color);
        GameObject node = DrawObject.draw(prefab, coordinates, "TestTree");
        //TODO draw edge between parent and child
        BinaryNode bNode = node.GetComponent<BinaryNode>();
        bNode.value = value;
        bNode.leftChild = null;
        bNode.rightChild = null;
        bNode.coordinates = coordinates; 
        bNode.level = this.level +1;
        bNode.parentEdge = createTreeEdge(this, bNode);
        //TODO Delete this
        DrawObject.changeColor(bNode.parentEdge, this.color, colorSequence);
        nodes.Add(bNode);
        StartCoroutine(ExampleCoroutine(nodes));
        return bNode;
    }

    public BinaryNode addChild(int value, List<BinaryNode> nodes)
    {
        nodes.Add(this);
        BinaryNode added = null;
        // Left
        if( value < this.value )
        {
            if( leftChild != null )
            {
                added = leftChild.addChild(value, nodes);
            }
            else
            {
                leftChild = createNode(value, nodes);
                added = leftChild;
            }

        }
        // Right 
        else if( value > this.value )
        {
            if( rightChild != null )
            {
                added = rightChild.addChild(value, nodes);
            }
            else
            {
                rightChild = createNode(value, nodes);
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

    public void updateNodesColor(List<BinaryNode> nodes, Color color){
        Debug.Log("Starting update");
        foreach (BinaryNode node in nodes)
        {
            Debug.Log(node.transform.parent.gameObject.name);
            if(node.parentEdge != null ){
                DrawObject.changeColor(node.parentEdge, color,colorSequence);
            }
            DrawObject.changeColor(node, color, colorSequence);            
        }
        Debug.Log("End update");
    }


    IEnumerator ExampleCoroutine(List<BinaryNode> nodes)
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
        
        updateNodesColor(nodes, Color.white);
    }
}
