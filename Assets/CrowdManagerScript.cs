using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using NodeCanvas.Tasks.Actions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.iOS;
using Random = UnityEngine.Random;
using UnityEngine.Events;

public class CrowdManagerScript : MonoBehaviour
{
    public List<GameObject> patronList;

    private PatronSpawner spawner;
    public PatronSetup ps;

    public event Action RiotEvent;

    public int aggressionThreshold;
    
    public int maxCapacity;
    public int capacity;
    public int space;
    public float crowdAggression;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GetComponent<PatronSpawner>();
        ps = GetComponent<PatronSetup>();
        patronList = new List<GameObject>();

        InvokeRepeating("CreateSpace", 2f, 10f);
    }

    void CreateSpace()
    {
        space = Random.Range(5, 8);
        capacity = capacity - space;
    }

    public void Update()
    {
        //I'm hoping that introducing a method of admitting Patrons will help sort this out.
        //As patrons are admitted they will be removed from the list, thus the need to spawn more will arise.
        if (spawner.PatronList.Count < maxCapacity)
        {
            int difference = maxCapacity - spawner.PatronList.Count;
            spawner.TrickleSpawn(difference);
        }

        if (patronList.Count > 0)
        {
            GetCrowdAggression();
        }
    }

    void GetCrowdAggression()
    {
        int totalAggression = 0;
        
        foreach (var patron in patronList)
        {
            totalAggression += patron.GetComponent<PatronSetup>().aggression;
        }

        crowdAggression = totalAggression / patronList.Count;

        if (crowdAggression > aggressionThreshold)
        {
            RiotEvent?.Invoke();
        }
    }

    void ClearPatronList()
    {
        patronList.Clear();
    }
}