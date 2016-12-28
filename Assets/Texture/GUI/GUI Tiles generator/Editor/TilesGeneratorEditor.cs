using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(TilesGenerator))]
[CanEditMultipleObjects]
public class TilesGeneratorEditor : Editor {
  TilesGenerator tile;
   SerializedProperty GUIprefab;
   SerializedProperty modeGen;
   SerializedProperty row;
   SerializedProperty collum;
   SerializedProperty canvas;
   SerializedProperty angle;
   SerializedProperty dist;
   SerializedProperty targetCam;
   SerializedProperty indentionX;
   SerializedProperty indentionY;
                               

    void OnEnable()
    {
        tile = (TilesGenerator)target;
        GUIprefab = serializedObject.FindProperty("Prefab");
        modeGen = serializedObject.FindProperty("modeGen");
        row = serializedObject.FindProperty("Row");
        collum = serializedObject.FindProperty("Collum");
        canvas = serializedObject.FindProperty("canvas");
        angle = serializedObject.FindProperty("angle");
        dist = serializedObject.FindProperty("dist");
        targetCam = serializedObject.FindProperty("targetCam");
        indentionX = serializedObject.FindProperty("indentionX");
        indentionY = serializedObject.FindProperty("indentionY");
                                

    }


    public override void OnInspectorGUI()
    {

        // Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
        //DrawDefaultInspector();
        serializedObject.Update();
        GUILayout.Space(20);
       
        EditorGUILayout.PropertyField(GUIprefab, new GUIContent("Prefab GUI: "));
        EditorGUILayout.PropertyField(canvas, new GUIContent("Canvas"));
        GUILayout.Space(5);
        EditorGUILayout.PropertyField(modeGen, new GUIContent("Generatation mode: "));
        GUILayout.Space(10);

        GUILayout.Label("Grid parab");
        EditorGUILayout.PropertyField(row, new GUIContent("\tRow: "));
        EditorGUILayout.PropertyField(collum, new GUIContent("\tCollum: "));
        GUILayout.Space(10);

        TilesGenerator.modeType mode = (TilesGenerator.modeType)modeGen.enumValueIndex;

        switch (mode) {
            case TilesGenerator.modeType.Round:
                EditorGUILayout.PropertyField(targetCam, new GUIContent("centr object: "));
                EditorGUILayout.PropertyField(angle, new GUIContent("angle: "));
                EditorGUILayout.PropertyField(dist, new GUIContent("dist: "));
                EditorGUILayout.PropertyField(indentionY, new GUIContent("indention y: "));
                GUILayout.Space(20);

                if (GUILayout.Button("Create Round Tiles"))
                {
                    tile.ButtonGenRoundTile();
                }
                break;

            case TilesGenerator.modeType.Straight:
                GUILayout.Label("IndentionX");
                EditorGUILayout.PropertyField(indentionX, new GUIContent("\tx: "));
                EditorGUILayout.PropertyField(indentionY, new GUIContent("\ty: "));
                EditorGUILayout.PropertyField(dist, new GUIContent("dist: "));
                GUILayout.Space(20);

                if (GUILayout.Button("Create Straight Tiles"))
                {
                    tile.ButtonGenStraightTile();
                }
                break;
        }

        if (GUILayout.Button("Clear"))
        {
            tile.DestroyTiles();
        }
    
        serializedObject.ApplyModifiedProperties();
    }

 

}
