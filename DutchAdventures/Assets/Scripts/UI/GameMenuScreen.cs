using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuScreen : MonoBehaviour
{


    /// <summary>
    /// exit the game onclick when in unity or in the .exe or on the phone
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitOnPhone();
        }
    }

    /// <summary>
    /// Quit app on phone
    /// </summary>
    private void QuitOnPhone()
    {
        Input.backButtonLeavesApp = true;
    }

    /// <summary>
    /// loads scene to Main menu
    /// </summary>
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Exits game in unity or on phone
    /// </summary>
    public void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

}
