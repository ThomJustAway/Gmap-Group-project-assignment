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

    }
    

    public override void OnInspectorGUI()
    {
        
        
        var myTestParticleSystem = (TestParticleSystem)target;
        serializedObject.Update();
        EditorGUILayout.PropertyField(particlePrefab);
        EditorGUILayout.PropertyField(particleColor);

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

        serializedObject.ApplyModifiedProperties();
    }

    
}
