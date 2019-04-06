using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NoteListEditable : NoteListBase 
{
	public List<Note> NoteList { get { return noteList; } }
}
