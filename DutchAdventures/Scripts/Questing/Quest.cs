using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string title;
    public string description;
    public string npcName;
    public string completionDialog;
    public int rewardCoins;
    public bool rewardItem;
    public int itemIndex;

    //Quest constructor
    public Quest(string title, string desc, string npcName, string completionDialog, int coins, bool rewardItem, int itemIndex)
    {
        this.title = title;
        this.description = desc;
        this.npcName = npcName;
        this.completionDialog = completionDialog;
        this.rewardCoins = coins;
        this.rewardItem = rewardItem;
        this.itemIndex = itemIndex;
    }

    //Function to check if the quest is empty; it has no title or desc.
    public bool isEmpty()
    {
        return this.title == string.Empty || this.description == string.Empty;

        //Only checks for title and description because
        //the npcName will always be filled in.
    }
}
