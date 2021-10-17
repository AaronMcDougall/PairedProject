using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PatronSetup : MonoBehaviour
{
    private CrowdManagerScript cm;

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
        patience = Random.Range(0, 100);
        aggression = Random.Range(0, 100);
        deviance = Random.Range(0, 100);
        
        //start coroutine to build aggression from awake
        StartCoroutine(GetAngry());
    }
    
    //builds aggression over time
    public IEnumerator GetAngry()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(aggression);
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
    
    /*private void OnEnable()
    {
        FindObjectOfType<CrowdManagerScript>().RiotEvent += Riot;
    }
    
    private void OnDisable()
    {
        FindObjectOfType<CrowdManagerScript>().RiotEvent -= Riot;
    }*/
}
