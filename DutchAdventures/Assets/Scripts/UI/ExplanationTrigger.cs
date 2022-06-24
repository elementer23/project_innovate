using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplanationTrigger : MonoBehaviour
{
    /// <summary>
    /// Trigger dialog when explenation screen is opent
    /// </summary>
    void Start()
    {
        DialogueTrigger trigger = gameObject.GetComponent(typeof(DialogueTrigger)) as DialogueTrigger;
        trigger.TriggerDialogue();
    }

}
