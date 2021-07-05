using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    private List<Node> nodes {get; set;}
    private Dictionary<int, List<int>> adjacentMtx {get; set;}
    private List<Coordinate> coordinates;

    public Graph(){
        nodes = new List<Node>();
        adjacentMtx = new Dictionary<int, List<int>>();
        coordinates = new List<Coordinate>();
        for(int k = 0; k < 2; k++){
            for(int i = 0; i < 3; i++){
                for(int j = 0; j < 2; j++){
                    float x =  i*0.6f;
                    float y = k*0.6f;
                    float z = j*0.6f;
                    Coordinate aux = new Coordinate(z, y, x);
                    coordinates.Add(aux);
                }
            }
        }
    }
        
    public Node addNode(GameObject nodePrefab){
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
    }

    

    public Edge addBidirectionalEdge(int origin, int destination, GameObject edgePrefab){
        List<int> aux = adjacentMtx[origin];
        aux.Add(destination);
        adjacentMtx[origin] = aux;
        List<int> aux2 = adjacentMtx[destination];
        aux.Add(origin);
        adjacentMtx[destination] = aux2;
        GameObject obj = Edge.drawEdge(edgePrefab, coordinates[nodes[origin].posCoordinate].coordinate, coordinates[nodes[destination].posCoordinate].coordinate, "Graph");
        Edge newEdge = obj.GetComponent<Edge>();
        return newEdge;
    }
}
