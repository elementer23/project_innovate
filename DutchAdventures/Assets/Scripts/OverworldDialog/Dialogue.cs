/* basics from https://github.com/Brackeys/Dialogue-System */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

	public string name;

	/// <summary>
	/// the dialogue box
	/// </summary>
	[TextArea(3, 10)]
	public string[] sentences;

}
