using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour
{

    //private GameObject playerObject = null;
    public Transform player;
    //private Scene currentScene;
    public PlayerSpawn lastPos;
    //private int frames = 0;
    // Start is called before the first frame update
    void Start()
    {
        player.position = this.GetLastPlayerPosition(lastPos, player);
        //if (playerObject == null)
        //{
        //    playerObject = GameObject.Find("Player");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        lastPos.spawnPosition = player.position;
        //int activeScene = SceneManager.GetActiveScene().buildIndex;
        //currentScene = SceneManager.GetActiveScene();
        //Debug.Log("current buildIndex: " + " " + activeScene + " " + "current Scene: " + currentScene.name);
        //frames++;
        //if (frames % 360 == 0)
        //{
        //    Debug.Log("x: " + " " + playerObject.transform.position.x + "y: " + " " + playerObject.transform.position.y);
        //    int activeScene = SceneManager.GetActiveScene().buildIndex;
        //    currentScene = SceneManager.GetActiveScene();
        //    Debug.Log("current buildIndex: " + " " + activeScene + " " + "current Scene: " + currentScene.name);
        //}
    }

    private Vector2 GetLastPlayerPosition(PlayerSpawn lastPosition, Transform player)
    {
        if (hasPreviousPosition(lastPosition))
        {
            return lastPosition.spawnPosition;
        }
        else
        {
            return player.position;
        }
    }

    private bool hasPreviousPosition(PlayerSpawn pos)
    {
        return !pos.spawnPosition.Equals(Vector2.zero);
    }
}
