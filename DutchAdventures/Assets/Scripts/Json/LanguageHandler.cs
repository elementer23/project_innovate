using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LanguageHandler : MonoBehaviour
{
    public string language;
    [SerializeField]
    private JsonHandler jsonHandler;

    private void Awake()
    {
        LangData langData = jsonHandler.ReadFromJson<LangData>("Language");
        this.language = langData.language;
    }

    private void Start()
    {
        jsonHandler = GameObject.FindGameObjectWithTag("JsonHandler").GetComponent<JsonHandler>();
    }

    // saves language to Json
    public void SaveLanguage()
    {
        LangData langData = new LangData(this.language);
        Debug.Log(langData);
        jsonHandler.WriteToJson(langData, "Language");
    }
    // calls function to call the json saver and go to next scene
    public void applyLanguage()
    {
        //TODO: Save language.
        SaveLanguage();
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    // show confirm popup
    public void showPopup(string language)
    {
        this.language = language;
        Debug.Log(language);
        GameObject Canvas = GameObject.Find("Canvas");
        Canvas.GetComponent<ToggleLangConfirmPopup>().getPopup().SetActive(true);
    }
    //close confirm poopup and sets lang to null again
    public void closePopup()
    {
        this.language = null;
        GameObject Canvas = GameObject.Find("Canvas");
        Canvas.GetComponent<ToggleLangConfirmPopup>().getPopup().SetActive(false);
    }

    //returns language
    public string GetLanguage()
    {
        return this.language;
    }
}
