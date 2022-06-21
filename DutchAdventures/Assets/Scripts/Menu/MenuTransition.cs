using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuTransition : MonoBehaviour
{
    public GameObject loadPopup;
    public void toSceneNoPopup(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void toSceneWithPopup(string scene)
    {
        loadPopup.SetActive(true);
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
