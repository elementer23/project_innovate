using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public Transform player;
    public int buildIndex;
    protected float minDist = 2;
    [SerializeField]
    private GameObject pointer;
    private bool canTravel = false;
    [SerializeField]
    private bool isOverworld = false;
    public PlayerSpawn playerSpawn;
    
    private void Start()
    {
        //If the player is in the normal world, i.e. not in a building:
        if (isOverworld)
        {
            //Place the player at the place where the player entered the building
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
            SceneManager.LoadScene(buildIndex);
        }
    }
}

