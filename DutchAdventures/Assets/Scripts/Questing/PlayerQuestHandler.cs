using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerQuestHandler : MonoBehaviour
{
    public int coins;

    [Header("Save Data")]
    [SerializeField]
    private TextAsset jsonFile;
    private JsonHandler jsonHandler;

    [Header("Quest")]
    [SerializeField]
    private Quest quest;

    private void Start()
    {
        jsonHandler = FindObjectOfType<JsonHandler>();

        //Load in saved quest
        quest = jsonHandler.ReadFromJson<Quest>(jsonFile);
    }

    //Call this function from your quest script to complete the quest.
    public void completeQuest()
    {
        addCoins(quest.rewardCoins);

        if (quest.canRewardItem)
        {
            KeyItemsSaver keyItemsSaver = GetComponent<KeyItemsSaver>();
            keyItemsSaver.setItem(quest.requestedItem, false);
            keyItemsSaver.setItem(quest.itemReward, true);
        }

        setQuest(Quest.empty);
    }

    //Sets the currently active quest to a quest.
    public void setQuest(Quest quest)
    {
        //Check if the player does not have a quest, add it.
        if (this.quest == null || this.quest.isEmpty())
        {
            Debug.Log("Completed quest");
            this.quest = quest;
            jsonHandler.WriteToJson(quest, "PlayerQuest");
        }
    }

    public Quest getQuest()
    {
        return quest;
    }

    //void saveQuest()
    //{
    //    File.WriteAllText(Application.dataPath + "/Resources/playerQuest.json", JsonUtility.ToJson(quest));
    //}

    //Quest loadQuest()
    //{
    //    UnityEditor.AssetDatabase.Refresh();
    //    var jsonFile = Resources.Load<TextAsset>("playerQuest");
    //    Quest q = JsonUtility.FromJson<Quest>(jsonFile.text);

    //    return q;
    //}

    /////////////////
    // Coin system //
    /////////////////

    public void addCoins(int amt)
    {
        coins += amt;
    }

    public void subtractCoint(int amt)
    {
        if (coins - amt >= 0)
        {
            coins -= amt;
        }
    }
}
