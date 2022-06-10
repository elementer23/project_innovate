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
        quest = jsonHandler.ReadFromJson<Quest>("playerQuest");
    }

    private void Update()
    {
        //Check for completion
        KeyItemsSaver keyItemsSaver = GetComponent<KeyItemsSaver>();
        if (keyItemsSaver.hasItem(quest.requestedItem))
        {
            quest.hasCompleted = true;
        }
    }

    //Call this function from your quest script to complete the quest.
    public void completeQuest()
    {
        addCoins(quest.rewardCoins);

        if (quest.canRewardItem)
        {
            KeyItemsSaver keyItemsSaver = GetComponent<KeyItemsSaver>();
            keyItemsSaver.setItem(quest.requestedItem, false);

            //set all items that are rewarted on true 
            foreach (string item in quest.itemReward)
            { 
                keyItemsSaver.setItem(item, true);
            }
        }
        resetQuest();
    }

    //Sets the currently active quest to a quest.
    public void setQuest(Quest quest)
    {
        Debug.Log("reset quest");
        //Check if the player does not have a quest, add it.
        if (this.quest == null || this.quest.isEmpty() || quest == Quest.empty)
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

    public void resetQuest()
    {
        quest = Quest.empty;
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
