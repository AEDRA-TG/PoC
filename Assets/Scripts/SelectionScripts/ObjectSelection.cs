using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ObjectSelection : MonoBehaviour
{
    [SerializeField]
    private ProjectedObject[] projectedObjects;

    [SerializeField]
    private Color selectedColor = Color.red;

    [SerializeField]
    private Color noSelectedColor = Color.white;
    public List<string> selectedObjects;
    public string projectedObjectName;

    void Start() {
        selectedObjects = new List<string>();
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitObject;
            if (Physics.Raycast(ray, out hitObject))
            {
                ProjectedObject selectedObject =
                    hitObject.transform.GetComponent<ProjectedObject>();
                if (selectedObject != null)
                {
                    projectedObjectName = hitObject.collider.gameObject.name;
                    UpdateSelectedObjectStatus (selectedObject);
                }
            }
        }

#elif UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            // TODO 
            if (touch.phase == TouchPhase.Began)
            {
                // TODO 
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    // TODO
                    ProjectedObject selectedObject =
                        hitObject.transform.GetComponent<ProjectedObject>();
                    if (selectedObject != null)
                    {
                        projectedObjectName = hitObject.collider.gameObject.name;
                        UpdateSelectedObjectStatus (selectedObject);
                    }
                }
            }
        }
#endif
    }

    void UpdateSelectedObjectStatus(ProjectedObject selectedObject)
    {
        // TODO 
        MeshRenderer meshRenderer = selectedObject.GetComponent<MeshRenderer>();
        if (selectedObject.Selected)
        {
            selectedObject.Selected = false;
            meshRenderer.material.color = noSelectedColor;
            selectedObjects.Remove(projectedObjectName);
        }
        else
        {
            selectedObject.Selected = true;
            meshRenderer.material.color = selectedColor;
            selectedObjects.Add(projectedObjectName);
        }
    }
}
