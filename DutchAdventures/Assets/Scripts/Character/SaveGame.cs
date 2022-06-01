using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour
{

    private GameObject playerObject = null;
    private int frames = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (playerObject == null)
        {
            playerObject = GameObject.Find("Player");
        }

        int activeScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        frames++;
        if (frames % 120 == 0)
        {
            Debug.Log("x: " + " " + playerObject.transform.position.x + "y: " + " " + playerObject.transform.position.y);
        }
    }
}
