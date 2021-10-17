using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PatronBehaviour : MonoBehaviour
{
    private StateManager stateManager;
    public PatronSetup ps;
    public event Action WaitingEvent;


    private void Awake()
    {
        ps = GetComponent<PatronSetup>();
        stateManager = GetComponent<StateManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Waypoint>())
        {
            WaitingEvent?.Invoke();
        }
    }

    

    
}