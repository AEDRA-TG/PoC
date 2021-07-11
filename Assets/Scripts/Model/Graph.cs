using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Graph
{
    private List<Node> nodes {get; set;}
    private Dictionary<int, List<int>> adjacentMtx {get; set;}
    private List<Coordinate> coordinates;

    [SerializeField]
    private float nodeVectorGenRange =0.5f;

    public Graph(){
        nodes = new List<Node>();
        adjacentMtx = new Dictionary<int, List<int>>();
        coordinates = new List<Coordinate>();
    }
        
    /*public Node addNode(GameObject nodePrefab){
        bool spaceFound = false;
        int posCoordinate = 0;
        Node newNode = null;
        while (!spaceFound)
        {
            if(coordinates[posCoordinate].isAvailable){
                List<int> relations = new List<int>();
                adjacentMtx.Add(nodes.Count - 1,relations);
                coordinates[posCoordinate].isAvailable = false;
                GameObject obj = Node.ShowNode(nodePrefab, coordinates[posCoordinate].coordinate, nodes.Count);
                newNode = obj.GetComponent<Node>();
                newNode.posCoordinate = posCoordinate;
                nodes.Add(newNode);
                spaceFound = true;
            }
            posCoordinate++;
        }
        return newNode;
    }*/

    // METODO PARA AGREGAR UN NODO
    public void addNode(GameObject nodePrefab){
        Node newNode = null;
        // Se calcula una posición random en el espacio
        Vector3 nodePosition = new Vector3(UnityEngine.Random.Range(0, nodeVectorGenRange), UnityEngine.Random.Range(0, nodeVectorGenRange), UnityEngine.Random.Range(0, nodeVectorGenRange));
        nodePosition = new Vector3(0,0,0);
        List<int> relations = new List<int>();
        adjacentMtx.Add(nodes.Count,relations);
        GameObject objReturn = Node.ShowNode(nodePrefab, nodePosition, nodes.Count);
        newNode = objReturn.GetComponent<Node>();
        nodes.Add(newNode);
    }
    

    /*public Edge addBidirectionalEdge(int origin, int destination, GameObject edgePrefab){
        List<int> aux = adjacentMtx[origin];
        aux.Add(destination);
        adjacentMtx[origin] = aux;
        List<int> aux2 = adjacentMtx[destination];
        aux.Add(origin);
        adjacentMtx[destination] = aux2;
        GameObject obj = Edge.drawEdge(edgePrefab, coordinates[nodes[origin].posCoordinate].coordinate, coordinates[nodes[destination].posCoordinate].coordinate, "Graph");
        Edge newEdge = obj.GetComponent<Edge>();
        return newEdge;
    }*/

    public void addBidirectionalEdge(GameObject edgePrefab, string origin, string destination){
        int originId = Int16.Parse(origin.Replace("Node_", ""));
        int destinationId = Int16.Parse(destination.Replace("Node_", ""));
        if(!edgeAlreadyExists(originId, destinationId)){
            List<int> aux = adjacentMtx[originId];
            aux.Add(destinationId);
            adjacentMtx[originId] = aux;
            List<int> aux2 = adjacentMtx[destinationId];
            aux.Add(originId);
            adjacentMtx[destinationId] = aux2;

            GameObject originNode = GameObject.Find(origin);
            GameObject destinationNode = GameObject.Find(destination);
            bool status = Edge.CreateLink(edgePrefab, originNode, destinationNode);
        }

        
    }

    private bool edgeAlreadyExists(int origin, int destination){
        int isCreated;
        List<int> aux = adjacentMtx[origin];
        isCreated = aux.IndexOf(destination);
        return (isCreated > 0)?true:false;
    }
}
