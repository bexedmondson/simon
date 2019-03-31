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
}
