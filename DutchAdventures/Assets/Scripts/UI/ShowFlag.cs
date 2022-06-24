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
        Debug.Log(languageHandler.GetLanguage());
        setRightFlag(languageHandler.GetLanguage());
    }

    //Load right flag by chosen langues
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
