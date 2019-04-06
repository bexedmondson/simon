using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreen : Screen 
{
	[SerializeField]
	private NoteList sequenceJustPlayed;

	[SerializeField]
	private Text resultNumberText;
    
	private void OnEnable()
	{
		//When this screen is transitioned to, display the length of the sequence they successfully completed.
		resultNumberText.text = (sequenceJustPlayed.noteList.Count - 1).ToString();
	}
}
