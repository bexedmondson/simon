using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSelectScreen : Screen 
{
	[SerializeField, Tooltip("This is a holder for the current song. Ignored if in random mode.")]
    private NoteListReadonlyHolder currentSongHolder;

    [SerializeField]
    private GameMode gameMode;

    [SerializeField]
    private ScreenType tuneScreenType;

	public void OnSongSelected( NoteListReadonly song )
    {
        currentSongHolder.noteList = song;
        gameMode.currentGameMode = GameMode.GameModeType.Song;

        ScreenManager.Get.SwitchToScreen( tuneScreenType );
    }
}
