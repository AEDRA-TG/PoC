using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScreen : MonoBehaviour
{
    [SerializeField]
    int nextPage;

    public void changeScreen(){
        SceneManager.LoadScene(nextPage);
    }
}
