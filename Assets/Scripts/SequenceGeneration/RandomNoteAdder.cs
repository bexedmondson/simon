using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNoteAdder : NoteAdderBase 
{
	public override void AddNote(NoteListEditable noteListEditable)
	{
		System.Array allNotes = System.Enum.GetValues( typeof( Note ) );
        
		noteListEditable.NoteList.Add( (Note) allNotes.GetValue( UnityEngine.Random.Range( 0, allNotes.Length ) ) );
	}
}
