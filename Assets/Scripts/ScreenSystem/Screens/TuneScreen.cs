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
	private List<NoteObject> noteObjects;

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
		//Wait for a bit to give the player a moment to prepare.
		yield return new WaitForSeconds( 0.5f );

        int i = 0;

		while( i < sequenceInProgress.noteList.Count )
        {
			PlayNote(sequenceInProgress.noteList[i]);
            i++;
            yield return new WaitForSeconds( 1.0f );
        }

		ScreenManager.Get.SwitchToScreen( gameplayScreenType );
    }
    
	private void PlayNote(Note note)
	{
		NoteObject noteObjectToPlay = noteObjects.Find( noteObject => noteObject.Note == note );

		if( noteObjectToPlay == null )
		{
			Debug.LogError( "No note object found for note " + note.ToString() + "!" );
			return;
		}
		else
		{
			noteObjectToPlay.Play(NoteObject.NotePlayType.Sequence);
		}
	}
}
