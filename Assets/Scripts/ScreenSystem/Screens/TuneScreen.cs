using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Note: In a normal project, I would separate UI and game logic, but this game is 
// entirely built in UI so I'm putting more logic in this script than I usually would.
public class TuneScreen : Screen 
{
	private List<int> sequenceInProgress = new List<int> { };

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
		sequenceInProgress.Add( 0 );
	}   

    private IEnumerator PlaySequence()
    {
        int i = 0;

        while( i < sequenceInProgress.Count )
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
