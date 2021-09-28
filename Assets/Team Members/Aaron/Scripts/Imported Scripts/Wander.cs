using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Wander : MonoBehaviour
{
    public Rigidbody rb;

    public float turn;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        turn = Mathf.PerlinNoise(0, Time.time) * 2 -1;
        
        rb.AddRelativeTorque(0,turn,0 );
    }
}
