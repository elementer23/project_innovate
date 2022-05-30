using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private Transform player;
    private Transform canvas;

    [HideInInspector]
    public GameObject dialogPrefab;
    [HideInInspector]
    public GameObject questPrefab;
    [HideInInspector]
    public GameObject questIconPrefab;
    [HideInInspector]
    public GameObject dialogIconPrefab;

    [Header("Dialog")]
    public string npcName;
    public string dialog;
    public bool hasAccepted = false;

    [Header("Quest")]
    public Quest quest;

    bool isQuestGiver = false;
    public GameObject dialogIcon;

    void Start()
    {
        //Set some variables to the corresponding objects.
        gameObject.name = npcName;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;

        //Fix the collider bug.
        GetComponent<CapsuleCollider2D>().isTrigger = true;
        GetComponent<CapsuleCollider2D>().isTrigger = false;

        isQuestGiver = !quest.isEmpty();

        //If the NPC has a quest, spawn in a exclemation mark above their head.
        if (isQuestGiver)
        {
            Instantiate(questIconPrefab, transform);
            quest.npcName = npcName;
        } else
        {
            dialogIcon = Instantiate(dialogIconPrefab, transform);
        }
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
            //Check if the NPC has a quest assigned to it, otherwise display dialog instead.
            if (!quest.isEmpty())
            {
                //If the quest from the NPC has not been accepted yet,
                if (!hasAccepted)
                {
                    //Check if the quest dialog box does not already exist,
                    if (!canvas.Find("Questbox(Clone)"))
                    {
                        //Add the quest dialog box.
                        GameObject obj = Instantiate(questPrefab, canvas);
                        DialogHandler dhandler = obj.GetComponent<DialogHandler>();
                        QuestHandler qhandler = obj.GetComponent<QuestHandler>();

                        dhandler.dialog = dialog;
                        dhandler.npcName = npcName;
                        qhandler.quest = quest;
                        qhandler.npcController = this;
                    }
                }
            }
            else
            {
                //Check if a dialog box already exist,
                if (!canvas.Find("Dialogbox(Clone)"))
                {
                    //Add the dialog box.
                    GameObject obj = Instantiate(dialogPrefab, canvas);
                    DialogHandler dhandler = obj.GetComponent<DialogHandler>();
                    dhandler.dialog = dialog;
                    dhandler.npcName = npcName;
                }
            }

        }
    }

    //Function to reset the NPC after completion or abanoning of the quest.
    public void resetNpc()
    {
        if (!quest.isEmpty())
        {
            Instantiate(questIconPrefab, transform);
            hasAccepted = false;
        }
    }

    //Function to make the NPC display dialog instead of a quest
    //when the player has completed the quest.
    public void clearNpc()
    {
        dialog = quest.completionDialog;
        quest = new Quest("", "", "", "", 0, false, "");
        hasAccepted = false;
    }
}
