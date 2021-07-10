using System.Collections;
using System.Collections.Generic;
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
        for(int k = 0; k < 5; k++){
            for(int i = 0; i < 3; i++){
                for(int j = 0; j < 2; j++){
                    float x;
                    float y;
                    float z;
                    if(i%2==0){
                        z =  (j*0.6f) + (k*0.1f);
                    }
                    else{
                        if(j==0){
                            z = (-0.4f) + (k*0.1f);
                        }
                        else
                            z = (1f) + (k*0.1f);
                    }
                    y = (k*0.6f) + (k*0.2f);
                    x = i*0.6f;
                    Coordinate aux = new Coordinate(z, y, x);
                    coordinates.Add(aux);
                }
            }
        }
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

    public Node addNode(GameObject nodePrefab){
        Node newNode = null;

        Vector3 nodePosition = new Vector3(UnityEngine.Random.Range(0, nodeVectorGenRange), UnityEngine.Random.Range(0, nodeVectorGenRange), UnityEngine.Random.Range(0, nodeVectorGenRange));
        List<int> relations = new List<int>();
        adjacentMtx.Add(nodes.Count,relations);
        GameObject objReturn = Node.ShowNode(nodePrefab, nodePosition, nodes.Count);
        newNode = objReturn.GetComponent<Node>();
        nodes.Add(newNode);
        return newNode;
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

    public void addBidirectionalEdge(int origin, int destination, GameObject edgePrefab){

        if(!edgeAlreadyExists(origin, destination)){
            List<int> aux = adjacentMtx[origin];
            aux.Add(destination);
            adjacentMtx[origin] = aux;
            List<int> aux2 = adjacentMtx[destination];
            aux.Add(origin);
            adjacentMtx[destination] = aux2;

            GameObject originNode = GameObject.Find("Node_" + origin);
            GameObject destinationNode = GameObject.Find("Node_" + destination);
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
