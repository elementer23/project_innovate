using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONRESETTER : MonoBehaviour
{
    public JsonHandler jsonHandler;

    public bool reset;

    private void Update()
    {
        if (reset)
        {
            File.WriteAllText(Application.dataPath + "/Resources/KeyItems.json", "{\"items\":[{\"name\":\"Jerrycan\",\"collected\":false},{\"name\":\"Wrench\",\"collected\":false},{\"name\":\"WaterFulled\",\"collected\":false},{\"name\":\"Money\",\"collected\":false},{\"name\":\"Pinpas\",\"collected\":false},{\"name\":\"Frikandel\",\"collected\":false},{\"name\":\"Heggenschaar\",\"collected\":false},{\"name\":\"Tulip\",\"collected\":false},{\"name\":\"FietsCertivicaat\",\"collected\":false},{\"name\":\"Bike\",\"collected\":false},{\"name\":\"Bezem\",\"collected\":false},{\"name\":\"Gear\",\"collected\":false}]}");
            File.WriteAllText(Application.dataPath + "/Resources/NpcQuestData.json", "{\"statuses\":[{\"npcName\":\"Rob\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false},{\"npcName\":\"Albert\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false},{\"npcName\":\"Floor\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false},{\"npcName\":\"Jan\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false}]}");
            File.WriteAllText(Application.dataPath + "/Resources/PlayerQuest.json", "{ \"title\": \"\", \"description\": \"\", \"npcName\": \"\", \"requestedItem\": \"\", \"rewardCoins\": 0, \"canRewardItem\": false, \"itemReward\": [] }");
            Debug.Log("RESET JSON");
            reset = false;
        }
    }
}
