using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Note: In a normal project, I would separate UI and game logic, but this game is 
// entirely built in UI so I'm putting more logic in this script than I usually would.
public class TuneScreen : Screen 
{   
	[SerializeField]
	private NoteListEditable sequenceInProgress;

	[SerializeField]
	private List<NoteObject> noteObjects;

	[SerializeField, Tooltip("This is a holder for the current song. Ignored if in random mode.")]
	private NoteListReadonlyHolder currentSongHolder;

	[SerializeField]
	private GameMode gameMode;

	[SerializeField]
	private ScreenType gameplayScreenType;

	[SerializeField]
	private ScreenType resultScreenType;

	private NoteAdderBase noteAdder;

	//As soon as the screen manager switches to this screen, begin a sequence.
	private void OnEnable()
	{
		switch( gameMode.currentGameMode )
		{
			case GameMode.GameModeType.Song:
			{
				if( !( noteAdder is SongNoteAdder ) )
				{
    				noteAdder = new SongNoteAdder( currentSongHolder.noteList );
				}
				break;
			}
			case GameMode.GameModeType.Random: //putting this in for clarity
			default:
			{
				if( !( noteAdder is RandomNoteAdder ) )
				{
				    noteAdder = new RandomNoteAdder();
				}
				break;
			}
		}

		SongFinishedState isSongFinished = noteAdder.AddNote( sequenceInProgress );

		if( isSongFinished == SongFinishedState.Finished )
		{
			ScreenManager.Get.SwitchToScreen( resultScreenType );
		}
		else
		{
			StartCoroutine( "PlaySequence" );
		}
	}

    private IEnumerator PlaySequence()
    {
		//Wait for a bit to give the player a moment to prepare.
		yield return new WaitForSeconds( 0.5f );

        int i = 0;
        
		while( i < sequenceInProgress.NoteListCount )
        {
			PlayNote( sequenceInProgress.GetNoteAtIndex(i) );
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
