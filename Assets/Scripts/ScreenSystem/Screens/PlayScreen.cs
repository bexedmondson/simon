using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScreen : Screen 
{
	[SerializeField]
	private NoteList sequenceToTestAgainst;

	[SerializeField]
	private ScreenType tuneScreenType;

	[SerializeField]
	private ScreenType resultScreenType;

	private int noteIndex = 0;

	private void OnEnable()
	{
		//When this screen is active, start counting the sequence from the first note.
		noteIndex = 0;
	}

	public void OnNotePlayed(NoteObject noteObjectPlayed)
	{
		noteObjectPlayed.Play( NoteObject.NotePlayType.Player );

		if( noteObjectPlayed.Note == sequenceToTestAgainst.noteList[ noteIndex ] )
		{
			//If player succeeded and there are still notes to play, wait for next note.
			if( noteIndex != sequenceToTestAgainst.noteList.Count - 1 )
			{
				noteIndex++;
				return;
			}
			else
			{
                //If player succeeded and there aren't any notes left to play, go back to the tune screen for the next sequence.
				StartCoroutine( "SwitchToTuneScreen" );
			}
		}
		else
		{
			//If the player failed, switch to the result screen.
			ScreenManager.Get.SwitchToScreen( resultScreenType );
		}
	}

	private IEnumerator SwitchToTuneScreen()
	{
		yield return new WaitForSeconds( 2.0f );
        ScreenManager.Get.SwitchToScreen( tuneScreenType );
	}
}
