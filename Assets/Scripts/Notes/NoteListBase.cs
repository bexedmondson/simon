﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu]
public abstract class NoteListBase : ScriptableObject 
{
	protected List<Note> noteList;

	public Note GetNoteAtIndex( int i )
	{
		return noteList[ i ];
	}

	public int NoteListCount { get { return noteList.Count; } }
}
