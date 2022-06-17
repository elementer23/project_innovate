using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Teleporter : MonoBehaviour
{
    public Transform player;
    public string sceneName;
    protected float minDist = 2;
    [SerializeField]
    private GameObject pointer;
    private bool canTravel = false;
    public PlayerSpawn entracePos;
    public PlayerSpawn exitPos;
    public Vector2 destination;
    private BoxCollider2D boxCollider2D;
    public GameObject fadeObject;
    public GameObject loadingText;

    void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
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
        StartCoroutine(teleport());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");   
        StartCoroutine(teleport());
    }

    private IEnumerator teleport()
    {
        if (canTravel)
        {
            entracePos.spawnPosition = player.position;
            exitPos.spawnPosition = destination;
            if(fadeObject != null)
            { 
                Animator anim = fadeObject.GetComponent<Animator>();
                anim.SetTrigger("Start");
                yield return new WaitForSeconds(1f);
                
            }
            if (loadingText != null)
            {
                loadingText.SetActive(true);
            }
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
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

