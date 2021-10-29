using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PatronSetup : MonoBehaviour
{ 
    public int patience;
    public int aggression;
    public int deviance;

    public bool inPosition;

    //determines and assigns random values to all three stats on spawn
    void Awake()
    {
        patience = Random.Range(10, 100);
        aggression = Random.Range(0, 75);
        deviance = Random.Range(30, 45);

        //start coroutine to build aggression from awake
        StartCoroutine(GetAngry());
    }

    //builds aggression over time
    public IEnumerator GetAngry()
    {
        for (int i = 0; i < 10; i++)
        {
            aggression = aggression + 1;
            yield return new WaitForSeconds(5);
        }
    }

    void Riot()
    {
        aggression = 100;
        deviance = 100;
        StopCoroutine(GetAngry());
    }

    void NeutralStats()
    {
        patience = 0;
        aggression = 0;
        deviance = 0;
        StopCoroutine(GetAngry());
    }

    void WayBlocked()
    {
        inPosition = true;
    }

    void WayClear()
    {
        inPosition = false;
    }
    
    private void OnEnable()
    {
        GetComponent<LeavingState>().GoToExitEvent += NeutralStats;
        FindObjectOfType<CrowdManagerScript>().RiotEvent += Riot;
        FindObjectOfType<InPosition>().inPositionEvent += WayBlocked;
        FindObjectOfType<InPosition>().outOfPositionEvent += WayClear;
    }

    private void OnDisable()
    {
        GetComponent<LeavingState>().GoToExitEvent -= NeutralStats;
        FindObjectOfType<CrowdManagerScript>().RiotEvent -= Riot;
    }
}