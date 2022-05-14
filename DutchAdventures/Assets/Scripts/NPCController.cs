using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    Transform player;
    Transform canvas;
    [HideInInspector]
    public GameObject dialogPrefab;
    [HideInInspector]
    public GameObject questPrefab;
    [HideInInspector]
    public GameObject questIconPrefab;
    public Quest quest;
    public string dialog;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;

        if(quest.description != string.Empty)
        {
            Instantiate(questIconPrefab, transform);
        }
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Vector2 dist = player.position - transform.position;
        if (dist.sqrMagnitude < 4)
        {
            if (quest.description != string.Empty)
            {
                if (!canvas.Find("Questbox(Clone)"))
                {
                    GameObject obj = Instantiate(questPrefab, canvas);
                    DialogHandler dhandler = obj.GetComponent<DialogHandler>();
                    dhandler.dialog = dialog;
                }
            }
            else
            {
                if (!canvas.Find("Dialogbox(Clone)"))
                {
                    GameObject obj = Instantiate(dialogPrefab, canvas);
                    DialogHandler dhandler = obj.GetComponent<DialogHandler>();
                    dhandler.dialog = dialog;
                }
            }
        }
    }
}
