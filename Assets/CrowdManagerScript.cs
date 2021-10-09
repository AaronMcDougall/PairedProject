using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using NodeCanvas.Tasks.Actions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.iOS;
using Random = UnityEngine.Random;

public class CrowdManagerScript : MonoBehaviour
{
    public List<GameObject> patronList;

    private PatronSpawner spawner;

    public PatronSetup ps;

    public int maxCapacity;
    public int capacity;
    public int space;
    public int timer;
    public float crowdAggression;
    public int patronAggression;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GetComponent<PatronSpawner>();
        ps = GetComponent<PatronSetup>();
        patronList = new List<GameObject>();

        InvokeRepeating("CreateSpace", 2f, 5f);
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
    }
}