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
    public AudioSource audioSource;
    public AudioClip leavingSpeech;

    public CrowdManagerScript cm;
    
    public override void Enter()
    {
        base.Enter();
        cm = FindObjectOfType<CrowdManagerScript>();
        audioSource.clip = leavingSpeech;
        audioSource.Play();
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
            cm.PatronList.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
