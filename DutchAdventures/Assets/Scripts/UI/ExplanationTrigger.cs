using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplanationTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DialogueTrigger trigger = gameObject.GetComponent(typeof(DialogueTrigger)) as DialogueTrigger;
        trigger.TriggerDialogue();
    }

}
