using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string title;
    public string description;
    public string npcName;
    public int rewardCoins;
    public bool rewardItem;
    public int itemIndex;

    public Quest(string title, string desc, string npcName, int coins, bool rewardItem, int itemIndex)
    {
        this.title = title;
        this.description = desc;
        this.npcName = npcName;
        this.rewardCoins = coins;
        this.rewardItem = rewardItem;
        this.itemIndex = itemIndex;
    }
}
