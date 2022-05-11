using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string title;
    public string description;
    public int rewardCoins;
    public bool rewardItem;
    public int itemIndex;

    public Quest(string title, string desc, int coins, bool rewardItem, int itemIndex)
    {
        this.title = title;
        this.description = desc;
        this.rewardCoins = coins;
        this.rewardItem = rewardItem;   
        this.itemIndex = itemIndex;
    }
}
