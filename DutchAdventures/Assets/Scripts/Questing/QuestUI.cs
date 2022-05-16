using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestUI : MonoBehaviour
{
    [HideInInspector]
    public GameObject questPrefab;
    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void addQuest(Quest quest)
    {
        Debug.Log("Add quest " + quest + " to quest UI");
        Transform questObj = Instantiate(questPrefab, transform).transform;
        questObj.Find("Title").GetComponent<TextMeshProUGUI>().text = quest.title;
        questObj.Find("Description").GetComponent<TextMeshProUGUI>().text = quest.description;
        questObj.Find("NPC").GetComponent<TextMeshProUGUI>().text = quest.npcName;
        questObj.gameObject.name = quest.title;
    }

    public void removeQuest(Quest quest)
    {
        Destroy(transform.Find(quest.title).gameObject);
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
