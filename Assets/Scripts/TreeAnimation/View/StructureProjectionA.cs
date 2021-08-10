using UnityEngine;
using System.Collections.Generic;
public class StructureProjectionA : MonoBehaviour{

    private List<int> animationList;

    private void Awake() {
        this.animationList = new List<int>();
    }
    private void OnEnable() {
        NodeA.OperationNotifier += AddObject;
        TreeControllerA.OperationNotifier += AddNodeAnimation;

    }
    private void OnDisable() {
        NodeA.OperationNotifier -= AddObject;
        TreeControllerA.OperationNotifier -= AddNodeAnimation;
    }

    private void AddObject(int ID)
    {
        animationList.Add(ID);
    }

    private void AddNodeAnimation()
    {
        Debug.Log("----------------------------------");
        foreach (int id in animationList)
        {
            Debug.Log("id -> " + id + " \n");
        }
        animationList.Clear();
    }    

    
}