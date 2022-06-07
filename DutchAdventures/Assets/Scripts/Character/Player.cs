using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public string getCurrentScene()
    {
        string getScene = SceneManager.GetActiveScene().name;

        return getScene;
    }
}
