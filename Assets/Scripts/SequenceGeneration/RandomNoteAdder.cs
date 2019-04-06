using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNoteAdder : NoteAdderBase 
{
	public override Note AddNote()
	{
		System.Array allNotes = System.Enum.GetValues( typeof( Note ) );
        
		return (Note) allNotes.GetValue( UnityEngine.Random.Range( 0, allNotes.Length ) );
	}
}
