using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class QuestStatusSaver : MonoBehaviour
{
    public NpcQuestStatuses npcStatuses = new NpcQuestStatuses();
    public TextAsset jsonFile;

    public void updateNpcStatus()
    {
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");
        npcStatuses = new NpcQuestStatuses();
        npcStatuses.statuses = new NpcQuestStatus[npcs.Length];

        for (int i = 0; i < npcs.Length; i++)
        {
            NPCController npc = npcs[i].GetComponent<NPCController>();
            npcStatuses.statuses[i] = new NpcQuestStatus(npc.name, npc.hasAccepted, npc.hasCompletedQuest);

        }

        writeToJson();
    }

    public NpcQuestStatuses readNpcStatus()
    {
        UnityEditor.AssetDatabase.Refresh();
        return JsonUtility.FromJson<NpcQuestStatuses>(jsonFile.text);
    }

    void writeToJson()
    {
        Debug.Log("Saved npc quest status");
        File.WriteAllText(Application.dataPath + "/Resources/npcQuestData.json", JsonUtility.ToJson(npcStatuses));
    }
}

[System.Serializable]
public class NpcQuestStatus
{
    public string npcName;
    public bool hasTakenQuest;
    public bool hasCompletedQuest;

    public NpcQuestStatus(string npcName, bool hasTakenQuest, bool hasCompletedQuest)
    {
        this.npcName = npcName;
        this.hasTakenQuest = hasTakenQuest;
        this.hasCompletedQuest = hasCompletedQuest;
    }
}

[System.Serializable]
public class NpcQuestStatuses
{
    public NpcQuestStatus[] statuses;
}