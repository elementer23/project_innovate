using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
    }

    public void toLanguageMenu()
    {
        SceneManager.LoadScene("LanguageMenu", LoadSceneMode.Single);
    }

}
