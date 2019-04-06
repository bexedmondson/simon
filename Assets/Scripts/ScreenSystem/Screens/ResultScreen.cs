using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreen : Screen
{
	[SerializeField]
	private NoteListEditable sequenceJustPlayed;

	[SerializeField]
	private Text resultNumberText;

	private void OnEnable()
	{
		//When this screen is transitioned to, display the length of the sequence they successfully completed.
		resultNumberText.text = ( sequenceJustPlayed.NoteListCount - 1 ).ToString();
	}

	public void ExitGame()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}
}
