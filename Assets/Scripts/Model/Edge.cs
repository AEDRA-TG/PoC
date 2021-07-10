using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    private static int edgeCount = 0;
    public static GameObject drawEdge(GameObject edgePrefab, Vector3 start, Vector3 end, string unityParent){
        float width = 0.025f;
        Vector3 offset = end - start;
        Vector3 scale = new Vector3(width, offset.magnitude / 2.0f, width);
        Vector3 position = start + (offset / 2.0f);

        GameObject cylinder = Instantiate(edgePrefab, position, Quaternion.identity);
        edgePrefab.name = "Edge_" + edgeCount;
        edgeCount++;
        cylinder.transform.parent = GameObject.Find(unityParent).transform;
        cylinder = cylinder.transform.GetChild(0).gameObject;
        cylinder.transform.up = offset;
        cylinder.transform.localScale = scale;

        return cylinder;
    }

    public static bool CreateLink(GameObject edgePrefab, GameObject originNode, GameObject destinationNode){
        GameObject linkObject = Instantiate(edgePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Link newLink = linkObject.GetComponent<Link>();
        linkObject.name = "Edge_" + 0;
        newLink.source = originNode;
        newLink.target = destinationNode;

        return true;
    }

}
