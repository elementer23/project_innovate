using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private Transform player;
    private Transform canvas;
    private KeyItemsSaver keyItemsSaver;

    private QuestStatusSaver questStatusSaver;

    [SerializeField]
    private GameObject dialogPrefab;
    [SerializeField]
    private GameObject questPrefab;
    [SerializeField]
    private GameObject competionDialogPrefab;

    [SerializeField]
    private GameObject questIconPrefab;

    [SerializeField]
    private string requiredItem;
    private bool hasRequiredItem;
    private bool canTakeQuest;

    [Header("Dialog")]
    public string npcName;
    public string startDialog;
    public string notCompletedDialog;
    public string completionDialog;
    public string postCompletionDialog;

    [Header("Quest")]
    public Quest quest;

    [HideInInspector]
    public bool hasAccepted = false;
    [HideInInspector]
    public bool hasCompletedQuest = false;
    [HideInInspector]
    public bool isQuestGiver = false;

    void Start()
    {
        //Set the quest status saver.
        questStatusSaver = GameObject.Find("QuestSaver").GetComponent<QuestStatusSaver>();

        //Set some variables to the corresponding objects.
        gameObject.name = npcName;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;
        keyItemsSaver = player.GetComponent<KeyItemsSaver>();

        isQuestGiver = !quest.isEmpty();

        //Get the status from the npc quest saver and update the local values
        bool[] status = questStatusSaver.getNpcStatus(npcName);
        hasAccepted = status[0];
        hasCompletedQuest = status[1];

        //Spawn a quest marker/dialog icon above the npc
        if (hasRequiredItem)
        {
            Instantiate(questIconPrefab, transform);
        }

        if (isQuestGiver)
        {
            quest.npcName = npcName;
        }
    }

    private void Update()
    {
        hasRequiredItem = keyItemsSaver.hasItem(requiredItem);

        if (canTakeQuest && !transform.Find("QuestMarker(Clone)"))
        {
            Instantiate(questIconPrefab, transform);
        }

        if (requiredItem == string.Empty)
        {
            canTakeQuest = true;
        }
        else
        {
            if (hasRequiredItem)
            {
                canTakeQuest = true;
            }
            else
            {
                canTakeQuest = false;
            }
        }
    }

    //When the player presses on the NPC,
    private void OnMouseDown()
    {
        if (canTakeQuest)
        {
            //Check if the player is close enough to the NPC,
            float dist = Vector2.Distance(player.position, transform.position);
            if (dist < 2)
            {
                //Get the status from the npc quest saver and update the local values
                bool[] status = questStatusSaver.getNpcStatus(npcName);
                hasAccepted = status[0];
                hasCompletedQuest = status[1];

                if (!startDialog.Equals(string.Empty))
                {
                    //Check if the NPC has a quest assigned to it, otherwise display dialog instead.
                    if (!quest.isEmpty())
                    {
                        if (!hasAccepted)
                        {
                            //Give player quest
                            addDialog(questPrefab, "Questbox(Clone)", startDialog, true);
                        }
                        else
                        {
                            if (!hasCompletedQuest)
                            {
                                if (player.GetComponent<KeyItemsSaver>().hasItem(quest.requestedItem))
                                {
                                    //Complete the quest
                                    addDialog(competionDialogPrefab, "CompletionDialog(Clone)", completionDialog, false);
                                }
                                else
                                {
                                    //Quest not finished yet
                                    addDialog(dialogPrefab, "Dialogbox(Clone)", notCompletedDialog, false);
                                }
                            }
                            else
                            {
                                //Quest is already finished finished
                                addDialog(dialogPrefab, "Dialogbox(Clone)", postCompletionDialog, false);
                            }
                        }
                    }
                    //Npc does not give quests and just talks.
                    else
                    {
                        string dialog = !hasCompletedQuest ? startDialog : completionDialog;

                        addDialog(dialogPrefab, "Dialogbox(Clone)", dialog, false);
                    }
                }
            }
        }
    }

    private void addDialog(GameObject prefab, string objName, string dialog, bool isQuest)
    {
        if (!canvas.Find(objName))
        {
            GameObject obj = Instantiate(prefab, canvas);
            DialogHandler dhandler = obj.GetComponent<DialogHandler>();

            dhandler.dialog = dialog;
            dhandler.npcName = npcName;

            if (isQuest)
            {
                QuestHandler qhandler = obj.GetComponent<QuestHandler>();

                qhandler.quest = quest;
                qhandler.npcController = this;
            }
        }
    }

    //void updateValues()
    //{
    //    if (isQuestGiver)
    //    {
    //        NpcQuestStatuses npcStatuses = GameObject.Find("QuestSaver").GetComponent<QuestStatusSaver>().readNpcStatus();
    //        foreach (NpcQuestStatus npcStatus in npcStatuses.statuses)
    //        {
    //            if (npcStatus.npcName == npcName)
    //            {
    //                hasAccepted = npcStatus.hasTakenQuest;
    //                hasCompletedQuest = npcStatus.hasCompletedQuest;
    //            }
    //        }
    //    }
    //}


    //Function to reset the NPC after completion or abanoning of the quest.
    public void resetNpc()
    {
        if (!quest.isEmpty())
        {
            Instantiate(questIconPrefab, transform);
            hasAccepted = false;
        }
    }
}
