using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScreenManager : MonoBehaviour 
{
	[System.Serializable]
	public class ScreenTypePair
	{
		[SerializeField]
		private ScreenType type;

		[SerializeField]
		private Screen screenObject;

		public Screen ScreenObject { get { return screenObject; } }

		public ScreenType ScreenType { get { return type; } }
	}

	[SerializeField]
	private ScreenType initialScreenType;

	[SerializeField]
	private List<ScreenTypePair> screenTypePairs = new List<ScreenTypePair> { };
    
	private static ScreenManager instance = null;
	public static ScreenManager Get { get { return instance; } }
    
	void Awake()
    {
		//Making this a singleton so only one thing is changing the screens at once.
		if( instance == null )         
            instance = this;
        else if( instance != this )
            Destroy( gameObject );

        DontDestroyOnLoad( gameObject );
    }
    
	private void Start()
	{
		SwitchToScreen( initialScreenType );
	}

	public void SwitchToScreen( ScreenType screenTypeToSwitchTo )
	{
		if( screenTypePairs.Any( screen => screen.ScreenType == screenTypeToSwitchTo ) )
		{
            Screen outScreen = null;
            Screen inScreen = null;

			foreach( ScreenTypePair screen in screenTypePairs )
			{            
				if( screen.ScreenObject.gameObject.activeInHierarchy && screen.ScreenType != screenTypeToSwitchTo )
				{
                    //Turn off any screens that are on and shouldn't be
					outScreen = screen.ScreenObject;
				}
				else if( !screen.ScreenObject.gameObject.activeInHierarchy && screen.ScreenType == screenTypeToSwitchTo )
				{
					//Turn on any screens that aren't on and should be
					inScreen = screen.ScreenObject;
				}            
			}

			if( inScreen != null || outScreen != null )
			{
				StartCoroutine( WaitForTransitionOut( inScreen, outScreen ) );
			}
		}
		else
		{
			Debug.LogError( "Trying to switch to a screen type '" + screenTypeToSwitchTo.name + "' that doesn't exist in ScreenManager's list!" );
		}
	}
    
	private IEnumerator WaitForTransitionOut(Screen inScreen, Screen outScreen)
	{
		//outScreen should be null during the initial transition in of the Start screen, so no else clause needed here
		if( outScreen != null )
		{
			Animator outAnimator = outScreen.GetComponent<Animator>();

            //If the outScreen has an Animator, and if the animator has a trigger called "TransitionOut", trigger it and wait for it to end.
			if( outAnimator != null && outAnimator.parameters.Any( parameter => parameter.name == "TransitionOut" ) )
			{            
				outAnimator.SetTrigger( "TransitionOut" );

				//Wait a frame here for the animator to follow the trigger and start the animation.
				yield return null;

                //Wait until animation is done.
				yield return new WaitUntil( () => outAnimator.GetCurrentAnimatorStateInfo( 0 ).normalizedTime > 1.0f );
			}

			outScreen.gameObject.SetActive( false );
		}

		if( inScreen != null )
		{
			inScreen.gameObject.SetActive( true );
		}
		else
		{
			Debug.LogError( "Can't transition in a null screen! Transitioned out " + outScreen );
		}
	}
}
