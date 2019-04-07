using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreen : Screen
{
	[SerializeField]
	private NoteListEditable sequenceJustPlayed;

	[SerializeField]
	private NoteListReadonlyHolder songHolder;

	[SerializeField]
	private GameMode gameMode;

	[SerializeField]
	private Text resultDescriptionText;

	[SerializeField]
	private Text resultNumberText;

	private void OnEnable()
	{
		//When this screen is transitioned to, display the length of the sequence they successfully completed.
		if( gameMode.currentGameMode == GameMode.GameModeType.Random )
		{
			resultDescriptionText.text = "You successfully played a sequence of length";
			resultNumberText.text = ( sequenceJustPlayed.NoteListCount - 1 ).ToString();
		}
		else if( gameMode.currentGameMode == GameMode.GameModeType.Song )
		{
			resultDescriptionText.text = "You completed this percentage of the song:";

			if( sequenceJustPlayed.NoteListCount == 1 )
			{
				resultNumberText.text = "0%";
			}
			else
			{
				//All the brackets! This is basically to get a percentage that the player completed of the song you've just played, while getting around problems with dividng ints.
				resultNumberText.text = ( (int)( (float)(sequenceJustPlayed.NoteListCount - 1) / (float)songHolder.noteList.NoteListCount * 100 ) ).ToString() + "%";
			}
		}
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
