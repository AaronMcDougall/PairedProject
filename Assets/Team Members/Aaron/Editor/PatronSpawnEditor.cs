using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(PatronSpawner))]
public class PatronSpawnEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Spawn Patrons"))
        {
            ((PatronSpawner)target)?.SpawnPatrons();
        }
    }
    
}
