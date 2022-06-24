using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingHandler : MonoBehaviour
{
    [SerializeField]
    private PlayerQuestHandler player;
    [SerializeField]
    private string questName;

    [SerializeField]
    private GameObject world;
    [SerializeField]
    private GameObject minigame;

    [SerializeField]
    private float minDist = 4;

    private void Update()
    {
        if (minigame.activeSelf)
        {
            minigame.SetActive(false);
        }

        if (player.getQuest().title == questName && !player.getQuest().hasCompleted)
        {
            bool isClose = Vector2.Distance(transform.position, player.transform.position) < minDist;
            transform.GetChild(0).gameObject.SetActive(isClose);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (player.getQuest().title == questName)
        {
            minigame.SetActive(true);
            world.SetActive(false);
        }
    }
}
