using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NoteAdderBase 
{
	public abstract SongFinishedState AddNote(NoteListEditable noteListEditable);
}
