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
            string[] files = { "KeyItems", "npcQuestData", "playerQuest", "PlayerData" };
            string[] contents =
            {
                "{\"items\":[{\"name\":\"Jerrycan\",\"collected\":false},{\"name\":\"Wrench\",\"collected\":false},{\"name\":\"WaterFulled\",\"collected\":false},{\"name\":\"Money\",\"collected\":false},{\"name\":\"MoneyReward\",\"collected\":false},{\"name\":\"Cable\",\"collected\":false},{\"name\":\"CableReward\",\"collected\":false},{\"name\":\"Frikandel\",\"collected\":false},{\"name\":\"Heggenschaar\",\"collected\":false},{\"name\":\"Tulip\",\"collected\":false},{\"name\":\"FietsCertivicaat\",\"collected\":false},{\"name\":\"Bike\",\"collected\":false},{\"name\":\"Bezem\",\"collected\":false}]}",
                "{\"statuses\":[{\"npcName\":\"Piet\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false},{\"npcName\":\"Jan\",\"hasTakenQuest\":false,\"hasCompletedQuest\":false}]}",
                "{\"title\":\"\",\"description\":\"\",\"npcName\":\"\",\"requestedItem\":\"\",\"rewardCoins\":0,\"canRewardItem\":true,\"itemReward\":[]}",
                "{\"saveData\":[{\"posX\":0, \"posY\":0, \"posZ\":0, \"sceneName\": \"\"}]}"
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

            Debug.Log("RESET JSON");
            reset = false;
        }
    }
}
