using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    private List<Node> nodes {get; set;}
    private Dictionary<int, List<int>> adjacentMtx {get; set;}

    public Graph(){
        nodes = new List<Node>();
        adjacentMtx = new Dictionary<int, List<int>>();
    }
    public void addNode(Node newNode){
        nodes.Add(newNode);
        List<int> relations = new List<int>();
        adjacentMtx.Add(nodes.Count - 1,relations);
        newNode.ShowNode();
    }

    public void addBidirectionalEdge(int origin, int destination){
        List<int> aux = adjacentMtx[origin];
        aux.Add(destination);
        adjacentMtx[origin] = aux;
        List<int> aux2 = adjacentMtx[destination];
        aux.Add(origin);
        adjacentMtx[destination] = aux2;
    }
}
