using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PatronBehaviour : MonoBehaviour
{
    public PatronSetup ps;
    public event Action WaitingEvent;
    public event Action FightingEvent;

    private void Awake()
    {
        ps = GetComponent<PatronSetup>();
    }

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

    public void SneakAround()
    {
        //enter sneaking state
        Debug.Log("Sneaking In");
    }

    //builds aggression over time
    public IEnumerator GetAngry()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(ps.aggression);
            ps.aggression = ps.aggression + 1;
            yield return new WaitForSeconds(5);
        }
    }
}