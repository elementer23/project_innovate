using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestUI : MonoBehaviour
{
    //public PlayerQuestHandler playerQuestHandler;
<<<<<<< Updated upstream
    public JsonHandler jsonHandler;
    [SerializeField]
    private QuestStatusSaver questStatusSaver;
=======
    [SerializeField]
    private JsonHandler jsonHandler;
    [SerializeField]
    private Animator completedPopup;
>>>>>>> Stashed changes

    private CanvasGroup canvasGroup;
    private CanvasGroup questTextCG;

    private TextMeshProUGUI title;
    private TextMeshProUGUI desc;
    private TextMeshProUGUI npcName;

    private bool hasQuest = false;
    private Quest currentQuest;
    private bool menuIsVisible;

    //Store a reference to the NPC, so the npc know if the quest has been accepted.
    [HideInInspector]
    public NPCController npcController;

    void Start()
    {
        //Set the variables to the objects. These objects are all children of this object.
        canvasGroup = GetComponent<CanvasGroup>();
        questTextCG = transform.GetChild(0).GetComponent<CanvasGroup>();
        //playerQuestHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerQuestHandler>();

        title = transform.GetChild(0).Find("Title").GetComponent<TextMeshProUGUI>();
        desc = transform.GetChild(0).Find("Description").GetComponent<TextMeshProUGUI>();
        npcName = transform.GetChild(0).Find("NPC").GetComponent<TextMeshProUGUI>();

        jsonHandler = GameObject.Find("JsonHandler").GetComponent<JsonHandler>();
        currentQuest = jsonHandler.ReadFromJson<Quest>("playerQuest");
    }

    private void Update()
    {
        if (currentQuest != null)
        {
            hasQuest = !currentQuest.isEmpty();

            title.text = currentQuest.title;
            desc.text = currentQuest.description;
            npcName.text = currentQuest.npcName;
        }

        //Update the visibility of the menu and the quest inside the menu.
        makeVisible(canvasGroup, menuIsVisible);
        makeVisible(questTextCG, hasQuest);
    }

    public void addQuest()
    {
        //Add the quest to the quest menu UI object.
        currentQuest = jsonHandler.ReadFromJson<Quest>("playerQuest");
        title.text = currentQuest.title;
        desc.text = currentQuest.description;
        npcName.text = currentQuest.npcName;
    }

    public void questButton()
    {
        //Toggle the visibility of the quest menu.
        menuIsVisible = !menuIsVisible;
    }

    public void removeQuest()
    {
        resetQuest();
        GameObject.Find("Player").GetComponent<PlayerQuestHandler>().resetQuest();
    }

    public void completeQuest()
    {
        resetQuest();
        GameObject.Find("Player").GetComponent<PlayerQuestHandler>().completeQuest();
        completedPopup.SetTrigger("Play");
    }

    private void resetQuest()
    {
        //Unset the quest from the player and npc the menu.
        currentQuest = jsonHandler.ReadFromJson<Quest>("playerQuest");
        string npcName = currentQuest.npcName;

        //Reset player quest json  
        currentQuest = Quest.empty;
        jsonHandler.WriteToJson(currentQuest, "playerQuest");

        //Resetting NPC and playerQuest
<<<<<<< Updated upstream
        GameObject.Find("Player").GetComponent<PlayerQuestHandler>().resetQuest();
        
        if (GameObject.Find(npcName) != null)
        {
            GameObject.Find(npcName).GetComponent<NPCController>().resetNpc();

        }

        // Update NPC quest data
        questStatusSaver.writeNpcStatusToJson(npcName, false, false);
       

=======
        GameObject.Find(npcName).GetComponent<NPCController>().resetNpc();

        // Update NPC quest data
        GameObject.Find("QuestSaver").GetComponent<QuestStatusSaver>().writeNpcStatusToJson(npcName);
>>>>>>> Stashed changes
    }

    private void makeVisible(CanvasGroup cg, bool visible)
    {
        //Function to make setting the visibility of canvasObjects easier.
        cg.alpha = visible ? 1 : 0;
        cg.interactable = visible;
        cg.blocksRaycasts = visible;
    }
}
