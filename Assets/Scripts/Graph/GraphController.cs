using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController : MonoBehaviour
{
    //Material
    [SerializeField]
    private Material material;
    //Object selection
    private ObjectSelection objectSelection;
    //Grafo
    private Graph projectedGraph;
    [SerializeField]

    //Prefabs
    private GameObject nodePrefab;
    [SerializeField]
    private GameObject edgePrefab;

    //Booleano que indica si queremos que los objetos no se muevan 
    //(Se pierde la repulsion si esta en true)
    [SerializeField]
    private bool allStatic = false;

    //Valor de fuerza que se aplica sobre los objetos para la repulsión
    [SerializeField]
    private float repulseForceStrength = 0.5f;
    //Booleano que indica si los nodos se repelen entre ellos o no
    [SerializeField]
    private bool repulseActive = true;
    [SerializeField]
    //Valor de la gravedad que tendran los objetos
    private float globalGravityPhysX = 0f;
    //Valor de la distancia a la cual se mantendran separados los nodos unos de otros
    [SerializeField]
    private float nodePhysXForceSphereRadius = 0.5F;
    //Valor de la fuerza de acercamiento cuando se agregan aristas
    [SerializeField]
    private float linkForceStrength = 6F;
    //Valor del largo que tendra la arista cuando es creada. 
    [SerializeField]
    private float linkIntendedLinkLength = 5F; 

    //Variables unicamente de prueba se usan para conectar aristas
    [SerializeField]
    private int originNode;
    [SerializeField]
    private int destinationNode;
    void Start()
    {
        projectedGraph = new Graph();
        objectSelection = FindObjectOfType<ObjectSelection>();
    }

    
    void Update()
    {
        //Setea estos valores a las variables dentro de la clase link
        Link.intendedLinkLength = linkIntendedLinkLength;
        Link.forceStrength = linkForceStrength;
        Link.material = material;
    }
    
    //Metodo que se ejecuta cuando se añade un nodo
    public void onClickAddNode(int nodesCount){
        for(int i = 0; i < nodesCount; i++){
            projectedGraph.addNode(nodePrefab);
        }
    }

    //Metodo que se ejecuta cuando se añade una arista
    public void onClickAddLink(int linksCount){
        if(objectSelection.selectedObjects.Count == 2){
            projectedGraph.addBidirectionalEdge(edgePrefab, objectSelection.selectedObjects[0], objectSelection.selectedObjects[1]);
        }
    }




    #region Getters y Setters
    public float RepulseForceStrength
    {
        get
        {
            return repulseForceStrength;
        }
        private set
        {
            repulseForceStrength = value;
        }
    }
    public bool AllStatic
    {
        get
        {
            return allStatic;
        }
        set
        {
            allStatic = value;
        }
    }

    public bool RepulseActive
    {
        get
        {
            return repulseActive;
        }
        set
        {
            repulseActive = value;
        }
    }
    public float GlobalGravityPhysX
    {
        get
        {
            return globalGravityPhysX;
        }
        set
        {
            globalGravityPhysX = value;
        }
    }
    public float NodePhysXForceSphereRadius
    {
        get
        {
            return nodePhysXForceSphereRadius;
        }
        set
        {
            nodePhysXForceSphereRadius = value;
        }
    }

    public float LinkForceStrength
    {
        get
        {
            return linkForceStrength;
        }
        private set
        {
            linkForceStrength = value;
        }
    }

    public float LinkIntendedLinkLength
    {
        get
        {
            return linkIntendedLinkLength;
        }
        set
        {
            linkIntendedLinkLength = value;
        }
    }
    #endregion
}
