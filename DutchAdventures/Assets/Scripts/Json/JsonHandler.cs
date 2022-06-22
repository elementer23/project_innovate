using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonHandler : MonoBehaviour
{
    private void Awake()
    {
        string[] files = { "KeyItems", "npcQuestData", "playerQuest", "PlayerData","Language"};
        string[] contents =
        {
            "{\"items\":[{\"name\":\"Jerrycan\",\"collected\":false},{\"name\":\"Wrench\",\"collected\":false},{\"name\":\"WaterFulled\",\"collected\":false},{\"name\":\"Money\",\"collected\":false},{\"name\":\"MoneyReward\",\"collected\":true},{\"name\":\"Cable\",\"collected\":false},{\"name\":\"CableReward\",\"collected\":true},{\"name\":\"Frikandel\",\"collected\":false},{\"name\":\"FrikandelReward\",\"collected\":false},{\"name\":\"Heggenschaar\",\"collected\":false},{\"name\":\"Tulip\",\"collected\":false},{\"name\":\"FietsCertivicaat\",\"collected\":false},{\"name\":\"TestPassed\",\"collected\":false},{\"name\":\"Wheel\",\"collected\":false},{\"name\":\"Bike\",\"collected\":false},{\"name\":\"Bezem\",\"collected\":false},{\"name\":\"Gear\",\"collected\":false}]}",
            "{\"statuses\":[{\"npcName\":\"Rob\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false},{\"npcName\":\"Albert\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false},{\"npcName\":\"Lana\",\"hasTakenQuest\":true,\"hasCompletedQuest\":false},{\"npcName\":\"Floor\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false},{\"npcName\":\"Jan\",\"hasTakenQuest\":true,\"hasCompletedQuest\":true},{\"npcName\":\"Piet\",\"hasTakenQuest\":true,\"hasCompletedQuest\":true},{\"npcName\":\"Piet2\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false},{\"npcName\":\"Piet3\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false},{\"npcName\":\"Leroy\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false}]}",
            "{ \"title\": \"\", \"description\": \"\", \"npcName\": \"\", \"requestedItem\": \"\", \"rewardCoins\": 0, \"canRewardItem\": false, \"itemReward\": [] }",
            "{\"playerPosition\":[0,0],\"sceneName\":\"BigCityScene\",\"playerPreset\":[\"#E8D4B2FF\",\"#6A4834FF\",\"#C43C3CFF\",\"#5586B9FF\",\"#6A4834FF\"],\"hairStyle\":0,\"playerSaved\":false,\"playerName\":\"player\"}",
            "{\"language\":\"en\"}"
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
        //Debug.Log("Write to JSON: \n" + JsonUtility.ToJson(dataToWrite));
        File.WriteAllText(Application.persistentDataPath + "/Resources/" + fileName + ".json", JsonUtility.ToJson(dataToWrite));
    }

    public T ReadFromJson<T>(string fileName)
    {
        string path = Application.persistentDataPath + "/Resources/" + fileName + ".json";
        string jsonString = File.ReadAllText(path);
        //Debug.Log("Read from JSON: \n" + jsonString);

        return JsonUtility.FromJson<T>(jsonString);
    }
}
