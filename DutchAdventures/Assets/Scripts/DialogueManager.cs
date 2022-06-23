/* basics from https://github.com/Brackeys/Dialogue-System */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

	public Animator animator;

	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
	}

	//start the dialogue when conditions are met
	public void StartDialogue (Dialogue dialogue)
	{
		animator.SetBool("IsOpen", true);
	
		nameText.text = dialogue.name;
		
		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			//put the new or old lines of the object or npc inside a queue
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	//display the next sentence when clicked and dequeue it
	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			
			//when there is no more text load the next scene
			if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("ExplenationScreen"))
			{
				GameObject.Find("Canvas").GetComponent<MenuTransition>().toSceneNoPopup("LevelSelect");
			}
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	//show the next sentence in the queue
	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	//close the dialog box
	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
	}

}
