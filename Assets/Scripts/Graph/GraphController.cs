using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController : MonoBehaviour
{
    // Start is called before the first frame update
    private Graph projectedGraph;

    void Start()
    {
        projectedGraph = new Graph();
        Node newNode = GetComponent<Node>();
        projectedGraph.addNode(newNode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
