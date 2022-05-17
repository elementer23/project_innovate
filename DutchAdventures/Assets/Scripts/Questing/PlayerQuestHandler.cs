using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuestHandler : MonoBehaviour
{
    [SerializeField]
    private List<Quest> quests = new List<Quest>();

    public void addQuest(Quest quest)
    {
        if (!quests.Contains(quest))
        {
            if (quests.Count < 5)
            {
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
