using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFlag : MonoBehaviour
{
    public LanguageHandler languageHandler;

    public Sprite[] flags;

    // Start is called before the first frame update
    void Start()
    {
        setRightFlag(languageHandler.GetLanguage());
    }

    /// <summary>
    /// Load right flag by chosen langues
    /// </summary>
    /// <param name="lang">Chosen Language</param>
    void setRightFlag(string lang)
    {
        Sprite flag = flags[0];
        switch (lang)
        {
            case "nl":
                flag = flags[0];
                break;
            case "ua":
                flag = flags[1];
                break;
            case "de":
                flag = flags[2];
                break;
            case "en":
                flag = flags[3];
                break;              
        }
        GetComponent<Image>().sprite = flag;
        
    }
}
