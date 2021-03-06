using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class BinaryTree : MonoBehaviour
{

    public static float MAX_WIDTH = 3f;
    public static float MAX_HEIGHT = 1.5f;
    [SerializeField]
    private BinaryNode root;
    public int levels { get; set; }
    public List<int> nodesByLevel;

    public BinaryTree()
    {
        this.levels = 0; //TODO: Delete this chochinada
        nodesByLevel = new List<int>();
        nodesByLevel.Add(1);
    }

    public bool addChild(int value)
    {
        bool created = false;
        root.level = 0; //TODO: Delete this cochinada
        root.parentEdge = null; //TODO: Delete this cochinada
        root.coordinates = root.gameObject.transform.position; //TODO: Delete this cochinada
        
        if (root != null)
        {
            List<BinaryNode> nodes = new List<BinaryNode>();
            BinaryNode newNode = root.addChild(value, nodes);
            if (newNode != null)
            {
                created = true;
                if (newNode.level > this.levels)
                {
                    this.levels = newNode.level;
                    nodesByLevel.Add(1);
                }
                else
                {
                    nodesByLevel[newNode.level]++;
                }
                //TODO: Redraw the tree 
                redrawTree(root, this.levels);
            }
        }
        else
        {
            //root = createNode(value);
        }
        return created;
    }

    public void redrawTree(BinaryNode root, int levels)
    {
        Queue<BinaryNode> queue = new Queue<BinaryNode>();
        int currentLevel = root.level;
        float height = BinaryTree.MAX_HEIGHT / levels;
        float width = 0;
        float x = root.coordinates.x;
        float y = root.coordinates.y;
        float z = root.coordinates.z;
        int nodesCount = 0;
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            BinaryNode node = queue.Dequeue();
            //draw node
            if (node != null)
            {
                nodesCount++;
                //draw node
                node.coordinates = new Vector3(x, y, z);
                DrawObject.moveNode(node, node.coordinates);

                //if exceed nodes count in current level, then advance to next level
                if (nodesCount == nodesByLevel[currentLevel])
                {
                    //calculate next level width
                    currentLevel++;
                    width = (float)(BinaryTree.MAX_WIDTH / (Math.Pow(2, currentLevel) + 1));
                    //this is a new level
                    y -= height;
                    //find leftmost point in X axis
                    x = root.coordinates.x - BinaryTree.MAX_WIDTH / 2;
                    x += width;
                    nodesCount = 0;
                }
                else
                {
                    //this is the same level
                    x += width;
                }

                //reposition edge
                if (node.parentEdge != null)
                {
                    DrawObject.moveEdge(node.parentEdge);
                }
                //add children to queue
                queue.Enqueue(node.leftChild);
                queue.Enqueue(node.rightChild);
            }
            else
            {
                //if node is null, reserve space
                x += width;
                if (currentLevel < levels)
                {
                    queue.Enqueue(null);
                    queue.Enqueue(null);
                }
            }
        }
    }

}
