using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : MonoBehaviour
{
    public JsonHandler jsonHandler;
    public string[] canStartQuest;
    [SerializeField]
    private GameObject npc;
    

    private void Start()
    {
        NpcQuestStatuses questStatus = jsonHandler.ReadFromJson<NpcQuestStatuses>("npcQuestData");
        foreach (NpcQuestStatus obj in questStatus.statuses)
        {
            foreach (string name in canStartQuest)
            {
                if (obj.npcName == name)
                {
                    Debug.Log("Oude man");
                    if (obj.hasCompletedQuest == true)
                    {
                        npc.SetActive(true);
                    }
                    else
                    {
                        npc.SetActive(false);
                    }
                }
            }
        }
    }
}
