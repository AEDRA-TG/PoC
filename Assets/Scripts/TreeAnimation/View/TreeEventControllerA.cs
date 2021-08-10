using UnityEngine;
public class TreeEventControllerA : MonoBehaviour {

    private TreeControllerA treeController;
    private void Awake() {
        this.treeController = new TreeControllerA();
    }
    public void onClickAddNode(int value){
        treeController.AddNode(value);
    }
}