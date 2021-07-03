using UnityEngine;

public class DrawObject : MonoBehaviour
{   
    [SerializeField]
    private GameObject prefab;
    public static void draw(ProjectedObject obj, string unityParent){
        obj = Instantiate(obj, obj.coordinates, Quaternion.identity);
        obj.transform.parent = GameObject.Find(unityParent).transform;
    }
}