using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    /// <summary>
    /// Returns current scene
    /// </summary>
    /// <returns>Scene name</returns>
    public string getCurrentScene()
    {
        string getScene = SceneManager.GetActiveScene().name;

        return getScene;
    }
}
