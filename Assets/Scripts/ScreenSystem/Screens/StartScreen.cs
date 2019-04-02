using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Note: In a normal project, I would separate UI and game logic, but this game is 
// entirely built in UI so I'm putting more logic in this script than I usually would.
public class StartScreen : Screen 
{
	[SerializeField]
	private NoteList sequenceInProgress;

	private void OnEnable()
	{
		//Whenever this screen is shown, the sequence should be cleared
		sequenceInProgress.noteList.Clear();
	}
}
