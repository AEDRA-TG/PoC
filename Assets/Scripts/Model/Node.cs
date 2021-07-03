using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField]
    private GameObject nodePrefab;

    public void ShowNode(){
        nodePrefab = Instantiate(nodePrefab, new Vector3(0f, -0.018f, 3.20f), Quaternion.identity);
        nodePrefab.transform.parent = GameObject.Find("Graph").transform;
    }

    public GameObject GetNodePrefab(){
        return nodePrefab;
    }

    public void SetNodePrefab(GameObject newPrefab){
        nodePrefab = newPrefab;
    }
}
