using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TODO: Make this inherit from Button instead, and change OnSelectDifficulty to override OnClick
public class DifficultyButton : MonoBehaviour 
{
	[SerializeField]
	private DifficultySettingHolder settingHolder;

	[SerializeField]
	private DifficultySetting difficultySetting;

	[SerializeField]
	private Image tick;

	public void OnEnable()
	{
		tick.gameObject.SetActive( settingHolder.setting == difficultySetting );
	}

	public void OnSelectDifficulty()
	{
		settingHolder.setting = difficultySetting;
		tick.gameObject.SetActive( true );
	}
}
