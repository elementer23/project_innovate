using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextQuestHandler : MonoBehaviour
{
    public GameObject previousNPC;
    public GameObject nextNPC;

    void Start()
    {
        nextNPC.SetActive(false);
    }

    void Update()
    {
        if (previousNPC.GetComponent<NPCController>().hasCompletedQuest)
        {
            nextNPC.SetActive(true);
            previousNPC.SetActive(false);
        }
    }
}
