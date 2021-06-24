using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeObjectSelection : MonoBehaviour
{

    [SerializeField]
    private ProjectedObject[] projectedObjects;

    [SerializeField]
    private Color selectedColor = Color.red;

    [SerializeField]
    private Color noSelectedColor = Color.gray;

    private ArrayList selectedObjects;

    void Start()
    {
        int count = 0;
        selectedObjects = new ArrayList();
        foreach (ProjectedObject obj in projectedObjects)
        {
            obj.ID = count;
            count++;
        }
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
        
        // If the 
        if(selectedObjects.Count != 0)
        {
            foreach (ProjectedObject obj in selectedObjects)
            {
                obj.Selected = false;
                meshRenderer.material.color = noSelectedColor;
                selectedObjects.Remove(obj);
            }
        }
        else
        {    
            
            if (selectedObject.Selected)
            {
                selectedObject.Selected = false;
                meshRenderer.material.color = noSelectedColor;
            }
            else
            {
                selectedObject.Selected = true;
                meshRenderer.material.color = selectedColor;
            }
        }
    }
}
