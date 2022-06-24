using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string title;
    public string description;
    public string npcName;
    public string requestedItem;
    public int rewardCoins;
    public bool canRewardItem;
    public string[] itemReward;
    public bool hasCompleted;
    
    /// <summary>
    /// create Emty quest
    /// </summary>
    public static Quest empty = new Quest("", "", "", "", 0, false, new string[0]);

    /// <summary>
    /// Quest constructor
    /// </summary>
    /// <param name="title">Title of quest</param>
    /// <param name="desc">Descriotion of quest</param>
    /// <param name="npcName">Npc name of quest</param>
    /// <param name="requestedItem">RequestedItem of quest</param>
    /// <param name="coins">Amount of coins added on completion of quest</param>
    /// <param name="canRewardItem">check if npc can reward items</param>
    /// <param name="itemsReward">Item rewards after completion of quest</param>
    public Quest(string title, string desc, string npcName, string requestedItem, int coins, bool canRewardItem, string[] itemsReward)
    {
        this.title = title;
        this.description = desc;
        this.npcName = npcName;
        this.requestedItem = requestedItem;
        this.rewardCoins = coins;
        this.canRewardItem = canRewardItem;
        this.itemReward = itemsReward;
    }

    /// <summary>
    /// Function to check if the quest is empty; it has no title or desc.
    /// </summary>
    /// <returns>True or false if quest title of description is empty</returns>
    public bool isEmpty()
    {
        return this.title == string.Empty || this.description == string.Empty;

        //Only checks for title and description because
        //the npcName will always be filled in.
    }
}