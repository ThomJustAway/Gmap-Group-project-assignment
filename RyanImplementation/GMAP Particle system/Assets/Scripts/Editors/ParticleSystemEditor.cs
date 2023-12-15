using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



[CustomEditor(typeof(ParticleSystem))]
[CanEditMultipleObjects]
public class ParticleSystemEditor : Editor
{

    SerializedProperty lifespan;
    SerializedProperty moveSpeed;

    SerializedProperty numberOfParticles;
    SerializedProperty interval;
    SerializedProperty randomSpawnPosition;

    

    SerializedProperty start;


    SerializedProperty moveForward;

    SerializedProperty prefab;
    SerializedProperty amountToPool;

    SerializedProperty objectPoolCheck;
    



   



    private void OnEnable()
    {
        
        lifespan = serializedObject.FindProperty("lifespan");
        numberOfParticles = serializedObject.FindProperty("numberOfParticles");
        
        interval = serializedObject.FindProperty("interval");
     
        randomSpawnPosition = serializedObject.FindProperty("randomSpawnPosition");
        start = serializedObject.FindProperty("start");
        moveForward = serializedObject.FindProperty("moveForward");
        moveSpeed = serializedObject.FindProperty("moveSpeed");
        prefab = serializedObject.FindProperty("prefab");
        amountToPool = serializedObject.FindProperty("amountToPool");

        objectPoolCheck = serializedObject.FindProperty("objectPoolCheck");


    }
    

    public override void OnInspectorGUI()
    {
        
        
        var myParticleSystem = (ParticleSystem)target;
        serializedObject.Update();

        //particle settings layout
        EditorGUILayout.PropertyField(prefab);
        EditorGUILayout.PropertyField(lifespan);
        EditorGUILayout.Space(10);

        //particle spawn layout
        EditorGUILayout.PropertyField(numberOfParticles);
        EditorGUILayout.PropertyField(interval);
        EditorGUILayout.PropertyField(randomSpawnPosition);
        EditorGUILayout.Space(10);


        //Object pooling settings layout
        EditorGUILayout.PropertyField(amountToPool);
        EditorGUILayout.PropertyField(objectPoolCheck);

        EditorGUILayout.Space(10);


        //Particles moving to specified location
        EditorGUILayout.PropertyField(moveForward);
        if (myParticleSystem.moveForward)
        {
            EditorGUILayout.PropertyField(moveSpeed);
        }
        EditorGUILayout.Space(35);

        //buttons to start the particle system
        if (GUILayout.Button("Start!"))
        {
            start.boolValue = true;
        }
       
        

        serializedObject.ApplyModifiedProperties();
    }

    
}
