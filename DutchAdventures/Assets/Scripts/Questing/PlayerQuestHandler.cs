using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuestHandler : MonoBehaviour
{
    public int coins;

    [Header("Quest")]
    [SerializeField]
    private Quest quest;

    //Sets the currently active quest to a quest.
    public void setQuest(Quest quest)
    {
        //Check if the player does not have a quest, add it.
        if (this.quest.isEmpty())
        {
            this.quest = quest;
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

        if (quest.rewardItem)
        {
            GetComponent<KeyItemsHandler>().setItem(quest.item, true);
        }
        GameObject.Find(quest.npcName).GetComponent<NPCController>().clearNpc();
        removeQuest();
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
