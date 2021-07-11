using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuItem : MonoBehaviour
{
    [HideInInspector] public Image img;
    //TODO
    [HideInInspector] public Transform trans;
    OptionsMenu optionsMenu;
    Button button;
    int index;

    //TODO
    void Awake() {
        img = GetComponent<Image>();
        trans = transform;

        optionsMenu = trans.parent.GetComponent<OptionsMenu>();
        //number of subitems (substract 1 because of hamburguer)
        index = trans.GetSiblingIndex() - 1;

        button = GetComponent<Button>();
        //button.onClick.AddListener(onItemClick);

    }

    void onItemClick(){
        optionsMenu.OnItemClick(index);
    }

    void OnDestroy() {
        //button.onClick.RemoveListener(onItemClick);
    }
}
