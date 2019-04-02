using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Note: In a normal project, I would separate UI and game logic, but this game is 
// entirely built in UI so I'm putting more logic in this script than I usually would.
public class TuneScreen : Screen 
{
	[SerializeField]
	private NoteList listOfAvailableNotes;

	[SerializeField]
	private NoteList sequenceInProgress;

	[SerializeField]
	private ScreenType gameplayScreenType;

	//As soon as the screen manager switches to this screen, begin a sequence.
	private void OnEnable()
	{
		AddNote();

		StartCoroutine( "PlaySequence" );
	}

	private void AddNote()
	{
		sequenceInProgress.noteList.Add( listOfAvailableNotes.noteList[ Random.Range( 0, listOfAvailableNotes.noteList.Count ) ] );
	}   

    private IEnumerator PlaySequence()
    {
        int i = 0;

		while( i < sequenceInProgress.noteList.Count )
        {
            PlayNote();
            i++;
            yield return new WaitForSeconds( 1.0f );
        }

		ScreenManager.Get.SwitchToScreen( gameplayScreenType );
    }

	private void PlayNote()
	{
	}
}
