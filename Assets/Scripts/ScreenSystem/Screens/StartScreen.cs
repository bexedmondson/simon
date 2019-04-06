using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Note: In a normal project, I would separate UI and game logic, but this game is 
// entirely built in UI so I'm putting more logic in this script than I usually would.
public class StartScreen : Screen 
{
	[SerializeField]
	private NoteListEditable sequenceInProgress;

	[SerializeField, Tooltip("This is a holder for the current song. Ignored if in random mode.")]
    private NoteListReadonlyHolder currentSongHolder;

	[SerializeField]
	private GameMode gameMode;

	[SerializeField]
	private ScreenType tuneScreenType;   

	private void OnEnable()
	{
		//Whenever this screen is shown, the sequence should be cleared
        //This really should just be a failsafe - sequence should be cleared by Results screen,
        //but in case the player exits halfway through or something, clearing here to be sure.
		sequenceInProgress.NoteList.Clear();
	}

	public void OnRandomStartSelected()
	{
		gameMode.currentGameMode = GameMode.GameModeType.Random;

		ScreenManager.Get.SwitchToScreen( tuneScreenType );
	}

	public void OnSongSelected(NoteListReadonly song)
	{
		currentSongHolder.noteList = song;
		gameMode.currentGameMode = GameMode.GameModeType.Song;      

		ScreenManager.Get.SwitchToScreen( tuneScreenType );
	}
}
