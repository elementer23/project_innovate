using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerNPCController : NPCController
{
    [SerializeField]
    private QuestUI questUI;

    private enum Tulips {BLUE, RED, YELLOW, PURPLE, WHITE};
    private List<Tulips> collectedTulipList = new List<Tulips>();
    public GameObject flowerContainer;
    public string holdingFlower;

    //When the player presses on the NPC,
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
                                    if (player.getQuest().hasCompleted)
                                    {
                                        //Complete the quest.
                                        GameObject dialog = addDialog(competionDialogPrefab, "CompletionDialog(Clone)", completionDialog, false);
                                    }
                                    else
                                    {
                                        //Quest not finished yet.
                                        if (holdingFlower.Length == 0)
                                        {
                                            notCompletedDialog = getNotCollectedTulipColors();
                                        } else
                                        {
                                            notCompletedDialog = getHoldingFlowerDialogue();
                                            holdingFlower = "";
                                            flowerContainer.SetActive(false);
                                            quest.description = getNotCollectedTulipColors();
                                            questUI.currentQuest = quest;
                                        }
                                       addDialog(dialogPrefab, "Dialogbox(Clone)", notCompletedDialog, false);
                                    }
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
            case "red_rose":
                dialogue = "This is a Red Rose. This looks like a Tulip but it is not.";
                return dialogue;
            case "sunflower":
                dialogue = "This is a Sunflower. It does not look like a Tulip.";
                return dialogue;
        }
        Tulips color = (Tulips)Enum.Parse(typeof(Tulips), holdingFlower.Split("_")[0].ToUpper());
        if(collectedTulipList.Contains(color))
        {
            dialogue += "You have already brought this. Can you find a diffrent color?";
        } else
        {
            collectedTulipList.Add(color);
            dialogue += "Thank you for finding this.";

        }
        return dialogue;

    }

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
