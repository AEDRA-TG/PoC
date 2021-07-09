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

    void Start()
    {
        projectedGraph = new Graph();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void onClickAddNode(){
        Node newNode = projectedGraph.addNode(nodePrefab);
    }
}
