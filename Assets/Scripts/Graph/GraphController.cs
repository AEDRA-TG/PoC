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
        for(int i = 0; i < 12; i++){
            Node newNode = projectedGraph.addNode(nodePrefab);
        }
        Edge newEdge = projectedGraph.addBidirectionalEdge(0, 1, edgePrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
