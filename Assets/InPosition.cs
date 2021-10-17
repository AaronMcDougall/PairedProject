using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InPosition : MonoBehaviour
{
    public bool inPosition;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeBool()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inPosition = true;
        }
    }
    
    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inPosition = false;
        }
    }
}
