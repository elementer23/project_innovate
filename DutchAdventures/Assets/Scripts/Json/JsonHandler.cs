using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonHandler : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);

        string[] files = { "KeyItems", "npcQuestData", "playerQuest", "PlayerData" };
        string[] contents =
        {
            "{\"items\":[{\"name\":\"Jerrycan\",\"collected\":false},{\"name\":\"Wrench\",\"collected\":false},{\"name\":\"WaterFulled\",\"collected\":false},{\"name\":\"Money\",\"collected\":false},{\"name\":\"Pinpas\",\"collected\":false},{\"name\":\"Frikandel\",\"collected\":false},{\"name\":\"Heggenschaar\",\"collected\":false},{\"name\":\"Tulip\",\"collected\":false},{\"name\":\"FietsCertivicaat\",\"collected\":false},{\"name\":\"Bike\",\"collected\":false},{\"name\":\"Bezem\",\"collected\":false}]}",
            "{\"statuses\":[{\"npcName\":\"Marco\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false},{\"npcName\":\"Pieter\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false},{\"npcName\":\"Bas\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false},{\"npcName\":\"Jan\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false}]}",
            "{ \"title\": \"\", \"description\": \"\", \"npcName\": \"\", \"requestedItem\": \"\", \"rewardCoins\": 0, \"canRewardItem\": false, \"itemReward\": \"\" }",
            "{\"saveData\":[{\"posX\": \"\", \"posY\": \"\", \"posZ\": \"\", \"sceneName\": \"\"}]}"
        };

        if (!Directory.Exists(Application.persistentDataPath + "/Resources/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Resources/");
        }

        for (int i = 0; i < files.Length; i++)
        {
            string path = Application.persistentDataPath + "/Resources/" + files[i] + ".json";

            if (!File.Exists(path))
            {
                Debug.Log("Created file");
                FileStream fsr = File.Create(path);
                fsr.Close();
                File.WriteAllText(path, contents[i]);
            }
        }
    }

    public void WriteToJson<T>(T dataToWrite, string fileName)
    {
        Debug.Log("Write to JSON: " + dataToWrite);
        File.WriteAllText(Application.persistentDataPath + "/Resources/" + fileName + ".json", JsonUtility.ToJson(dataToWrite));
    }

    public T ReadFromJson<T>(string fileName)
    {
        string path = Application.persistentDataPath + "/Resources/" + fileName + ".json";
        string jsonString = File.ReadAllText(path);
        Debug.Log(jsonString);

        return JsonUtility.FromJson<T>(jsonString);
    }
}
