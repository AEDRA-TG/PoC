using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;


public class AlternativeObjectSelection : MonoBehaviour
{

    [SerializeField]
    private ProjectedObject[] projectedObjects;

    [SerializeField]
    private Color selectedColor = Color.red;

    [SerializeField]
    private Color noSelectedColor = Color.white;

    private ArrayList selectedObjects;

    // !- MULTISELECTION

    private float pointerDownTimer;
    [SerializeField]
    public double requieredHoldTime;

    private bool pointerDown;

    private bool multiselectionMode;

    private Image backImage;

    private Image exitMultiSelectionImage;

    private Button backButton;

    private Button exitMultiSelectionButton;
    // ? METHODS

    void Start()
    {
        multiselectionMode = false;
        pointerDown = false;
        int count = 0;
        selectedObjects = new ArrayList();
        backImage = GameObject.Find("BackButton").GetComponent<Image>();
        exitMultiSelectionImage = GameObject.Find("ExitMultiSelection").GetComponent<Image>();
        backButton = GameObject.Find("BackButton").GetComponent<Button>();
        exitMultiSelectionButton = GameObject.Find("ExitMultiSelection").GetComponent<Button>();
        
        foreach (ProjectedObject obj in projectedObjects)
        {
            obj.ID = count;
            count++;
        }
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
    }

    void Update()
    {
        if(multiselectionMode && selectedObjects.Count == 0){
            multiselectionMode = false;
            Debug.Log("MUTISELECTION OFF");
            //Utils.sendToast("Multiselección desactivada");
            toggleBackButton(true);
        }

        if(pointerDown && !multiselectionMode){
            pointerDownTimer += Time.deltaTime;
            if(pointerDownTimer >= requieredHoldTime){
                Debug.Log("MULTISELECTION ON");
                //Utils.sendToast("Multiselección activada");
                toggleBackButton(false);
                multiselectionMode = true;
                Reset();
            }
        }

#if UNITY_EDITOR

        if (Input.GetMouseButtonDown(0))
        {
            pointerDown = true;
            SelectObject(Input.mousePosition);
        }
        
        if(Input.GetMouseButtonUp(0)){
            Reset();
        }

        

        

#elif UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            // TODO 
            if (touch.phase == TouchPhase.Began)
            {
                pointerDown = true;
                SelectObject(touch.position);
            }

            if(touch.phase == TouchPhase.Ended){
                Reset();
            }
        }
#endif
    }
    public void SelectObject(Vector3 inputPosition)
    {
        ProjectedObject selectedObject = GetSelectedObject(inputPosition);
        if(selectedObject != null)
        {
            if (selectedObjects.Count != 0)
            {
                if(!multiselectionMode)
                {
                    ProjectedObject obj = (ProjectedObject)selectedObjects[0];
                        UpdateSelectionStatus(obj);
                    if (selectedObject.ID != obj.ID)
                    {
                        UpdateSelectionStatus(selectedObject);
                    }
                }
                else
                {
                    UpdateSelectionStatus(selectedObject);
                }            
            }
            else
            {
                UpdateSelectionStatus(selectedObject);
            }
        }
    }
    private ProjectedObject GetSelectedObject(Vector3 inputPosition){
        ProjectedObject selectedObject = null;
        Ray ray = Camera.main.ScreenPointToRay(inputPosition);
        RaycastHit hitObject;
        if (Physics.Raycast(ray, out hitObject))
        {
            selectedObject = hitObject.transform.GetComponent<ProjectedObject>();
        }
        return selectedObject;
    }
    public void UpdateSelectionStatus(ProjectedObject obj)
    {
        // TODO 
        MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
        if (obj.Selected)
        {
            obj.Selected = false;
            meshRenderer.material.color = noSelectedColor;
            selectedObjects.Remove(obj);
        }
        else
        {
            obj.Selected = true;
            meshRenderer.material.color = selectedColor;
            selectedObjects.Add(obj);
        }
    }

    //TODO: order code in different classes
    public void toggleBackButton(bool visible)
    {
        if(visible)
        {
            backImage.DOFade(1f, 0);
            exitMultiSelectionImage.DOFade(0f, 0);
            backButton.interactable = true;
            exitMultiSelectionButton.interactable = false; 
            backButton.transform.SetAsLastSibling();
        }else
        {
            backImage.DOFade(0f, 0);
            exitMultiSelectionImage.DOFade(1f, 0);
            backButton.interactable = false;
            exitMultiSelectionButton.interactable = true;
            exitMultiSelectionButton.transform.SetAsLastSibling();
        }
    }

    public void exitMultiSelectionMode()
    {
        //Utils.sendToast("Multiselección desactivada");
        toggleBackButton(true);
        multiselectionMode = false;
        while(selectedObjects.Count > 0)
        {
           UpdateSelectionStatus((ProjectedObject)selectedObjects[0]); 
        }
    }

}
