using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;

	/// <summary>
	/// triggers the dialogue of an npc or gameobject
	/// </summary>
	public void TriggerDialogue ()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		Debug.Log("Trigger");
	}

}
