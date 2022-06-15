using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItemHandler : MonoBehaviour
{
    public string keyItem;
    public string requiredQuest;

    protected Transform player;
    protected GameObject pointer;
    protected float minDist = 2;
    protected PlayerQuestHandler playerQuestHandler;
    protected bool canObtain = false;
    protected bool isVisible = false;
    //private Animator completeQuestAnim;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerQuestHandler = player.GetComponent<PlayerQuestHandler>();
        pointer = transform.GetChild(0).gameObject;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = true;
        //completeQuestAnim = GameObject.Find("QuestComplete").GetComponent<Animator>();
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
    protected virtual void OnMouseDown()
    {
        if (canObtain)
        {
            if (isVisible)
            {
                KeyItemsSaver keyItemSaver = player.GetComponent<KeyItemsSaver>();
                keyItemSaver.setItem(keyItem, true);
                //completeQuestAnim.SetTrigger("Play");

                Destroy(gameObject);
            }
        }
    }
}
