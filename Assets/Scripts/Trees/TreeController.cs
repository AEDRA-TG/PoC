using UnityEngine;
using System;

public class TreeController : MonoBehaviour
{
    public void addNode()
    {
        System.Random rand = new System.Random();
        int value = rand.Next(1,100);
        GameObject gObj = GameObject.Find("TestTree");
        BinaryTree tree = gObj.GetComponent<BinaryTree>();
        bool created = tree.addChild(value);
        if (created)
        {
            Utils.sendToast("Node created: " + value);
        }
        else
        {
            Utils.sendToast("Node not created: " + value);
        }
    }

    /*void Start()
    {
        System.Random rand = new System.Random();
        int value = rand.Next(1,100);
        GameObject gObj = GameObject.Find("TestTree");
        BinaryTree tree = gObj.GetComponent<BinaryTree>();
        bool created = tree.addChild(value);
        if (created)
        {
            Utils.sendToast("Node created: " + value);
        }
        else
        {
            Utils.sendToast("Node not created: " + value);
        }
    }*/
}