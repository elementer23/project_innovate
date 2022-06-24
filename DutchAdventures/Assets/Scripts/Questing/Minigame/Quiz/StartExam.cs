using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartExam : MonoBehaviour
{

    private int minDist = 2;
    [SerializeField]
    private GameObject pointer;
    public Transform player;
    public bool canTouch = false;

    // Update is called once per frame
    void Update()
    {
        //get the distance between the player and pointer object
        float dist = Vector2.Distance(player.position, transform.position);
        canTouch = dist < minDist;
        pointer.SetActive(canTouch);
    }

    private void OnMouseDown()
    {
        if (canTouch)
        {

           
        }
    }
}
