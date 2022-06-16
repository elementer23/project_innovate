using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WindowQuestPointer : MonoBehaviour
{

    public GameObject[] npcs;
    public Transform player;
    public Transform arrow;
   

    private GameObject closestNpc;
    [SerializeField]
    private bool QuestNPC = false;

    private Camera cam;

    private void Start()
    {
        npcs = GameObject.FindGameObjectsWithTag("NPC");
        closestNpc = npcs[0];
        cam = UnityEngine.Camera.main;

    }

    private void Update()
    {
        foreach (GameObject npc in npcs)
        {
            if (npc.GetComponent<NPCController>().isQuestGiver)
            {
                //!npc.GetComponent<NPCController>().quest.title.Equals(string.Empty)
                //if (!player.GetComponent<KeyItemsSaver>().hasItem(npc.GetComponent<NPCController>().getRequiredKeyitem()))
                //{
                    Debug.Log(!npc.GetComponent<NPCController>().quest.requestedItem.Equals(string.Empty));
                    QuestNPC = true;
                    float playerPos = Vector2.Distance(npc.transform.position, player.position);
                    float closestNpcPos = Vector2.Distance(closestNpc.transform.position, player.position);

                    if (playerPos < closestNpcPos)
                    {
                        closestNpc = npc;
                    }

                Vector3 viewPos = cam.ViewportToWorldPoint(closestNpc.transform.position);
                if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
                {
                    QuestNPC = false;
                }
                else
                {
                    QuestNPC = true;
                }
                //}
            }
        }
        gameObject.SetActive(QuestNPC);
        updateArrow(closestNpc);

    }

    private void updateArrow(GameObject npc)
    {
        Vector2 diff = npc.transform.position - player.position;
        float angle = Mathf.Atan2(diff.y, diff.x);
        arrow.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
    }
}
