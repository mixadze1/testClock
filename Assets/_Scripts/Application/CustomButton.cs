using UnityEngine;
using UnityEditor;
using Assets._Scripts.Application.Data;

#if UNITY_EDITOR
[CustomEditor(typeof(SavesHandler))]
    public class CustomButton : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            SavesHandler savesHandler = (SavesHandler)target;
            if (GUILayout.Button("DeleteAllSaves"))
            {
                savesHandler.DeleteSaves();
            }
        }
    }
#endif