using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class OptionsMenu : MonoBehaviour
{
    [Header("Space between menu items")]
    [SerializeField] Vector2 spacing;

    [Space] 
    [Header ("Main button rotation")]
    [SerializeField] float rotationDuration;
    [SerializeField] Ease rotationEase; 

    [Space] 
    [Header ("Animation")]
    [SerializeField] float expandDuration;
    [SerializeField] float collapseDuration;
    [SerializeField] Ease expandEase; 
    [SerializeField] Ease collapseEase; 

    [Space] 
    [Header ("Fading")]
    [SerializeField] float expandFadeDuration;
    [SerializeField] float collapseFadeDuration;

    Button mainButton;
    OptionsMenuItem[] optionItems;
    bool isExpanded;
    Vector2 mainButtonPosition;
    int itemsCount;

    // Start is called before the first frame update
    void Start()
    {
        //substract one to exclude the hamburger menu
        itemsCount = transform.childCount - 1;
        //inflate array
        optionItems = new OptionsMenuItem[itemsCount];
        for (int i = 0; i < itemsCount; i++)
        {
            optionItems[i] = transform.GetChild(i + 1).GetComponent<OptionsMenuItem>();
            //TODO
            optionItems[i].img.DOFade(0f, 0);

        }
        //inflate hamburger menu
        mainButton = transform.GetChild(0).GetComponent<Button>();
        mainButton.onClick.AddListener(ToggleMenu);
        mainButton.transform.SetAsLastSibling();
        //save position of hamburguer position
        mainButtonPosition = mainButton.transform.position;

        ResetPositions();
    }

    //
    void ResetPositions()
    {
        for (int i = 0; i < itemsCount; i++)
        {
            optionItems[i].trans.position = mainButtonPosition;
        }
    }

    void ToggleMenu()
    {
        //TODO: expand
        if (!isExpanded)
        {
            for (int i = 0; i < itemsCount; i++)
            {
                //optionItems[i].trans.position = mainButtonPosition + spacing * (i + 1);
                optionItems[i].trans.DOMove (mainButtonPosition + spacing * (i + 1), expandDuration).SetEase(expandEase); 
                optionItems[i].img.DOFade(1f, expandFadeDuration).From(0f);
            }
        }
        //TODO: collapse
        else
        {
            for (int i = 0; i < itemsCount; i++)
            {
                //optionItems[i].trans.position = mainButtonPosition;
                optionItems[i].trans.DOMove (mainButtonPosition, collapseDuration).SetEase(collapseEase); 
                optionItems[i].img.DOFade(0f, collapseFadeDuration);
            }
        }
        isExpanded = !isExpanded;
        //rotate main button (Optional)
        mainButton.transform
            .DORotate(Vector3.forward * 180f, rotationDuration)
            .From (Vector3.zero)
            .SetEase(rotationEase);
    }

    private void OnDestroy() {
        //Remove event listeners to avoid memory leaks
        mainButton.onClick.RemoveListener(ToggleMenu);
    }

    public void OnItemClick(int index){
        switch(index){
            case 0:
                Debug.Log("Añadir nodo");
                break;
            case 1:
                Debug.Log("Eliminar nodo");
                break;

            case 2:
                Debug.Log("Recorrer ED");
                break;
        }
    }
}