using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItemHandler : MonoBehaviour
{
    public string keyItem;
    public string requiredQuest;

    private Transform player;
    private GameObject pointer;
    private float minDist = 2;
    private PlayerQuestHandler playerQuestHandler;
    private bool canObtain = false;
    private bool isVisible = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerQuestHandler = player.GetComponent<PlayerQuestHandler>();
        pointer = transform.GetChild(0).gameObject;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    void Update()
    {
        float dist = Vector2.Distance(player.position, transform.position);
        canObtain = dist < minDist && isVisible;
        pointer.SetActive(canObtain);

        isVisible = playerQuestHandler.getQuest().title == requiredQuest;
        GetComponent<SpriteRenderer>().enabled = isVisible;
    }

    //Pickups quest item if the player press down and is in range
    private void OnMouseDown()
    {
        if (canObtain)
        {
            if (isVisible)
            {
                KeyItemsSaver keyItemSaver = player.GetComponent<KeyItemsSaver>();
                keyItemSaver.setItem(keyItem, true);
                keyItemSaver.SaveItems();

                Destroy(gameObject);
            }
        }
    }
}
