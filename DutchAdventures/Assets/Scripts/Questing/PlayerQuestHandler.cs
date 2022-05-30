using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerQuestHandler : MonoBehaviour
{
    public int coins;
    public TextAsset jsonFile;

    [Header("Quest")]
    [SerializeField]
    private Quest quest;

    private void Start()
    {
        quest = loadQuest();
    }

    //Sets the currently active quest to a quest.
    public void setQuest(Quest quest)
    {
        //Check if the player does not have a quest, add it.
        if (this.quest == null || this.quest.isEmpty())
        {
            this.quest = quest;
            saveQuest();
        }
        else
        {
            Debug.LogWarning("Already has quest");
        }
    }

    public Quest getQuest()
    {
        return quest;
    }

    //Removes the quest the player currently has.
    public void removeQuest()
    {    
        //Set the quest to a empty quest.
        Debug.Log("Remove quest: " + quest.title);
        quest = new Quest("", "", "", "", 0, false, "");
    }

    //Call this function from your quest script to complete the quest.
    public void completeQuest()
    {
        addCoins(quest.rewardCoins);

        if (quest.canRewardItem)
        {
            GetComponent<KeyItemsHandler>().setItem(quest.requestedItem, false);
            GetComponent<KeyItemsHandler>().setItem(quest.itemReward, true);
        }
        //GameObject.Find(quest.npcName).GetComponent<NPCController>().clearNpc();
        removeQuest();
        saveQuest();
    }

    void saveQuest()
    {
        Debug.Log(JsonUtility.ToJson(quest));
        File.WriteAllText(Application.dataPath + "/Resources/playerQuest.json", JsonUtility.ToJson(quest));
        Debug.Log("Saved quest");
    }

    Quest loadQuest()
    {
        return JsonUtility.FromJson<Quest>(jsonFile.text);
    }

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
