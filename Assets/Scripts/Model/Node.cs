using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public int posCoordinate {get; set;}
    public static GameObject ShowNode(GameObject nodePrefab,Vector3 coordinate, int posNode){
        nodePrefab = Instantiate(nodePrefab, coordinate, Quaternion.identity);
        nodePrefab.transform.parent = GameObject.Find("Graph").transform;
        nodePrefab.name = "Node_" + (posNode);
        return nodePrefab.transform.GetChild(0).gameObject;
    }
}
