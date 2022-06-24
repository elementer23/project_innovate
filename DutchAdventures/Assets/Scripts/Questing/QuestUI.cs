using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestUI : MonoBehaviour
{
    //public PlayerQuestHandler playerQuestHandler;
    [SerializeField]
    private JsonHandler jsonHandler;
    [SerializeField]
    private Animator taskcompletedPopup;
    [SerializeField]
    private Animator questcompletedPopup;
    
    private QuestStatusSaver questStatusSaver;

    private CanvasGroup canvasGroup;
    private CanvasGroup questTextCG;

    private TextMeshProUGUI title;
    private TextMeshProUGUI desc;
    private TextMeshProUGUI npcName;

    private bool hasQuest = false;
    public Quest currentQuest;
    private bool menuIsVisible;

    //Store a reference to the NPC, so the npc know if the quest has been accepted.
    [HideInInspector]
    public NPCController npcController;

    private void Awake()
    {
        questStatusSaver = GameObject.FindGameObjectWithTag("QuestSaver").GetComponent<QuestStatusSaver>();
    }

    /// <summary>
    /// Set the variables to the objects. These objects are all children of this object.
    /// </summary>
    void Start()
    {
        
        canvasGroup = GetComponent<CanvasGroup>();
        questTextCG = transform.GetChild(0).GetComponent<CanvasGroup>();

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

    /// <summary>
    /// Add the quest to the quest menu UI object.
    /// </summary>
    public void addQuest()
    {
        currentQuest = jsonHandler.ReadFromJson<Quest>("playerQuest");
        title.text = currentQuest.title;
        desc.text = currentQuest.description;
        npcName.text = currentQuest.npcName;
    }

    /// <summary>
    /// Toggle the visibility of the quest menu.
    /// </summary>
    public void questButton()
    {
        menuIsVisible = !menuIsVisible;
    }

    /// <summary>
    /// Remove quest from UI and update NPC data 
    /// </summary>
    public void removeQuest()
    {
        GameObject.Find("Player").GetComponent<PlayerQuestHandler>().resetQuest();

        // Update NPC quest data
        resetQuest(false, false);
    }

    /// <summary>
    /// Complete quest in Quest UI 
    /// </summary>
    public void completeQuest()
    {
        GameObject.Find("Player").GetComponent<PlayerQuestHandler>().completeQuest();
        questcompletedPopup.SetTrigger("Play");
        // Update NPC quest data
        resetQuest(true, true);
    }

    /// <summary>
    /// Reset Quest from player and NPC
    /// </summary>
    /// <param name="hasTaken">If npc has taken quest</param>
    /// <param name="hasCompleted">If npc has completed Quest</param>
    private void resetQuest(bool hasTaken, bool hasCompleted)
    {
        questStatusSaver.writeNpcStatusToJson(currentQuest.npcName, hasTaken, hasCompleted);

        GameObject.Find("Player").GetComponent<PlayerQuestHandler>().resetQuest();
        
        if (GameObject.Find(currentQuest.npcName) != null)
        {
            GameObject.Find(currentQuest.npcName).GetComponent<NPCController>().setNpc(hasTaken, hasCompleted);
        }

        //Reset player quest json  
        currentQuest = Quest.empty;
        jsonHandler.WriteToJson(currentQuest, "playerQuest");
    }

    /// <summary>
    /// Function to make setting the visibility of canvasObjects easier.
    /// </summary>
    /// <param name="cg">Canvas group of scene</param>
    /// <param name="visible">Vissible true or false</param>
    private void makeVisible(CanvasGroup cg, bool visible)
    {
        cg.alpha = visible ? 1 : 0;
        cg.interactable = visible;
        cg.blocksRaycasts = visible;
    }
}
