using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController : MonoBehaviour
{
    // Start is called before the first frame update
    private Graph projectedGraph;
    [SerializeField]
    private GameObject nodePrefab;
    [SerializeField]
    private GameObject edgePrefab;

    [SerializeField]
    private bool allStatic = false;

    [SerializeField]
    private float repulseForceStrength = 0.1f;
    [SerializeField]
    private bool repulseActive = true;
    [SerializeField]
    private float globalGravityPhysX = 10f;
    [SerializeField]
    private float nodePhysXForceSphereRadius = 50F;  
    void Start()
    {
        projectedGraph = new Graph();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void onClickAddNode(int nodesCount){
        for(int i = 0; i < nodesCount; i++){
            Node newNode = projectedGraph.addNode(nodePrefab);
        }
    }

    public void onClickAddLink(int linksCount){
        for(int i = 0; i< linksCount; i++){
            projectedGraph.addBidirectionalEdge(0,1,edgePrefab);
        }
    }




    #region Getters y Setters
    public float RepulseForceStrength
    {
        get
        {
            return repulseForceStrength;
        }
        private set
        {
            repulseForceStrength = value;
        }
    }
    public bool AllStatic
    {
        get
        {
            return allStatic;
        }
        set
        {
            allStatic = value;
        }
    }

    public bool RepulseActive
    {
        get
        {
            return repulseActive;
        }
        set
        {
            repulseActive = value;
        }
    }
    public float GlobalGravityPhysX
    {
        get
        {
            return globalGravityPhysX;
        }
        set
        {
            globalGravityPhysX = value;
        }
    }
    public float NodePhysXForceSphereRadius
    {
        get
        {
            return nodePhysXForceSphereRadius;
        }
        set
        {
            nodePhysXForceSphereRadius = value;
        }
    }
    #endregion
}
