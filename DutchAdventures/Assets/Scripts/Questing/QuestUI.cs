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
        //Create a new questUI element.
        Transform questObj = Instantiate(questPrefab, transform).transform;
        //Update the text to the quest values.
        questObj.Find("Title").GetComponent<TextMeshProUGUI>().text = quest.title;
        questObj.Find("Description").GetComponent<TextMeshProUGUI>().text = quest.description;
        questObj.Find("NPC").GetComponent<TextMeshProUGUI>().text = quest.npcName;
        //Set the object's name to the title so it can later be found back.
        questObj.gameObject.name = quest.title;
    }

    public void removeQuest(Quest quest)
    {
        //Find the quest object with a name that matches the quest title.
        Destroy(transform.Find(quest.title).gameObject);
    }

    public void questButton()
    {
        //Toggle the visibility of the object.
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
