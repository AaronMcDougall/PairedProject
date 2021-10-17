using System;
using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Tasks.Actions;
using UnityEngine;

public class LeavingState : StateBase
{
    //the location of moving to the exit for the patrons
    private GoToPoint exit;
    public GameObject destinationLoc;
    public Vector3 destination;

    private PatronSetup ps;
    public bool isLeaving = false;

    //move speed
    public float speed=10.0f;
    
    public event Action GoToExitEvent;
    
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Enter.LeavingState");
        //ps = GetComponent<PatronSetup>();
        isLeaving = true;
        GoToExitEvent?.Invoke();
    }

    public override void Execute()
    {
        base.Execute();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Exit"))
        {
            Destroy(GameObject.FindWithTag("Patron"));
        }
    }
    
    public override void Exit()
    {
        base.Exit();
    }
}
