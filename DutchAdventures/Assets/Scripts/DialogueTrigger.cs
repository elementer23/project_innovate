using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		//triggers the dialogue of an npc or gameobject
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		Debug.Log("Trigger");
	}

}
