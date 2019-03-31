using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CustomEditor( typeof( ScreenManager ) )]
public class ScreenManagerInspector : Editor
{
#region Subclasses
    
	public static class ScreenListInspector
    {
		static List<bool> expansionBoolList = new List<bool> { };

		public static void ShowList( SerializedProperty list )
        {
			EditorGUILayout.PropertyField( list );

			if( list.isExpanded )
			{            
				EditorGUILayout.PropertyField( list.FindPropertyRelative( "Array.size" ) );

				if( list.arraySize > expansionBoolList.Count )
				{
					int sizeBoolListStartedAs = expansionBoolList.Count;
					for( int i = sizeBoolListStartedAs; i < list.arraySize; i++ )
						expansionBoolList.Add( true );
				}
				else if( list.arraySize > expansionBoolList.Count )
				{
					int sizeBoolListStartedAs = expansionBoolList.Count;
					for( int i = sizeBoolListStartedAs; i > list.arraySize; i-- )
						expansionBoolList.RemoveAt( i );
				}

				EditorGUI.indentLevel += 1;
                
				for( int i = 0; i < list.arraySize; i++ )
				{
					expansionBoolList[i] = ScreenTypePairInspector.Show( list.GetArrayElementAtIndex( i ), expansionBoolList[i] );
				}

				EditorGUI.indentLevel -= 1;
			}
        }
    }
    
	public static class ScreenTypePairInspector
	{      
		public static bool Show(SerializedProperty pair, bool expanded)
		{
			SerializedProperty screenType = pair.FindPropertyRelative( "type" );
            SerializedProperty screenObject = pair.FindPropertyRelative( "screenObject" );

			string foldoutName = "";
            
			if( screenType == null || screenType.objectReferenceValue == null )
				foldoutName = "No ScreenType Assigned";
			else
				foldoutName += screenType.objectReferenceValue.ToString();

			if( screenObject == null || screenObject.objectReferenceValue == null )
				foldoutName += " - No ScreenObject Assigned!";

			bool expandedToReturn = EditorGUILayout.Foldout( expanded, foldoutName );

			if( expandedToReturn )
			{
				EditorGUILayout.BeginHorizontal();

				GUILayout.Space( 20 );

				EditorGUILayout.BeginVertical();
				GUILayout.Label( "Screen Type", GUILayout.Width( 75 ) );
				EditorGUILayout.PropertyField( screenType, GUIContent.none );
				EditorGUILayout.EndVertical();

				EditorGUILayout.BeginVertical();
				GUILayout.Label( "ScreenObject", GUILayout.Width( 75 ) );
				EditorGUILayout.PropertyField( screenObject, GUIContent.none );
				EditorGUILayout.EndVertical();

				EditorGUILayout.EndHorizontal();
			}

			return expandedToReturn;
		}
	}

#endregion

	public override void OnInspectorGUI()
    {
        serializedObject.Update();

        ScreenListInspector.ShowList( serializedObject.FindProperty( "screenTypePairs" ) );

        serializedObject.ApplyModifiedProperties();
    }
}