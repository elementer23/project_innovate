using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuScreen : MonoBehaviour
{


    //exit the game onclick when in unity or in the .exe or on the phone
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitOnPhone();
        }
    }

    private void QuitOnPhone()
    {
        Input.backButtonLeavesApp = true;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

}
