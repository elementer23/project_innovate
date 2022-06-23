using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    protected PlayerQuestHandler player;
    protected Transform canvas;
    protected int minDist = 5;
    protected QuestStatusSaver questStatusSaver;

    [SerializeField]
    protected GameObject dialogPrefab;
    [SerializeField]
    protected GameObject questPrefab;
    [SerializeField]
    protected GameObject competionDialogPrefab;

    public GameObject questIconPrefab;

    public string requiredItem;

    public bool hasRequiredItem;

    [Header("NPC Data")]
    //The same saved to the json etc.
    public string npcName;
    //The name to be displayed in the dialog
    public string displayName;

    [SerializeField]
    protected bool hideOnCompletion;

    protected bool canTakeQuest;

    //Dialog:
    [Header("Dialog")]
    public string startDialog;
    public string questBusyDialog;
    public string notCompletedDialog;
    public string completionDialog;
    public string postCompletionDialog;

    [Header("Quest")]
    public Quest quest;

    //[HideInInspector]
    public bool hasAccepted = false;
    //[HideInInspector]
    public bool hasCompletedQuest = false;
    [HideInInspector]
    public bool isQuestGiver = false;

    protected virtual void Start()
    {
        //Set the quest status saver.
        questStatusSaver = GameObject.Find("QuestSaver").GetComponent<QuestStatusSaver>();

        //Set some variables to the corresponding objects.
        gameObject.name = npcName;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerQuestHandler>();
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;

        isQuestGiver = !quest.isEmpty();

        //Get the status from the npc quest saver and update the local values
        bool[] status = questStatusSaver.getNpcStatus(npcName);
        hasAccepted = status[0];
        hasCompletedQuest = status[1];

        if (isQuestGiver)
        {
            quest.npcName = npcName;
        }

        createDialogBoxes();

        if(displayName == string.Empty)
        {
            displayName = npcName;
        }
    }

    protected virtual void Update()
    {
        createDialogBoxes();
    }

    protected void createDialogBoxes() 
    {
        //Spawn a quest marker/dialog icon above the npc
        if (canTakeQuest && !transform.Find("QuestMarker(Clone)"))
        {
            Instantiate(questIconPrefab, transform);
        }

        hasRequiredItem = player.GetComponent<KeyItemsSaver>().hasItem(requiredItem);
        //hasRequiredItem = player.getQuest().hasCompleted;

        if (requiredItem == string.Empty)
        {
            canTakeQuest = true;
        }
        else
        {
            if (hasRequiredItem)
            {
                canTakeQuest = true;
                if(transform.Find("QuestMarker(Clone)"))
                {
                    transform.Find("QuestMarker(Clone)").GetComponent<QuestIcon>().activeQuest = true;
                }

            }
            else
            {
                canTakeQuest = false;
                if (!transform.Find("QuestMarker(Clone)"))
                {
                    Instantiate(questIconPrefab, transform);
                }
            }
        }

        if (hideOnCompletion)
        {
            gameObject.SetActive(!hasCompletedQuest);
        }
    }

    //When the player presses on the NPC,
    protected virtual void OnMouseDown()
    {
        if (canTakeQuest)
        {
            //Check if the player is close enough to the NPC,
            float dist = Vector2.Distance(player.transform.position, transform.position);
            if (dist < minDist)
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
                        // Check if player has already quest
                        if (player.getQuest().title.Equals(string.Empty) || player.getQuest().title.Equals(quest.title))
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
                                    if (player.getQuest().hasCompleted)
                                    {
                                        //Complete the quest
                                        GameObject dialog = addDialog(competionDialogPrefab, "CompletionDialog(Clone)", completionDialog, false);
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
                        else 
                        {
                            addDialog(dialogPrefab, "Dialogbox(Clone)", questBusyDialog, false);
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

    public string getRequiredKeyitem()
    {
        return this.requiredItem;
    }
    protected virtual GameObject addDialog(GameObject prefab, string objName, string dialog, bool isQuest)
    {
        if (!canvas.Find(objName))
        {
            GameObject obj = Instantiate(prefab, canvas);
            DialogHandler dhandler = obj.GetComponent<DialogHandler>();

            dhandler.dialog = dialog;
            dhandler.npc = this;

            if (isQuest)
            {
                QuestHandler qhandler = obj.GetComponent<QuestHandler>();

                qhandler.quest = quest;
                qhandler.npcController = this;
            }
            return obj;
        }
        return null;
    }

    //Function to reset the NPC after completion or abanoning of the quest.
    public void setNpc(bool hasTaken, bool hasCompleted)
    {
        hasAccepted = hasTaken;
        hasCompletedQuest = hasCompleted;
    }
}
