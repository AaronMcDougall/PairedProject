using System;
using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Tasks.Actions;
using UnityEngine;
using Object = System.Object;

public class GoToPoint : MonoBehaviour
{
    public GameObject destinationLoc;
    public Vector3 destination;

    public float speed = 10f;

    public bool agro = false;

    void Start()
    {
        destinationLoc = GameObject.FindGameObjectWithTag("Waypoint");
        destination = destinationLoc.transform.position;
    }

    void FixedUpdate()
    {
        if (agro == true)
        {
            GoToBouncer();
        }
        else if (agro == false)
        {
            GoToWaypoint();
        }
    }

    void GoToBouncer()
    {
        agro = true;
        destinationLoc = GameObject.FindGameObjectWithTag("Player");
        destination = destinationLoc.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, destination, (speed * Time.deltaTime));
    }

    void GoToWaypoint()
    {
        destinationLoc = GameObject.FindGameObjectWithTag("Waypoint");
        destination = destinationLoc.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, destination, (speed * Time.deltaTime));
    }
}