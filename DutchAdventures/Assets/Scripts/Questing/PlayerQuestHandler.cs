using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuestHandler : MonoBehaviour
{
    //The list of quests the player has.
    [SerializeField]
    private List<Quest> quests = new List<Quest>();

    public void addQuest(Quest quest)
    {
        //If the quest is not already in the list,
        if (!quests.Contains(quest))
        {
            //If there are less then 5 quests,
            if (quests.Count < 5)
            {
                //Add the quest.
                Debug.Log("Add quest to player");
                quests.Add(quest);
            }
            else
            {
                Debug.LogWarning("Quest log is full");
            }
        }
        else
        {
            Debug.LogWarning("Quest already exists");
        }
    }

    public void removeQuest(Quest quest)
    {
        //If the list contains the quest, remove it.
        if (quests.Contains(quest))
        {
            quests.Remove(quest);
        }
    }

    public List<Quest> getQuests()
    {
        return quests;
    }

    public int getQuestLength()
    {
        return quests.Count;
    }

}
