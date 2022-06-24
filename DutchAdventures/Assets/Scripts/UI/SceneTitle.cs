using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneTitle : MonoBehaviour
{
    public TextMeshProUGUI sceneText;
    public string sceneName;

    /// <summary>
    /// set the scenetext to the scene name
    /// </summary>
    void Start()
    {
        sceneText.text = this.sceneName;
    }
}
