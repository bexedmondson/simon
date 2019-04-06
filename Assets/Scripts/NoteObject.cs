using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class NoteObject : MonoBehaviour 
{
	[SerializeField]
	private Note note;

	private Animator animator;

	public Note Note { get { return note; } }

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	public void Play()
	{
		animator.SetTrigger( "Play" );
	}
}
