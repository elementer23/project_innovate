using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestIcon : MonoBehaviour
{
    public Sprite iconQuest;
    public Sprite iconTakenQuest;
    public Sprite iconCompleteQuest;
    public Sprite iconDialog;
    public Sprite empty;

    public bool activeQuest = false;
    private GameObject player;
    private NPCController npcController;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        npcController = transform.parent.GetComponent<NPCController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    void Update()
    {
        if (npcController.isQuestGiver)
        {
            //has accepted, not completed
            if (npcController.hasAccepted && !npcController.hasCompletedQuest)
            {
                spriteRenderer.sprite = iconTakenQuest;
                activeQuest = false;
            }
            //not accepted, not completed, has no requierd keyitem
            else if (!npcController.hasAccepted && !npcController.hasCompletedQuest && npcController.getRequiredKeyitem().Equals(string.Empty))
            {
                spriteRenderer.sprite = iconQuest;
                activeQuest = true;
            }            
            //has accepted, has completed
            else if (npcController.hasAccepted && npcController.hasCompletedQuest)
            {
                spriteRenderer.sprite = iconCompleteQuest;
                activeQuest = false;
            }
            //not accepted, has completed
            else if (!npcController.hasAccepted && npcController.hasCompletedQuest)
            {
                spriteRenderer.sprite = iconCompleteQuest;
                activeQuest = false;
            }
            else if (!npcController.hasRequiredItem && !npcController.getRequiredKeyitem().Equals(string.Empty))
            {
                spriteRenderer.sprite = empty;
            }
        }
        else
        {
            spriteRenderer.sprite = iconDialog;
        }
    }
}
