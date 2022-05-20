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
    public PlayerSpawn entracePos;
    public PlayerSpawn exitPos;
    public Vector2 destination;

    private void Start()
    {
        //Place the player at the place where the player entered the building
        player.position = this.GetPreviousPosition(entracePos, exitPos, player);
        Vector3 pos = exitPos.spawnPosition;
        pos.z = -10;
        Camera.main.transform.position = pos;
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
            entracePos.spawnPosition = player.position;
            exitPos.spawnPosition = destination;
            SceneManager.LoadScene(buildIndex);
        }
    }

    private Vector2 GetPreviousPosition(PlayerSpawn entrance, PlayerSpawn exit, Transform player)
    {
        if (HasPreviousPosition(entrance) && HasPreviousPosition(exit))
        {
            return exit.spawnPosition;
        }
        else
        {
            return player.position;
        }
    }

    private bool HasPreviousPosition(PlayerSpawn pos)
    {
        return !pos.spawnPosition.Equals(Vector2.zero);
    }
}

