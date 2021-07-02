using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    private List<Node> nodes {get; set;}
    private Dictionary<int, List<int>> adjacentMtx {get; set;}

    public void addNode(Node newNode){
        nodes.Add(newNode);
        List<int> relations = new List<int>();
        adjacentMtx.Add(nodes.Count - 1,relations);
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
