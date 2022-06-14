using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogHandler))]
public class QuestHandler : MonoBehaviour
{
    //The quest imported from the NPC.
    [HideInInspector]
    public Quest quest;

    //Add the quest to this object
    private PlayerQuestHandler player;

    //Store a reference to the NPC, so the npc know if the quest has been accepted.
    [HideInInspector]
    public NPCController npcController;

    //Store a reference to the object which makes the quest appear in the menu.
    private QuestUI questUI;

    void Start()
    {
        //Find the objects and set the variables.
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerQuestHandler>();
        questUI = transform.parent.Find("QuestMenuHolder").Find("QuestMenu").GetComponent<QuestUI>();
    }

    public void acceptBtn()
    {
        Debug.Log("Accept");
        //Tell the NPC the quest has been accepted.
        npcController.hasAccepted = true;

        //Add the quest to the player.
        player.setQuest(quest);

        //Save the quest data to the JSON
        GameObject.Find("QuestSaver").GetComponent<QuestStatusSaver>().writeNpcStatusToJson(quest.npcName, true, false);

        //Add the quest to the quest menu.
        questUI.addQuest();

        //Destroy the quest box UI object.
        Destroy(gameObject);
    }
}
