/* basics from https://github.com/Brackeys/Dialogue-System */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueManager : MonoBehaviour {

	public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogueText;

	public Animator animator;

	private Queue<string> sentences;

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Awake () {
		sentences = new Queue<string>();
		GameObject dialogBox = GameObject.Find("DialogueBox");
		nameText = dialogBox.transform.Find("Name").GetComponent<TextMeshProUGUI>();
		dialogueText = dialogBox.transform.Find("Dialogue").GetComponent<TextMeshProUGUI>();
	}

	/// <summary>
	/// start the dialogue when conditions are met
	/// </summary>
	/// <param name="dialogue">Dialog Object</param>
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

	/// <summary>
	/// display the next sentence when clicked and dequeue it
	/// </summary>
	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			
			//when there is no more text load the next scene if it is explenation scene
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

	/// <summary>
	/// show the next sentence in the queue
	/// </summary>
	/// <param name="sentence">Sentence from dialog</param>
	/// <returns></returns>
	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	/// <summary>
	/// close the dialog box
	/// </summary>
	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
	}

}
