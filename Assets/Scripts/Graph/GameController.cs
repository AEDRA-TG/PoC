using UnityEngine;

[RequireComponent(typeof(GraphController))]

public class GameController : MonoBehaviour {

    // use BulletUnity or PhysX?
    [SerializeField]
    private bool engineBulletUnity = true;
    

    public bool EngineBulletUnity
    {
        get
        {
            return engineBulletUnity;
        }
        private set
        {
            engineBulletUnity = value;
        }
    }

    void Start()
    {
    }

    void Update()
    {
    }
}
