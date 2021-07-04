using UnityEngine;

public class DrawObject: MonoBehaviour
{   
    public static GameObject draw(GameObject prefab, Vector3 coordinates, string unityParent){
        prefab = Instantiate(prefab, coordinates, Quaternion.identity);
        prefab.transform.parent = GameObject.Find(unityParent).transform;
        return prefab.transform.GetChild(0).gameObject;
    }
}