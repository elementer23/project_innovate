using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Vector2 dist = player.position - transform.position;
        if (dist.sqrMagnitude < 4)
        {
            Debug.Log("QUEST");
        }

    }
}
