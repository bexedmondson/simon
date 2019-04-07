using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Make this inherit from Button instead, and change OnSelectDifficulty to override OnClick
public class DifficultyButton : MonoBehaviour 
{
	[SerializeField]
	private DifficultySettingHolder settingHolder;

	[SerializeField]
	private DifficultySetting difficultySetting;

	public void OnSelectDifficulty()
	{
		settingHolder.setting = difficultySetting;
	}
}
