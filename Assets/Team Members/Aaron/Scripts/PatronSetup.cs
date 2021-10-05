using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PatronSetup : MonoBehaviour
{
    private CrowdManagerScript cm;
    private PatronBehaviour pb;
    
    public int patience;
    public int aggression;
    public int deviance;

    private void Start()
    {
        cm = GetComponent<CrowdManagerScript>();
    }

    //determines and assigns random values to all three stats on spawn
    void Awake()
    {
        pb = GetComponent<PatronBehaviour>();

        patience = Random.Range(0, 100);
        aggression = Random.Range(0, 100);
        deviance = Random.Range(0, 100);
        
        //start coroutine to build aggression from awake
        StartCoroutine(pb.GetAngry());
    }
}
