using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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

    public void targetFound()
    {
        GameObject arFrameImage = GameObject.Find("ArFrame");
        arFrameImage.GetComponent<Image>().DOFade(0.0f,0.0f);
    }

    public void targetLost()
    {
        GameObject arFrameImage = GameObject.Find("ArFrame");
        arFrameImage.GetComponent<Image>().DOFade(1.0f,0.0f);
    }
}
