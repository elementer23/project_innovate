using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class JSONRESETTER : MonoBehaviour
{
    public JsonHandler jsonHandler;

    public bool reset = false;
    public bool reloadScene = false;

    private void Update()
    {
        if (reset)
        {
            string[] files = { "KeyItems", "npcQuestData", "playerQuest", "PlayerData","Language"};
            string[] contents =
            {
                "{\"items\":[{\"name\":\"Jerrycan\",\"collected\":false},{\"name\":\"Wrench\",\"collected\":false},{\"name\":\"WaterFulled\",\"collected\":false},{\"name\":\"Money\",\"collected\":false},{\"name\":\"MoneyReward\",\"collected\":false},{\"name\":\"Cable\",\"collected\":false},{\"name\":\"CableReward\",\"collected\":false},{\"name\":\"Pinpas\",\"collected\":false},{\"name\":\"Frikandel\",\"collected\":false},{\"name\":\"Heggenschaar\",\"collected\":false},{\"name\":\"Tulip\",\"collected\":false},{\"name\":\"FietsCertivicaat\",\"collected\":false},{\"name\":\"TestPassed\",\"collected\":false},{\"name\":\"Wheel\",\"collected\":false},{\"name\":\"Bike\",\"collected\":false},{\"name\":\"Bezem\",\"collected\":false},{\"name\":\"Gear\",\"collected\":false},{\"name\":\"HedgeTrimmer\",\"collected\":true},{\"name\":\"colledtedTulip-BLUE\",\"collected\":false},{\"name\":\"colledtedTulip-RED\",\"collected\":true},{\"name\":\"colledtedTulip-YELLOW\",\"collected\":false},{\"name\":\"colledtedTulip-PURPLE\",\"collected\":false},{\"name\":\"colledtedTulip-WHITE\",\"collected\":false}]}",
                "{\"statuses\":[{\"npcName\":\"Rob\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false},{\"npcName\":\"Albert\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false},{\"npcName\":\"Lana\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false},{\"npcName\":\"Floor\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false},{\"npcName\":\"Jan\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false},{\"npcName\":\"Piet\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false},{\"npcName\":\"Leroy\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false}]}",
                "{ \"title\": \"\", \"description\": \"\", \"npcName\": \"\", \"requestedItem\": \"\", \"rewardCoins\": 0, \"canRewardItem\": false, \"itemReward\": [] }",
                "{\"playerPosition\":[0,0],\"sceneName\":\"BigCityScene\",\"playerPreset\":[\"#E8D4B2FF\",\"#6A4834FF\",\"#C43C3CFF\",\"#5586B9FF\",\"#6A4834FF\"],\"hairStyle\":0,\"playerSaved\":false,\"playerName\":\"player\"}",
                "{\"language\":\"en\"}"
            };


            for (int i = 0; i < files.Length; i++)
            {
                string path = Application.persistentDataPath + "/Resources/" + files[i] + ".json";

                File.WriteAllText(path, contents[i]);
            }

            Debug.Log("RESET JSON");
            reset = false;
        }


        if (reloadScene)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            reloadScene = false;
        }
    }

    public  void ResetJson()
    {
        this.reset = true;
    }

    public void ReloadScene()
    {
        this.reloadScene = true;
    }
}
