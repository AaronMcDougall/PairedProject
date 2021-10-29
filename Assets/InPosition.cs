using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InPosition : MonoBehaviour
{
    public bool inPosition;

    public event Action outOfPositionEvent;
    public event Action inPositionEvent;


    void ChangeBool()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inPosition = true;
            inPositionEvent?.Invoke();

        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inPosition = false;
            outOfPositionEvent?.Invoke();
        }
    }
}
