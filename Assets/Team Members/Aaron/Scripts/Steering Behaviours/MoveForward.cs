using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10f;
    private Vector3 thisPos;

    private bool wandering = true;
    private void OnEnable()
    {
        FindObjectOfType<PatronBehaviour>().WaitingEvent += WaitInLine;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wandering)
        {
            rb.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        else
        {
            thisPos = transform.position;
        }
    }
        

    void WaitInLine()
    {
        wandering = false;
    }
}