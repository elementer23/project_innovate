using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMiniGame : MonoBehaviour
{
    public Transform player;
    protected float minDist = 2;
    private bool canStart = false;
    [SerializeField]
    private GameObject pointer;
    public string[] neededKeyItem;
    private KeyItemsSaver keyItemsSaver;

    [SerializeField]
    private GameObject world;
    [SerializeField]
    private GameObject minigame;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = true;
        keyItemsSaver = player.GetComponent<KeyItemsSaver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasAllKeyItems())
        {
            float dist = Vector2.Distance(player.position, transform.position);
            canStart = dist < minDist;
            pointer.SetActive(canStart);
        }
        else
        {
            pointer.SetActive(false);
        }
    }

    /// <summary>
    /// Start quest if parameters are true
    /// </summary>
    private void OnMouseDown()
    {
        if (hasAllKeyItems() && canStart)
        {
            world.SetActive(false);
            minigame.SetActive(true);
        }
    }

    /// <summary>
    /// check if player hass all keyitems
    /// </summary>
    /// <returns>True or false</returns>
    private bool hasAllKeyItems()
    {
        foreach (string item in neededKeyItem)
        {
            if (!keyItemsSaver.hasItem(item)) {
                return false;
            }
        }

        return true;
    }
}
