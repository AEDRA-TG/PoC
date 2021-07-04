using UnityEngine;

public class TreeController : MonoBehaviour
{
    void Start()
    {
        GameObject gObj = GameObject.Find("TestTree");
        BinaryTree tree = gObj.GetComponent<BinaryTree>();
        tree.addChild(30);
        tree.addChild(25);
        tree.addChild(5);
    }

}