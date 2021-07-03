using UnityEngine;

public class TreeController : MonoBehaviour
{
    void Start()
    {
        GameObject gObj = GameObject.Find("TestTree");
        Debug.Log(gObj);
        BinaryTree tree = gObj.GetComponent<BinaryTree>();
        tree.addChild(30);
    }

}