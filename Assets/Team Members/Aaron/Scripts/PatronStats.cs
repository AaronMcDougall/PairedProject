using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronStats : MonoBehaviour
{
    public int patience;
    public int aggression;
    public int deviance;
    
    // Start is called before the first frame update
    void Awake()
    {
        patience = Random.Range(0, 100);
        aggression = Random.Range(0, 100);
        deviance = Random.Range(0, 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
