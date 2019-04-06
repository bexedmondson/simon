using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameMode : ScriptableObject 
{
	public enum GameModeType
	{
		Random,
        Song,
	}

	public GameModeType currentGameMode;
}
