using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



[CustomEditor(typeof(TestParticleSystem))]
[CanEditMultipleObjects]
public class TestParticleSystemEditor : Editor
{

    SerializedProperty particlePrefab;
    SerializedProperty particleColor;

    SerializedProperty numberOfParticles;
    SerializedProperty randomSpeed;
    SerializedProperty minSpeed, maxSpeed;
    SerializedProperty particleSpeed;
    SerializedProperty interval;
    SerializedProperty randomSpawnPosition;

    SerializedProperty objectPool;

    SerializedProperty start;
   



    private void OnEnable()
    {
        particlePrefab = serializedObject.FindProperty("particlePrefab");
        particleColor = serializedObject.FindProperty("particleColor");
        numberOfParticles = serializedObject.FindProperty("numberOfParticles");
        randomSpeed = serializedObject.FindProperty("randomSpeed");
        particleSpeed = serializedObject.FindProperty("particleSpeed");
        interval = serializedObject.FindProperty("interval");
        minSpeed = serializedObject.FindProperty("minSpeed");
        maxSpeed = serializedObject.FindProperty("maxSpeed");
        objectPool = serializedObject.FindProperty("objectPool");
        randomSpawnPosition = serializedObject.FindProperty("randomSpawnPosition");
        start = serializedObject.FindProperty("start");

    }
    

    public override void OnInspectorGUI()
    {
        
        
        var myTestParticleSystem = (TestParticleSystem)target;
        serializedObject.Update();

        //particle settings layout
        EditorGUILayout.PropertyField(particlePrefab);
        EditorGUILayout.PropertyField(particleColor);
        EditorGUILayout.Space(10);

        //particle spawn layout
        EditorGUILayout.PropertyField(numberOfParticles);
        EditorGUILayout.PropertyField(randomSpeed);
        if (myTestParticleSystem.randomSpeed) 
        { 
            EditorGUILayout.PropertyField(minSpeed);
            EditorGUILayout.PropertyField(maxSpeed);
        }
        else
        {
            EditorGUILayout.PropertyField(particleSpeed);
        }
        EditorGUILayout.PropertyField(interval);
        EditorGUILayout.PropertyField(randomSpawnPosition);
        EditorGUILayout.Space(10);


        //Object pooling settings layout
        EditorGUILayout.PropertyField (objectPool);
        EditorGUILayout.Space(35);


        //buttons to start the particle system
        if (GUILayout.Button("Start!"))
        {
            start.boolValue = true;
        }
        

        serializedObject.ApplyModifiedProperties();
    }

    
}
