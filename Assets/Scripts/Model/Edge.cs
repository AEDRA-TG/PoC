using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{

    public static GameObject drawEdge(GameObject edgePrefab, Vector3 start, Vector3 end, string unityParent){
        //Instantiate cylinder, use one of the points as the point of instantiation.
        Vector3 midPoint = (start + end)/2;
        edgePrefab = Instantiate(edgePrefab, midPoint, Quaternion.identity);
        edgePrefab.transform.parent = GameObject.Find(unityParent).transform;
        //Look at Transform.LookAt to make the cylinder face the other point.
        edgePrefab.transform.LookAt(end);
        //Scale the cylinder based on the distance between the two points.
        float dist = Vector3.Distance(start, end);
        Debug.Log(dist);
        Vector3 scaled = edgePrefab.transform.localScale;
        edgePrefab.transform.localScale = new Vector3(scaled.x, scaled.y, dist);
        return edgePrefab.transform.GetChild(0).gameObject;
    }

}
