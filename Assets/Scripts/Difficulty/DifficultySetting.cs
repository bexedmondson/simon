using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DifficultySetting : ScriptableObject 
{
	[SerializeField]
	private float timeBetweenNotes;

	public float TimeBetweenNotes { get { return timeBetweenNotes; } }
}
