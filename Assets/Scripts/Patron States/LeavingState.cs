using System;
using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Tasks.Actions;
using UnityEngine;

public class LeavingState : StateBase
{
    //move speed
    public float speed=10.0f;
    public event Action GoToExitEvent;

    public CrowdManagerScript cm;
    
    public override void Enter()
    {
        base.Enter();
        cm = FindObjectOfType<CrowdManagerScript>();
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
            cm.patronList.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
