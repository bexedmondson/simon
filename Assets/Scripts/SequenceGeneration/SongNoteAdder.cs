using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongNoteAdder : NoteAdderBase 
{
	private NoteListReadonly songNoteList;

	public SongNoteAdder( NoteListReadonly songNoteList )
	{
		this.songNoteList = songNoteList;
	}

	public override void AddNote(NoteListEditable noteList)
	{
		noteList.NoteList.Add( songNoteList.GetNoteAtIndex( noteList.NoteListCount ) );
	}
}
