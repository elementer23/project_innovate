using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestIcon : MonoBehaviour
{
    public Sprite iconQuest;
    public Sprite iconTakenQuest;
    public Sprite iconCompleteQuest;
    public Sprite iconDialog;

    private NPCController npcController;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        npcController = transform.parent.GetComponent<NPCController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (npcController.isQuestGiver)
        {
            //has accepted, not completed
            if (npcController.hasAccepted && !npcController.hasCompletedQuest)
            {
                spriteRenderer.sprite = iconTakenQuest;
            }
            //not accepted, not completed
            else if (!npcController.hasAccepted && !npcController.hasCompletedQuest)
            {
                spriteRenderer.sprite = iconQuest;
            }
            //has accepted, has completed
            else if (npcController.hasAccepted && npcController.hasCompletedQuest)
            {
                spriteRenderer.sprite = iconCompleteQuest;
            }
            //not accepted, has completed
            else if (!npcController.hasAccepted && npcController.hasCompletedQuest)
            {
                spriteRenderer.sprite = iconCompleteQuest;
            }
        }
        else
        {
            spriteRenderer.sprite = iconDialog;
        }
    }
}
