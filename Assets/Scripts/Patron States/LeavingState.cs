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
    public CrowdManagerScript cm;

    //move speed
    public float speed=10.0f;
    
    public event Action GoToExitEvent;

    public override void Enter()
    {
        base.Enter();
        cm = GetComponent<CrowdManagerScript>();
        GoToExitEvent?.Invoke();
    }

    public override void Execute()
    {
        base.Execute();
    }
    
    public override void Exit()
    {
        base.Exit();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Exit"))
        {
            //need to sort this out, ref to cm keeps resetting to nothing?
            //cm.patronList.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
