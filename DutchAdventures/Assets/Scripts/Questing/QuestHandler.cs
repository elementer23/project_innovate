using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogHandler))]
public class QuestHandler : MonoBehaviour
{
    public Quest quest;
    private DialogHandler handler;
    private PlayerQuestHandler player;
    private QuestUI questUI;
    [HideInInspector]
    public NPCController npcController;

    [SerializeField]
    private CanvasGroup btns;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerQuestHandler>();
        handler = GetComponent<DialogHandler>();
        questUI = transform.parent.Find("QuestMenu").GetComponent<QuestUI>();
        btns.alpha = 0;
    }

    void Update()
    {
        btns.alpha = handler.isFinished ? 1 : 0;
        btns.interactable = handler.isFinished;
    }

    public void acceptBtn()
    {
        Destroy(npcController.transform.Find("QuestMarker(Clone)").gameObject);
        npcController.hadAccepted = true;
        player.addQuest(quest);
        questUI.addQuest(quest);
        Destroy(gameObject);

    }
}
