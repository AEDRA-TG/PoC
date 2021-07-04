using UnityEngine;

public class DrawObject: MonoBehaviour
{   
    public static GameObject draw(GameObject prefab, Vector3 coordinates, string unityParent)
    {
        prefab = Instantiate(prefab, coordinates, Quaternion.identity);
        prefab.transform.parent = GameObject.Find(unityParent).transform;
        return prefab.transform.GetChild(0).gameObject;
    }

    public static GameObject drawEdge(GameObject prefab, Vector3 start, Vector3 end, string unityParent)
    {
        //Instantiate cylinder, use one of the points as the point of instantiation.
        Vector3 midPoint = (start + end)/2;
        prefab = Instantiate(prefab, midPoint, Quaternion.identity);
        prefab.transform.parent = GameObject.Find(unityParent).transform;
        //Look at Transform.LookAt to make the cylinder face the other point.
        prefab.transform.LookAt(end);
        //Scale the cylinder based on the distance between the two points.
        float dist = Vector3.Distance(start, end);
        Vector3 scaled = prefab.transform.localScale;
        prefab.transform.localScale = new Vector3(scaled.x, scaled.y, dist);
        return prefab.transform.GetChild(0).gameObject;
    }
}