using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LanguageData : MonoBehaviour
{

    public string language = null;
    public GameObject popup;

    void start ()
    {
      //  popup = GameObject.Find("ConfirmPopup");
    }

    public void applyLanguage()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void showPopup(string language)
    {
        this.language = language;
        Debug.Log(language);
        popup.SetActive(true);
    }

    public void closePopup()
    {
        this.language = null;
        popup.SetActive(false);
    }

    //  

}
