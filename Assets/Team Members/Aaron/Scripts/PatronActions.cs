using System;
using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Tasks.Actions;
using Unity.VisualScripting;
using UnityEngine;

public class PatronActions : MonoBehaviour
{
    private void OnEnable()
    {
        FindObjectOfType<PatronBehaviour>().FightingEvent += FightingAction;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FightingAction()
    {
        //fighting things in here
        //coroutine to attack every few seconds?
    }
}
