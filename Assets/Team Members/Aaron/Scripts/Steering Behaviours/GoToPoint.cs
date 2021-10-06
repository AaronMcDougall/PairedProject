using System;
using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Tasks.Actions;
using UnityEngine;
using Object = System.Object;

public class GoToPoint : MonoBehaviour
{
    //whichever point to go to (bouncer or waypoint)
    public GameObject destinationLoc;
    public Vector3 destination;

    //movement speed
    public float speed = 10f;

    public bool agro = false;

    //finds first waypoint to go to if not agro
    void Start()
    {
        destinationLoc = GameObject.FindGameObjectWithTag("Waypoint");
        destination = destinationLoc.transform.position;
    }

    //checks to see aggression level (via bool); acts accordingly. Would love to have this in the behaviour tree,
    //but can't find how to FixedUpdate() it in there
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

    //moves to (nearest) bouncer
    public void GoToBouncer()
    {
        agro = true;
        destinationLoc = GameObject.FindGameObjectWithTag("Player");
        destination = destinationLoc.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, destination, (speed * Time.deltaTime));
    }

    //moves to waiting (nearest) waypoint
    public void GoToWaypoint()
    {
        destinationLoc = GameObject.FindGameObjectWithTag("Waypoint");
        destination = destinationLoc.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, destination, (speed * Time.deltaTime));
    }

    /*//moves to goal
    public void GoToGoal()
    {
        destinationLoc = GameObject.FindGameObjectWithTag("Finish");
        destination = destinationLoc.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, destination, (speed * Time.deltaTime));
    }*/
}