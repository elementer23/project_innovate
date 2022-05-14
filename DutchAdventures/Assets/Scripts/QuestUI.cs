using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestUI : MonoBehaviour
{
    [HideInInspector]
    public GameObject questPrefab;
    private CanvasGroup canvasGroup;
    private PlayerQuestHandler player;
    private Quest[] quests;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerQuestHandler>();

        quests = player.quests;

        foreach (Quest quest in quests)
        {
            Transform questObj = Instantiate(questPrefab, transform).transform;
            questObj.Find("Title").GetComponent<TextMeshProUGUI>().text = quest.title;
            questObj.Find("Description").GetComponent<TextMeshProUGUI>().text = quest.description;
        }
    }

    void Update()
    {
        if(quests != player.quests)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }

            quests = player.quests;

            foreach (Quest quest in quests)
            {
                Transform questObj = Instantiate(questPrefab, transform).transform;
                questObj.Find("Title").GetComponent<TextMeshProUGUI>().text = quest.title;
                questObj.Find("Description").GetComponent<TextMeshProUGUI>().text = quest.description;
            }
        }
    }

    public void questButton()
    {
        if (canvasGroup.alpha == 1)
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
        else
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
    }
}
