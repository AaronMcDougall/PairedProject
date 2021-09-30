using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PatronBehaviour : MonoBehaviour
{
    public event Action WaitingEvent;
    public bool atWaypoint = false;
    
    public void WaitInLine()
    {
        //enter waiting state
        Debug.Log("Waiting in Line");
        WaitingEvent?.Invoke();
    }

    public void Fight()
    {
        //enter fighting state
        Debug.Log("Starting a Fight");
    }

    public void SneakAround()
    {
        //enter sneaking state
        Debug.Log("Sneaking In");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Waypoint>())
        {
            atWaypoint = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Waypoint>())
        {
            atWaypoint = false;
        }
    }
}
