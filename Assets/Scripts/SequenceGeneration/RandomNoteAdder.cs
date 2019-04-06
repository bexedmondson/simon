using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNoteAdder : NoteAdderBase 
{
	public override void AddNote(List<Note> noteList)
	{
		System.Array allNotes = System.Enum.GetValues( typeof( Note ) );
        
		noteList.Add( (Note) allNotes.GetValue( UnityEngine.Random.Range( 0, allNotes.Length ) ) );
	}
}
