using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WindowQuestPointer : MonoBehaviour
{

    public GameObject[] npcs;
    public List<GameObject> questNpcs;
    public Transform player;
    public Transform arrow;

    private GameObject closestNpc;

    private Camera cam;
    private CanvasGroup getCanvas;

    private void Start()
    {
        npcs = GameObject.FindGameObjectsWithTag("NPC");
        questNpcs = new List<GameObject>();

        FillQuestNPCList();

        cam = Camera.main;
        getCanvas = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        FillQuestNPCList();
        if (questNpcs.Count > 0)
        {
            QuestNavigator();
        }
        else
        {
            getCanvas.alpha = 0;
        }
    }

    private void QuestNavigator()
    {
        foreach (GameObject npc in npcs)
        {
            int Icon = npc.GetComponent<NPCController>().transform.childCount;
            var QuestIconStatus = npc.GetComponent<NPCController>().transform.GetChild(Icon - 1).GetComponent<QuestIcon>().activeQuest;
            //Debug.Log(npc.GetComponent<NPCController>().npcName + " Icon = " + QuestIconStatus);

            if (QuestIconStatus == true)
            {
                float playerPos = Vector2.Distance(npc.transform.position, player.position);
                float closestNpcPos = Vector2.Distance(closestNpc.transform.position, player.position);

                if (playerPos < closestNpcPos)
                {
                    closestNpc = npc;
                }

                DisappearArrow();
                UpdateArrow(closestNpc);
            } 
            
        }
        
    }

    private void FillQuestNPCList()
    {
        foreach (var npc in npcs)
        {
            if (!npc.GetComponent<NPCController>().quest.title.Equals(string.Empty))
            {
                questNpcs.Add(npc);
            }
        }
        if (questNpcs.Count > 0)
        {
            closestNpc = questNpcs[0];
        }
    }
    private void DisappearArrow()
    {
        if (questNpcs.Count > 0)
        {
            Vector3 viewPos = cam.WorldToViewportPoint(closestNpc.transform.position);

            if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
            {
                getCanvas.alpha = 0;
            }
            else
            {
                getCanvas.alpha = 1;
            }
        }
        else
        {
            getCanvas.alpha = 0;
        }
    }

    private void UpdateArrow(GameObject npc)
    {
        Vector2 diff = npc.transform.position - player.position;
        float angle = Mathf.Atan2(diff.y, diff.x);
        arrow.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
    }
}
