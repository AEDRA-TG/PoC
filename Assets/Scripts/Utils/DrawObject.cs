using UnityEngine;
using DG.Tweening;

public class DrawObject : MonoBehaviour
{
    public static int POS_NODE = 0;

    public static GameObject
    draw(GameObject prefab, Vector3 coordinates, string unityParent)
    {
        prefab = Instantiate(prefab, coordinates, Quaternion.identity);
        prefab.transform.parent = GameObject.Find(unityParent).transform;
        prefab.name = "Node_" + (DrawObject.POS_NODE++);
        DrawObject.POS_NODE++;
        return prefab.transform.GetChild(0).gameObject;
    }

    public static GameObject drawEdge(GameObject prefab, Vector3 start, Vector3 end, string unityParent)
    {
        float width = 0.025f;
        Vector3 offset = end - start;
        Vector3 scale = new Vector3(width, offset.magnitude / 2.0f, width);
        Vector3 position = start + (offset / 2.0f);

        GameObject cylinder = Instantiate(prefab, position, Quaternion.identity);
        cylinder.transform.parent = GameObject.Find(unityParent).transform;
        cylinder = cylinder.transform.GetChild(0).gameObject;
        cylinder.transform.up = offset;
        cylinder.transform.localScale = scale;

        return cylinder;
    }

    public static void moveNode(ProjectedObject node, Vector3 coordinates)
    {
        GameObject prefab = node.gameObject.transform.parent.gameObject;
        prefab.transform.position = coordinates;
    }

    public static void moveEdge(TreeEdge edge)
    {
        Vector3 start = edge.from.coordinates;
        Vector3 end = edge.to.coordinates;

        float width = 0.010f;
        Vector3 offset = end - start;
        Vector3 scale = new Vector3(width, offset.magnitude / 2.0f, width);
        Vector3 position = start + (offset / 2.0f);

        GameObject cylinder = edge.gameObject.transform.parent.gameObject;
        cylinder.transform.position = position;
        cylinder = cylinder.transform.GetChild(0).gameObject;
        cylinder.transform.up = offset;
        cylinder.transform.localScale = scale;
    }

    public static void reposition(string unityParent)
    {
        float speed = 1;
        Vector3 imageTargetPosition = GameObject.Find(unityParent).transform.position;
        GameObject tree = GameObject.Find("TestTree");
        tree.transform.position = imageTargetPosition;
        tree.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
    }

    public static void changeColor(ProjectedObject obj, Color color){
        MeshRenderer mesh = obj.gameObject.GetComponent<MeshRenderer>();
        mesh.material.DOColor(color, 2f);
    }
}
