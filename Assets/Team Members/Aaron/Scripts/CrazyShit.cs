using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//honestly don't worry about this script just yet, I was considering making it an overall patron movement script
public class CrazyShit : MonoBehaviour
{
    private Rigidbody rb;
    
    public GameObject destinationLoc;

    private Vector3 destination;

    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        destinationLoc = GameObject.Find("Waypoint1");
        destination = destinationLoc.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, (speed * Time.deltaTime));
    }
}