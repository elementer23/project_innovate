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
            GameObject npc = npcs[i];
            npcStatuses.statuses[i] = new NpcQuestStatus(npc.name, npc.GetComponent<NPCController>().hasAccepted);

        }
        Debug.Log(JsonUtility.ToJson(npcStatuses));
        writeToJson();
    }

    public NpcQuestStatuses readNpcStatus()
    {
        return JsonUtility.FromJson<NpcQuestStatuses>(jsonFile.text);
    }

    void writeToJson()
    {
        File.WriteAllText(Application.dataPath + "/Resources/npcQuestData.json", JsonUtility.ToJson(npcStatuses));
    }
}

[System.Serializable]
public class NpcQuestStatus
{
    public string npcName;
    public bool hasTakenQuest;

    public NpcQuestStatus(string name, bool taken)
    {
        this.npcName = name;
        this.hasTakenQuest = taken;
    }
}

[System.Serializable]
public class NpcQuestStatuses
{
    public NpcQuestStatus[] statuses;
}