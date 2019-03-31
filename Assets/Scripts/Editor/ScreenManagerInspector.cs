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

		private static SerializedProperty typePairList = null;

		public static void ShowList( SerializedProperty list )
        {
			//Saving the list so we can later check whether any ScreenTypes are occurring more than once.
			typePairList = list;
			
			EditorGUILayout.PropertyField( list );

			if( list.isExpanded )
			{            
				EditorGUILayout.PropertyField( list.FindPropertyRelative( "Array.size" ) );

                //This keeps a list of bools that keep track of which ScreenTypePair list items are expanded.
				//Here, we're adjusting the length of the bool list to match the ScreenTypePair list length.
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
					expansionBoolList[i] = ShowTypeObjectPair( list.GetArrayElementAtIndex( i ), expansionBoolList[i] );
				}

				EditorGUI.indentLevel -= 1;
			}
        }

		public static bool ShowTypeObjectPair( SerializedProperty pair, bool expanded )
        {
            SerializedProperty screenType = pair.FindPropertyRelative( "type" );
            SerializedProperty screenObject = pair.FindPropertyRelative( "screenObject" );

            //Edit the label of the foldout item to reflect its contents.
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

                EditorGUI.BeginChangeCheck();
				Object previousScreenTypeObject = screenType.objectReferenceValue;

                EditorGUILayout.PropertyField( screenType, GUIContent.none );
                if( EditorGUI.EndChangeCheck() )
                {
					//If the screen type is already in the list elsewhere, undo the change and show a dialog to explain why.
					if( IsScreenTypeAlreadyInList( screenType ) )
					{
						screenType.objectReferenceValue = previousScreenTypeObject;
						EditorUtility.DisplayDialog( "Can't add this ScreenType!", 
						                            "This screen type is already being used elsewhere. Please make another screen type (Create>Screen Type) or change this to an unused screen type.", 
						                            "OK" );
					}
                }

                EditorGUILayout.EndVertical();

                EditorGUILayout.BeginVertical();
                GUILayout.Label( "ScreenObject", GUILayout.Width( 75 ) );
                EditorGUILayout.PropertyField( screenObject, GUIContent.none );
                EditorGUILayout.EndVertical();

                EditorGUILayout.EndHorizontal();
            }

            return expandedToReturn;
        }

		private static bool IsScreenTypeAlreadyInList(SerializedProperty screenTypeToCheckFor)
		{
			int numOfTimesTypeIsInList = 0;
			
			for( int i = 0; i < typePairList.arraySize; i++ )
			{
				if( typePairList.GetArrayElementAtIndex( i ).FindPropertyRelative( "type" ) != null && typePairList.GetArrayElementAtIndex( i ).FindPropertyRelative( "type" ).objectReferenceValue != null )
				{
					if( typePairList.GetArrayElementAtIndex( i ).FindPropertyRelative( "type" ).objectReferenceValue == screenTypeToCheckFor.objectReferenceValue )
					{
						numOfTimesTypeIsInList++;
					}
				}
			}

            //If it's in the list more than once, the screen type is being used somewhere other than the place it's just been entered.
			return ( numOfTimesTypeIsInList > 1 );
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