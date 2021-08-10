using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testController : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;


    // Start is called before the first frame update
    public void AddElement()
    {
        string unityParent = "ImageTarget";
        Vector3 coordinates = GameObject.Find("ImageTarget").transform.position;
        prefab = Instantiate(prefab, coordinates, Quaternion.identity);
        prefab.transform.parent = GameObject.Find(unityParent).transform;
        prefab.name = "Node_" + (DrawObject.POS_NODE++);
        DrawObject.POS_NODE++; 
    }

    // Update is called once per frame
    void Update()
    {
    }
}
