using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInfo : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        DialogueTrigger trigger = gameObject.GetComponent(typeof(DialogueTrigger)) as DialogueTrigger;
        trigger.TriggerDialogue();
    }
}
