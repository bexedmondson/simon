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

	public override SongFinishedState AddNote(NoteListEditable noteListEditable)
	{
		if( noteListEditable.NoteListCount == songNoteList.NoteListCount )
		{
			return SongFinishedState.Finished;
		}
		else
		{
			noteListEditable.NoteList.Add( songNoteList.GetNoteAtIndex( noteListEditable.NoteListCount ) );
			return SongFinishedState.NotFinished;
		}

	}
}
