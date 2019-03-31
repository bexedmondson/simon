using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour 
{
	[System.Serializable]
	public class ScreenTypePair
	{
		[SerializeField]
		private ScreenType type;

		[SerializeField]
		private Screen screenObject;
	}

	[SerializeField]
	private List<ScreenTypePair> screenTypePairs = new List<ScreenTypePair> { };

	private static ScreenManager instance = null;
    
	void Awake()
    {
		//Making this a singleton so only one thing is changing the screens at once.
		if( instance == null )         
            instance = this;
        else if( instance != this )
            Destroy( gameObject );

        DontDestroyOnLoad( gameObject );
    }
}
