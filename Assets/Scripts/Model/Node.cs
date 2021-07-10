using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : MonoBehaviour
{

    public int posCoordinate {get; set;}

    [SerializeField]
    protected static bool verbose = true;

    protected static GraphController graphControl;

    private string id;
    private string text;
    private string type;

    public string Id
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }

    public string Text
    {
        get
        {
            return text;
        }
        set
        {
            text = value;
        }
    }

    public string Type
    {
        get
        {
            return type;
        }
        set
        {
            type = value;
        }
    }

    protected abstract void doGravity();

    protected abstract void doRepulse();

    protected virtual void Start()
    {
        graphControl = FindObjectOfType<GraphController>();
    }

    void FixedUpdate()
    {
        if (!graphControl.AllStatic && graphControl.RepulseActive)
            doRepulse();

        if (!graphControl.AllStatic)
            doGravity();
    }
    public static GameObject ShowNode(GameObject nodePrefab,Vector3 coordinate, int posNode){
        nodePrefab = Instantiate(nodePrefab, coordinate, Quaternion.identity);
        nodePrefab.transform.parent = GameObject.Find("Graph").transform;
        nodePrefab.name = "Node_" + (posNode);
        return nodePrefab.transform.GetChild(0).gameObject;
    }
    
}
