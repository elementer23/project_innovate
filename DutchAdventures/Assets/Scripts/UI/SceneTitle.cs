using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneTitle : MonoBehaviour
{
    public TextMeshProUGUI sceneText;
    public string sceneName;

    void Start()
    {
        //set the scenetext to the scene name
        sceneText.text = sceneName;
    }
}
