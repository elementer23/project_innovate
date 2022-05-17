using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogHandler))]
public class QuestHandler : MonoBehaviour
{
    [HideInInspector]
    public Quest quest; //The quest imported from the NPC.
    private DialogHandler handler; //The dialog handler connected to this GO.
    private PlayerQuestHandler player; //The player, to which the quest is added
    private QuestUI questUI;
    [HideInInspector]
    public NPCController npcController;

    [SerializeField]
    private CanvasGroup btns;

    void Start()
    {
        //Find the objects and set the variables.
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerQuestHandler>();
        handler = GetComponent<DialogHandler>();
        questUI = transform.parent.Find("QuestMenu").GetComponent<QuestUI>();
        //Make the buttons invisible to start.
        btns.alpha = 0;
        btns.interactable = false;
    }

    void Update()
    {
        //if the NPC is done talking, make the buttons appear.
        btns.alpha = handler.isFinished ? 1 : 0;
        btns.interactable = handler.isFinished;
    }

    public void acceptBtn()
    {
        //Destroy the exclemation mark above the quest giver.
        Destroy(npcController.transform.Find("QuestMarker(Clone)").gameObject);
        //Make it so the quest cannot be accepted again.
        npcController.hadAccepted = true;
        //Add the quest to the player.
        player.addQuest(quest);
        //Add the quest to the UI.
        questUI.addQuest(quest);
        //Destroy the UI object.
        Destroy(gameObject);
    }
}
