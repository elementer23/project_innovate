using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextQuestHandler : MonoBehaviour
{
    public GameObject prevNPC;
    public GameObject npcToDisable;
    public GameObject nextNPC;

    /// <summary>
    /// switch npc after completion quest
    /// </summary>
    void Update()
    {
        if (prevNPC.GetComponent<NPCController>().hasCompletedQuest)
        {
            nextNPC.SetActive(true);
            npcToDisable.SetActive(false);
        }
    }
}
