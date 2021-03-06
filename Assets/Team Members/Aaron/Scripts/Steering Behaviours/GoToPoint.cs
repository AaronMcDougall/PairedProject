using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, (speed * Time.deltaTime));
    }

    private void OnEnable()
    {
        GetComponent<FightingState>().GoToBouncerEvent += GoToBouncer;
        GetComponent<PatientState>().GoToWaitingEvent += GoToWaypoint;
        GetComponent<SneakingState>().GoToSneakingEvent += GoToGoal;
        GetComponent<LeavingState>().GoToExitEvent += GoToExit;
    }
    
    private void OnDisable()
    {
        GetComponent<FightingState>().GoToBouncerEvent -= GoToBouncer;
        GetComponent<PatientState>().GoToWaitingEvent -= GoToWaypoint;
        GetComponent<SneakingState>().GoToSneakingEvent -= GoToGoal;
        GetComponent<LeavingState>().GoToExitEvent -= GoToExit;
    }

    //moves to (nearest) bouncer
    private void GoToBouncer()
    {
        destinationLoc = GameObject.FindGameObjectWithTag("Player");
        destination = destinationLoc.transform.position;
        //transform.position = Vector3.MoveTowards(transform.position, destination, (speed * Time.deltaTime));
    }

    //moves to waiting (nearest) waypoint
    private void GoToWaypoint()
    {
        destinationLoc = GameObject.FindGameObjectWithTag("Waypoint");
        destination = destinationLoc.transform.position;
        //transform.position = Vector3.MoveTowards(transform.position, destination, (speed * Time.deltaTime));
    }

    //moves to goal
    public void GoToGoal()
    {
        destinationLoc = GameObject.FindGameObjectWithTag("Finish");
        destination = destinationLoc.transform.position;
        //transform.position = Vector3.MoveTowards(transform.position, destination, (speed * Time.deltaTime));
    }

    //moves to exit / leaves club area
    public void GoToExit()
    {
        destinationLoc = GameObject.FindGameObjectWithTag("Exit");
        destination = destinationLoc.transform.position;
        //transform.position = Vector3.MoveTowards(transform.position, destination, (speed * Time.deltaTime));
    }
}