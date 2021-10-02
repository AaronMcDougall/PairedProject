using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PatronSetup : MonoBehaviour
{
    private List<GameObject> PatronList;
    
    public int patience;
    public int aggression;
    public int deviance;

    private void Start()
    {
        List<GameObject> PatronList = new List<GameObject>();
    }

    // Start is called before the first frame update
    void Awake()
    {
        patience = Random.Range(0, 100);
        aggression = Random.Range(0, 100);
        deviance = Random.Range(0, 100);
        
        PatronList.Add(this.GameObject());
        
        //start coroutine to build aggression from awake
    }
}
