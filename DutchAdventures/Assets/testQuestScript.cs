using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testQuestScript : MonoBehaviour
{
    public PlayerQuestHandler player;
    public string questTitle;

    private void OnMouseDown()
    {
        if(player.getQuest().title == questTitle)
        {
            Debug.Log("Conpleted quest");
            player.completeQuest();
        } else
        {
            Debug.Log("Not right quest");
        }
    }
}
