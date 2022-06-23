using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItemHandler : MonoBehaviour
{
    [Header("Quest items requirements")]
    public string keyItem;
    public string requiredQuest;
    [SerializeField]
    private string[] requiredKeyitems;

    [Header("Quest completion")]
    [SerializeField]
    private bool completeQuest = false;

    protected Transform player;
    protected GameObject pointer;
    protected float minDist = 2;
    protected PlayerQuestHandler playerQuestHandler;
    protected bool canObtain = false;
    protected bool isVisible = false;
    //private Animator completeQuestAnim;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerQuestHandler = player.GetComponent<PlayerQuestHandler>();
        pointer = transform.GetChild(0).gameObject;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = true;
        //completeQuestAnim = GameObject.Find("QuestComplete").GetComponent<Animator>();

        // does not show when required keyitems is not collected
        if (this.requiredKeyitems.Length > 0)
        { 
            foreach (string keyitem in requiredKeyitems)
            {
                if (player.GetComponent<KeyItemsSaver>().hasItem(keyitem))
                {
                    gameObject.SetActive(true);
                }
            }
        }
        // does not show when item is already collected
        if (player.GetComponent<KeyItemsSaver>().hasItem(this.keyItem))
        {
            gameObject.SetActive(false);
        }
    }

    protected virtual void Update()
    {

        float dist = Vector2.Distance(player.position, transform.position);
        canObtain = dist < minDist && isVisible;
        pointer.SetActive(canObtain);

        isVisible = playerQuestHandler.getQuest().title == requiredQuest;
        GetComponent<SpriteRenderer>().enabled = true;
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

                if (completeQuest == true)
                {
                    playerQuestHandler.completeQuest();
                    GameObject.Find("QuestMenu").GetComponent<QuestUI>().completeQuest();
                }

                Destroy(gameObject);
            }
        }
    }
}
