using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuTransition : MonoBehaviour
{
    //The loading popup.
    public GameObject loadPopup;

    /// <summary>
    /// Loads the given scene with no loading popup.
    /// </summary>
    /// <param name="scene">The name of the new scene.</param>
    public void toSceneNoPopup(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    /// <summary>
    /// Loads the given scene with a loading popup.
    /// </summary>
    /// <param name="scene">The name of the new scene.</param>
    public void toSceneWithPopup(string scene)
    {
        loadPopup.SetActive(true);
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
