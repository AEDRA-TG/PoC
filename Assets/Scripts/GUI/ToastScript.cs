using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToastScript : MonoBehaviour
{
    Text toastText;
    private string text;
    public void Start(){
        toastText = GameObject.Find("ToastText").GetComponent<Text>();
        toastText.text = "holii";
    }

    public void setText(string text){
        this.text = text;
        SceneManager.LoadScene( "ToastScene", LoadSceneMode.Additive );
    }
}
