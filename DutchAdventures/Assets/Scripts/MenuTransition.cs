using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTransition : MonoBehaviour
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

    public void toGame()
    {
        SceneManager.LoadScene("BigCityScene", LoadSceneMode.Single);
    }

}
