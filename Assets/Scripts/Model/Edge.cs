using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    [SerializeField]
    private GameObject edgePrefab;

    public GameObject GetEdgePrefab(){
        return edgePrefab;
    }

    public void SetEdgePrefab(GameObject newPrefab){
        edgePrefab = newPrefab;
    }
}
