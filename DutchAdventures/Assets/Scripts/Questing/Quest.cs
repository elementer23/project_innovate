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
    public string itemReward;

    public static Quest empty = new Quest("", "", "", "", 0, false, "");
    
    //Quest constructor
    public Quest(string title, string desc, string npcName, string requestedItem, int coins, bool canRewardItem, string itemReward)
    {
        this.title = title;
        this.description = desc;
        this.npcName = npcName;
        this.requestedItem = requestedItem;
        this.rewardCoins = coins;
        this.canRewardItem = canRewardItem;
        this.itemReward = itemReward;
    }

    //Function to check if the quest is empty; it has no title or desc.
    public bool isEmpty()
    {
        return this.title == string.Empty || this.description == string.Empty;

        //Only checks for title and description because
        //the npcName will always be filled in.
    }
}