using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerNPCController : NPCController
{
    //Reference to the QuestUI so that can be updated with the correct information.
    [SerializeField]
    private QuestUI questUI;

    //The tulip colors.
    private enum Tulips {BLUE, RED, PINK, YELLOW, PURPLE, WHITE};
    //A list with the collected tulip colors.
    private List<Tulips> collectedTulipList = new();
    //Reference to the flower container so that can be updated with the correct information.
    public GameObject flowerContainer;
    //The flower name that the player is currently holding.
    [HideInInspector]
    public string holdingFlower = "";


    protected override void Start()
    {
        base.Start();
        KeyItemsSaver keyItemSaver = player.GetComponent<KeyItemsSaver>();
        foreach(KeyItem item in keyItemSaver.readItems().items)
        {
            if(!item.collected)
            {
                continue;
            }

            if (item.name.StartsWith("colledtedTulip"))
            {
                Tulips color = (Tulips)Enum.Parse(typeof(Tulips), item.name.Split("-")[1]);
                collectedTulipList.Add(color);
                continue;
            }


          /*  if (item.name.StartsWith("holdingFlower"))
            {
                holdingFlower = item.name.Split("-")[1];
                continue;
            }*/

        }

        if(holdingFlower.Length > 0)
        {
            flowerContainer.SetActive(true);
            GameObject ChildGameObject1 = flowerContainer.transform.GetChild(0).gameObject;
            ChildGameObject1.GetComponent<Image>().sprite = GameObject.Find(holdingFlower).GetComponent<SpriteRenderer>().sprite;
        }

        quest.description = getNotCollectedTulipColors();
        questUI.currentQuest = quest;
    }

    /// <summary>
    /// When the player presses on the NPC.
    /// </summary>
    protected override void OnMouseDown()
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
                                //Clear collected list if you are restarting the quest.
                                KeyItemsSaver keyItemSaver = player.GetComponent<KeyItemsSaver>();
           
                                foreach (string color in Enum.GetNames(typeof(Tulips)))
                                {
                                    keyItemSaver.setItem("colledtedTulip-" + color, false);
                                }

                                collectedTulipList.Clear();
                                //Give player quest
                                addDialog(questPrefab, "Questbox(Clone)", startDialog, true);
                                quest.description = getNotCollectedTulipColors();
                                questUI.currentQuest = quest;
                            }
                            else
                            {
                                if (!hasCompletedQuest)
                                {
                                 //Quest not finished yet.
                                 if (holdingFlower.Length == 0)
                                 {
                                    notCompletedDialog = getNotCollectedTulipColors();
                                 } 
                                 else
                                 {
                                    notCompletedDialog = getHoldingFlowerDialogue();
                                    KeyItemsSaver keyItemSaver = player.GetComponent<KeyItemsSaver>();
                                    keyItemSaver.setItem("holdingFlower-" + holdingFlower, false);
                                    holdingFlower = "";
                                    flowerContainer.SetActive(false);

                                    //If player has collected all the tulips.
                                    if(collectedTulipList.Count == Enum.GetValues(typeof(Tulips)).Length)
                                    {
                                       GameObject dialog = addDialog(competionDialogPrefab, "CompletionDialog(Clone)", completionDialog, false);
                                       return;
                                    }
                                    quest.description = getNotCollectedTulipColors();
                                    questUI.currentQuest = quest;
                                    }
                                    addDialog(dialogPrefab, "Dialogbox(Clone)", notCompletedDialog, false);
                                }
                                else
                                {
                                    //Quest is already finished finished.
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

    /// <summary>
    /// Gets the NPC dialogue depending on the flower the player is currently holding.
    /// </summary>
    /// <returns>
    /// The NPC dialogue.
    /// </returns>
    private string getHoldingFlowerDialogue()
    {
        string dialogue = "";
        switch(holdingFlower)
        {
            case "red_tulip":
                dialogue = "This is a Red Tulip. They represent love and friendship.";
                break;
            case "blue_tulip":
                dialogue = "This is a Blue Tulip. They represent peace and tranquility.";
                break;
            case "yellow_tulip":
                dialogue = "This is a Yellow Tulip. They represent sunshine but also symbolize rejection in love.";
                break;
            case "white_tulip":
                dialogue = "This is a White Tulip. They represent remembrance and respect .";
                break;
            case "purple_tulip":
                dialogue = "This is a Purple Tulip. They represent rebirth and spring .";
                break;
            case "pink_tulip":
                dialogue = "This is a Pink Tulip. They represent care and attachment.";
                break;
            //The non-tulip flowers are not remembered so they only have to show this.
            case "red_rose":
                dialogue = "This is a Red Rose. This looks like a Tulip but it is not.";
                return dialogue;
            case "sunflower":
                dialogue = "This is a Sunflower. It does not look like a Tulip.";
                return dialogue;
        }
        //Check if the player already brought this tullip color before.
        Tulips color = (Tulips)Enum.Parse(typeof(Tulips), holdingFlower.Split("_")[0].ToUpper());
        if(collectedTulipList.Contains(color))
        {
            //If the tulip color was already brought before.
            dialogue += "You have already brought this. Can you find a diffrent color?";
        } 
        else
        {
            //If the tulip color is new.
            collectedTulipList.Add(color);
            KeyItemsSaver keyItemSaver = player.GetComponent<KeyItemsSaver>();
            keyItemSaver.setItem("colledtedTulip-" + color, true);
            dialogue += "Thank you for finding this.";

        }
        return dialogue;

    }

    /// <summary>
    /// Generated the NPC dialogie for if the player does not have a flower.
    /// The colors the player has not yet collected will be shown.
    /// </summary>
    /// <returns></returns>
    private string getNotCollectedTulipColors()
    {
        string dialogue = "I still need the following colors: ";

        //Two loops are used here to properly format the dialogue with ',' and 'and';
        List<string> notCollectedTulips = new List<string>();

        foreach (Tulips tulip in Enum.GetValues(typeof(Tulips)))
        {
            if (collectedTulipList.Contains(tulip))
            {
                continue;
            }
            notCollectedTulips.Add(tulip.ToString());

        }
        //A for loop is used instead of a foreach so we can compare the index with the Count to see if the next entry is the last.
        //Used for correct formatting of the NPC dialogue.
        for (int i = 0; i < notCollectedTulips.Count; i++)
        {
            if (i > 0)
            {
                if (i == notCollectedTulips.Count - 1)
                {
                    //Next color is last.
                    dialogue += " and ";
                }
                else
                {
                    dialogue += ", ";
                }
            }
            dialogue += notCollectedTulips[i];
        }
        dialogue += ".";
        return dialogue; 
    }

}
