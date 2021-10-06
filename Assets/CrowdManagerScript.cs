using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdManagerScript : MonoBehaviour
{
    public List<GameObject> patronList;

    private PatronSpawner spawner;

    public PatronSetup ps;

    public int capacity;
    public int space;
    public float crowdAggression;
    public int patronAggression;
    
    // Start is called before the first frame update
    void Start()
    {
        spawner = GetComponent<PatronSpawner>();
        ps = GetComponent<PatronSetup>();
        patronList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (patronList.Count < (capacity - space))
        {
            spawner.TrickleSpawn(space);
        }
    }
}