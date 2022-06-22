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
        //find all npc with the NPC tag
        npcs = GameObject.FindGameObjectsWithTag("NPC");
        questNpcs = new List<GameObject>();
        
        //fill the questnpcs list
        FillQuestNPCList();

        //get the main camera
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
        //loop through all the npcs with a quest in current scene
        foreach (GameObject npc in questNpcs)
        {
            //check whether an npc has a active quest or not
            int Icon = npc.GetComponent<NPCController>().transform.childCount;
            bool QuestIconStatus = npc.GetComponent<NPCController>().transform.GetChild(Icon - 1).GetComponent<QuestIcon>().activeQuest;

            if (QuestIconStatus == true)
            {
                //get the player position and position of closest npc with a quest
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
        //clear the npc quest list 
        questNpcs.Clear();
        
        //loop through all the npcs in the current scene
        foreach (var npc in npcs)
        {
            //check whether an npc has a quest title or not
            if (!npc.GetComponent<NPCController>().quest.title.Equals(string.Empty))
            {
                //add the npcs with a quest to a list
                questNpcs.Add(npc);
            }
        }
        
        if (questNpcs.Count > 0)
        {
            //set the first npc that can be found as the closest npc
            closestNpc = questNpcs[0];
        }
    }
    private void DisappearArrow()
    {
        if (questNpcs.Count > 0)
        {
            //checks whether the npc object is within camera range
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
        //calculation to change the arrow position, so it points towards the closest npc
        Vector2 diff = npc.transform.position - player.position;
        float angle = Mathf.Atan2(diff.y, diff.x);
        arrow.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
    }
}
