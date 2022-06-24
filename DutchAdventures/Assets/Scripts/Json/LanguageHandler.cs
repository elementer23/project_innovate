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

    /// <summary>
    /// saves language to Json
    /// </summary>
    public void SaveLanguage()
    {
        LangData langData = new LangData(this.language);
        Debug.Log(langData);
        jsonHandler.WriteToJson(langData, "Language");
    }

    /// <summary>
    /// calls function to call the json saver and go to next scene
    /// </summary>
    public void applyLanguage()
    {
        //TODO: Save language.
        SaveLanguage();
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    /// <summary>
    /// show confirm popup
    /// </summary>
    /// <param name="language">String with language</param>
    public void showPopup(string language)
    {
        this.language = language;
        Debug.Log(language);
        GameObject Canvas = GameObject.Find("Canvas");
        Canvas.GetComponent<ToggleLangConfirmPopup>().getPopup().SetActive(true);
    }

    /// <summary>
    /// close confirm poopup and sets lang to null again
    /// </summary>
    public void closePopup()
    {
        this.language = null;
        GameObject Canvas = GameObject.Find("Canvas");
        Canvas.GetComponent<ToggleLangConfirmPopup>().getPopup().SetActive(false);
    }

    /// <summary>
    /// returns language
    /// </summary>
    /// <returns>String with language</returns>
    public string GetLanguage()
    {
        return this.language;
    }
}
