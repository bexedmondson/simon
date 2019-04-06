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

		public GameObject ScreenObject { get { return screenObject.gameObject; } }

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
			foreach( ScreenTypePair screen in screenTypePairs )
			{
				screen.ScreenObject.SetActive( screen.ScreenType == screenTypeToSwitchTo );
			}
		}
		else
		{
			Debug.LogError( "Trying to switch to a screen type '" + screenTypeToSwitchTo.name + "' that doesn't exist in ScreenManager's list!" );
		}
	}
}
