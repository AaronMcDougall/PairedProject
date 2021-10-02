using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PatronBehaviour : MonoBehaviour
{
    private PatronSetup _patronStats;
    public event Action WaitingEvent;
    public event Action FightingEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Waypoint>())
        {
            WaitingEvent?.Invoke();
        }
    }
    
    public void WaitInLine()
    {
        //enter waiting state
        Debug.Log("Waiting in Line");
    }

    /*public void Fight()
    {
        //enter fighting state
        Debug.Log("Starting a Fight");
        FightingEvent?.Invoke();
    }*/

    public void SneakAround()
    {
        //enter sneaking state
        Debug.Log("Sneaking In");
    }



    private void OnTriggerExit(Collider other)
    {
        /*if (other.GetComponent<Waypoint>())
        {
            atWaypoint = false;
        }*/
    }
}
