using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInfo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject pointer;
    private bool isClose = false;
    public Transform player;
    private int minDist = 10;



    private void Update()
    {
        //get the distance between the player and the pointer object
        float dist = Vector2.Distance(player.position, transform.position);
        isClose = dist < minDist;
        pointer.SetActive(isClose);
    }

    private void OnMouseDown()
    {
        if (isClose)
        {
            //Trigger the dialogue box that belongs to the object
            DialogueTrigger trigger = gameObject.GetComponent(typeof(DialogueTrigger)) as DialogueTrigger;
            trigger.TriggerDialogue();
        }
    }

}
