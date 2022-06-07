using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonHandler : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (!Directory.Exists(Application.dataPath + "/Resources/KeyItems.json"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Resources/KeyItems.json");
            File.WriteAllText(Application.dataPath + "/Resources/KeyItems.json", "{\"items\":[{\"name\":\"Jerrycan\",\"collected\":false},{\"name\":\"Wrench\",\"collected\":false},{\"name\":\"WaterFulled\",\"collected\":false},{\"name\":\"Money\",\"collected\":false},{\"name\":\"Pinpas\",\"collected\":false},{\"name\":\"Frikandel\",\"collected\":false},{\"name\":\"Heggenschaar\",\"collected\":false},{\"name\":\"Tulip\",\"collected\":false},{\"name\":\"FietsCertivicaat\",\"collected\":false},{\"name\":\"Bike\",\"collected\":false},{\"name\":\"Bezem\",\"collected\":false}]}");
        }
        if (!Directory.Exists(Application.dataPath + "/Resources/npcQuestData.json"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Resources/npcQuestData.json");
            File.WriteAllText(Application.dataPath + "/Resources/NpcQuestData.json", "{\"statuses\":[{\"npcName\":\"Marco\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false},{\"npcName\":\"Pieter\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false},{\"npcName\":\"Bas\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false},{\"npcName\":\"Jan\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false}]}");
        }
        if (!Directory.Exists(Application.dataPath + "/Resources/playerQuest.json"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Resources/PlayerQuest.json");
            File.WriteAllText(Application.dataPath + "/Resources/PlayerQuest.json", "{ \"title\": \"\", \"description\": \"\", \"npcName\": \"\", \"requestedItem\": \"\", \"rewardCoins\": 0, \"canRewardItem\": false, \"itemReward\": \"\" }");
        }
        if (!Directory.Exists(Application.dataPath + "/Resources/PlayerData.json"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Resources/PlayerData.json");
            File.WriteAllText(Application.dataPath + "/Resources/PlayerData.json", "{ \"position\": \"\", \"currentScene\": \"\" }");
        }
    }

    public void WriteToJson<T>(T dataToWrite, string fileName)
    {
        Debug.Log("Write to JSON: " + dataToWrite);
        File.WriteAllText(Application.persistentDataPath + "/Resources/" + fileName + ".json", JsonUtility.ToJson(dataToWrite));
    }

    public T ReadFromJson<T>(string fileName)
    {
        TextAsset jsonFile = Resources.Load<TextAsset>(fileName);
        Debug.Log("Read from JSON: " + jsonFile.name);
        return JsonUtility.FromJson<T>(jsonFile.text);
    }
}
