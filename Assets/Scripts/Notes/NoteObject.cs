using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class NoteObject : MonoBehaviour 
{
	public enum NotePlayType
	{
		Sequence,
        Player,
	}

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

	public void Play(NotePlayType notePlayType)
	{
		if( notePlayType == NotePlayType.Player )
		{
			animator.SetTrigger( "PlayPlayer" );
		}
		else if( notePlayType == NotePlayType.Sequence )
		{
			animator.SetTrigger( "PlaySequence" );
		}

		audioSource.PlayOneShot( audioSource.clip );
	}
}
