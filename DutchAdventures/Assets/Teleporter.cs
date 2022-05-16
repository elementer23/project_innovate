using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public Transform player;
    public int buildIndex;
    public float minDist = 2;
    [SerializeField]
    private GameObject pointer;
    private bool canTravel = false;
    [SerializeField]
    private bool isOverworld = false;
    public PlayerSpawn playerSpawn;
    
    private void Start()
    {
        if (isOverworld)
        {
            player.position = playerSpawn.spawnPosition;
            Vector3 pos = playerSpawn.spawnPosition;
            pos.z = -10;
            Camera.main.transform.position = pos;
        }
    }

    private void Update()
    {
        float dist = Vector2.Distance(player.position, transform.position);
        canTravel = dist < minDist;
        pointer.SetActive(canTravel);
    }

    private void OnMouseDown()
    {
        if (canTravel)
        {
            if (isOverworld)
            {
                playerSpawn.spawnPosition = player.position;
            }
            Debug.Log("dsda");
            SceneManager.LoadScene(buildIndex);
        }
    }
}

