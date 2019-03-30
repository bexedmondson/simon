using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScreenType : ScriptableObject 
{
	[SerializeField]
	private string screenName;

	public string ScreenName { get { return screenName; } }
}
