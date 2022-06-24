using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFlag : MonoBehaviour
{
    public LanguageHandler languageHandler;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(languageHandler.GetLanguage());
        setRightFlag(languageHandler.GetLanguage());
    }

    //Load right flag by chosen langues
    void setRightFlag(string lang)
    {
        Sprite flag = Resources.Load<Sprite>("ua_small");
        switch (lang)
        {
            case "nl":
                 flag = Resources.Load<Sprite>("Sprites/flags/nl_small");
                break;
            case "ua":
                 flag = Resources.Load<Sprite>("Sprites/flags/ua_small");
                break;
            case "de":
                 flag = Resources.Load<Sprite>("Sprites/flags/de_small");
                break;
            case "en":
                flag = Resources.Load<Sprite>("Sprites/flags/en_small");
                break;              
        }
        GetComponent<Image>().sprite = flag;
        
    }
}
