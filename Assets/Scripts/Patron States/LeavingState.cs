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

    //move speed
    public float speed=10.0f;
    
    public override void Enter()
    {
        base.Enter();
    }

    public override void Execute()
    {
        base.Execute();
    }

    private void LeaveArea()
    {
        destinationLoc = GameObject.FindGameObjectWithTag("Exit");
        destination = destinationLoc.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, destination, (speed * Time.deltaTime));
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
