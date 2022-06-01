using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private Transform player;
    private Transform canvas;

    [SerializeField]
    private GameObject dialogIcon;

    private QuestStatusSaver questStatusSaver;

    [HideInInspector]
    public GameObject dialogPrefab;
    [HideInInspector]
    public GameObject questPrefab;
    [HideInInspector]
    public GameObject competionDialogPrefab;
    [HideInInspector]
    public GameObject questIconPrefab;
    [HideInInspector]
    public GameObject dialogIconPrefab;

    [Header("Dialog")]
    public string npcName;
    public string startDialog;
    public string completionDialog;

    [Header("Quest")]
    public Quest quest;

    //[HideInInspector]
    public bool hasAccepted = false;
    //[HideInInspector]
    public bool hasCompletedQuest = false;
    private bool isQuestGiver = false;


    void Start()
    {
        //Set the quest status saver.
        questStatusSaver = GameObject.Find("QuestSaver").GetComponent<QuestStatusSaver>();

        //Set some variables to the corresponding objects.
        gameObject.name = npcName;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;

        //Fix the collider bug.
        GetComponent<CapsuleCollider2D>().isTrigger = true;
        GetComponent<CapsuleCollider2D>().isTrigger = false;

        isQuestGiver = !quest.isEmpty();

        //If the NPC has a quest, spawn in a exclemation mark above their head.
        if (!hasAccepted && !hasCompletedQuest)
        {
            if (isQuestGiver)
            {
                Instantiate(questIconPrefab, transform);
                quest.npcName = npcName;
            }
            else
            {
                dialogIcon = Instantiate(dialogIconPrefab, transform);
            }
        }

        //Get the status from the npc quest saver and update the local values
        bool[] status = questStatusSaver.getNpcStatus(npcName);
        hasAccepted = status[0];
        hasCompletedQuest = status[1];
    }

    private void Update()
    {
        if (!isQuestGiver)
        {
            float dist = Vector2.Distance(player.transform.position, gameObject.transform.position);
            bool isClose = dist < 2;

            dialogIcon.SetActive(isClose);
        }
    }

    //When the player presses on the NPC,
    private void OnMouseDown()
    {
        //Check if the player is close enough to the NPC,
        float dist = Vector2.Distance(player.position, transform.position);
        if (dist < 2)
        {
            //Get the status from the npc quest saver and update the local values
            bool[] status = questStatusSaver.getNpcStatus(npcName);
            hasAccepted = status[0];
            hasCompletedQuest = status[1];

            //Check if the NPC has a quest assigned to it, otherwise display dialog instead.
            if (!quest.isEmpty())
            {
                //Check if the player has completed the quest or not.
                if (!hasCompletedQuest)
                {
                    //Check if the player has the item needed for the quest.
                    if (player.GetComponent<KeyItemsSaver>().hasItem(quest.requestedItem))
                    {
                        addDialog(dialogPrefab, "Dialogbox(Clone)", completionDialog, false);
                        hasCompletedQuest = true;
                    }
                    else
                    {
                        //If the quest from the NPC has not been accepted yet,
                        if (!hasAccepted)
                        {
                            addDialog(questPrefab, "Questbox(Clone)", startDialog, true);
                        } else
                        {
                            addDialog(dialogPrefab, "Dialogbox(Clone)", "Come back when you have completed the quest...", false);
                        }
                    }
                }
            }
            //Check if npc has dialog
            else if (!startDialog.Equals(string.Empty))
            {
                string dialog = !hasCompletedQuest ? startDialog : completionDialog;

                addDialog(dialogPrefab, "Dialogbox(Clone)", dialog, false);
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
