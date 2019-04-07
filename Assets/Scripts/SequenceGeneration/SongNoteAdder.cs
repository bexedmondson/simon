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
			noteListEditable.NoteList.Add( Note.C4 ); //Purely for the maths on the results screen, this note isn't used anywhere.
			return SongFinishedState.Finished;
		}
		else
		{
			noteListEditable.NoteList.Add( songNoteList.GetNoteAtIndex( noteListEditable.NoteListCount ) );
			return SongFinishedState.NotFinished;
		}

	}
}
