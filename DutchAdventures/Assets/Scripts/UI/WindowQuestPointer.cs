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
    private void Start()
    {
        npcs = GameObject.FindGameObjectsWithTag("NPC");
        closestNpc = npcs[0];

    }

    private void Update()
    {
        foreach (GameObject npc in npcs)
        {
            if (!npc.GetComponent<NPCController>().quest.title.Equals(string.Empty))
            {
                if (player.GetComponent<KeyItemsSaver>().hasItem(npc.GetComponent<NPCController>().getRequiredKeyitem()))
                {
                    QuestNPC = true;
                    float playerPos = Vector2.Distance(npc.transform.position, player.position);
                    float closestNpcPos = Vector2.Distance(closestNpc.transform.position, player.position);

                    if (playerPos < closestNpcPos)
                    {
                        closestNpc = npc;
                    }
                }
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
