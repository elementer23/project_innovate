using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogHandler))]
public class QuestHandler : MonoBehaviour
{
    public Quest quest;
    private DialogHandler handler;
    private PlayerQuestHandler player;

    [SerializeField]
    private CanvasGroup btns;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerQuestHandler>();
        handler = GetComponent<DialogHandler>();
        btns.alpha = 0;
    }

    void Update()
    {
        btns.alpha = handler.isFinished ? 1 : 0; 
        btns.interactable = handler.isFinished;
    }

    public void acceptBtn()
    {
        
        Debug.Log("accept");
    }
}
