/* basics from https://github.com/Brackeys/Dialogue-System */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

	public string name;

	//the dialogue box
	[TextArea(3, 10)]
	public string[] sentences;

}
