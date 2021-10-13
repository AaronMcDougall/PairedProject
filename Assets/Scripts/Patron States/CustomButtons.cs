using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StateBase), true)]
public class CustomButton_Editor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("ChangeState"))
        {
            ((StateBase)target).GetComponent<StateManager>().ChangeState((StateBase)target);
        }
            

        /*base.OnInspectorGUI();

        if (GUILayout.Button("Begin"))
        {
            (target as StateBase)?.Enter();

        }
        if (GUILayout.Button("Execute"))
        {
            (target as StateBase)?.Execute();

        }
        if (GUILayout.Button("Exit"))
        {
            (target as StateBase)?.Exit();

        }*/
    }
}
