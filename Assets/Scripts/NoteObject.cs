using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class NoteObject : MonoBehaviour 
{
	[SerializeField]
	private Note note;

	private Animator animator;

	private AudioSource audioSource;

	public Note Note { get { return note; } }

	private void Awake()
	{
		animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
	}

	public void Play()
	{
		animator.SetTrigger( "Play" );
		audioSource.PlayOneShot( audioSource.clip );
	}
}
