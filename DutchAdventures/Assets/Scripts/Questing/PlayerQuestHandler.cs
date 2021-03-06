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

    private Animator completeTaskAnim;
    private bool hasPlayed = false;
    private void Start()
    {
        jsonHandler = FindObjectOfType<JsonHandler>();

        if (GameObject.Find("TaskComplete"))
        {
            completeTaskAnim = GameObject.Find("TaskComplete").GetComponent<Animator>();
        }

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
            if (hasPlayed == false)
            {
                hasPlayed = true;
                completeTaskAnim.SetTrigger("Play");
            }
        }
    }

    /// <summary>
    /// Call this function from your quest script to complete the quest.
    /// </summary>
    public void completeQuest()
    {
        addCoins(quest.rewardCoins);

        if (quest.canRewardItem)
        {
            Debug.Log("Complete");
            KeyItemsSaver keyItemsSaver = GetComponent<KeyItemsSaver>();
            keyItemsSaver.setItem(quest.requestedItem, false);

            //set all items that are rewarted on true 
            foreach (string item in quest.itemReward)
            {
                Debug.Log("key item: " + item + " :True");
                keyItemsSaver.setItem(item, true);
            }
        }
        quest = Quest.empty;
    }

    /// <summary>
    /// Sets the currently active quest to a quest.
    /// </summary>
    /// <param name="quest">Quest object</param>
    public void setQuest(Quest quest)
    {
        //Check if the player does not have a quest, add it.
        if (this.quest == null || this.quest.isEmpty() || quest == Quest.empty)
        {
            this.quest = quest;
            jsonHandler.WriteToJson(quest, "PlayerQuest");
        }
    }

    /// <summary>
    /// get quest from player
    /// </summary>
    /// <returns>Returns quest object</returns>
    public Quest getQuest()
    {
        return quest;
    }

    /// <summary>
    /// Reset quest keyitems of player
    /// </summary>
    public void resetQuest()
    {
        GetComponent<KeyItemsSaver>().setItem(quest.requestedItem, false);
        quest = Quest.empty;
    }

    /////////////////
    // Coin system //
    /////////////////

    /// <summary>
    /// Add coins to wallet
    /// </summary>
    /// <param name="amt">amount of coins</param>
    public void addCoins(int amt)
    {
        coins += amt;
    }

    /// <summary>
    /// Delete coins from wallet
    /// </summary>
    /// <param name="amt">Amount of coins</param>
    public void subtractCoint(int amt)
    {
        if (coins - amt >= 0)
        {
            coins -= amt;
        }
    }
}
