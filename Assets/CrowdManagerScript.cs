using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using NodeCanvas.Tasks.Actions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.iOS;
using Random = UnityEngine.Random;
using UnityEngine.Events;

public class CrowdManagerScript : MonoBehaviour
{
    public List<GameObject> PatronList;

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
        PatronList = new List<GameObject>();

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
        if (PatronList.Count < maxCapacity)
        {
            var difference = maxCapacity - PatronList.Count;
            spawner.TrickleSpawn(difference);
        }

        if (PatronList.Count > 0)
        {
            GetCrowdAggression();
        }
    }

    void GetCrowdAggression()
    {
        int totalAggression = 0;
        
        foreach (var patron in PatronList)
        {
            totalAggression += patron.GetComponent<PatronSetup>().aggression;
        }

        crowdAggression = totalAggression / PatronList.Count;

        if (crowdAggression > aggressionThreshold)
        {
            RiotEvent?.Invoke();
        }
    }

    void ClearPatronList()
    {
       PatronList.Clear();
    }
}