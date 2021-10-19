using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class FightingState : StateBase
{
    public StateBase finishFightingState;
    public GameObject target;
    public AudioSource swipeSound;
    public event Action GoToBouncerEvent;
    public event Action SwipeEvent;

    public bool inRange;
    
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Fight");
        
        GoToBouncerEvent?.Invoke();
    }
       

    public override void Execute()
    {
        base.Execute();
        
        //need to find target
        target = GameObject.Find("Player");

        Debug.Log("Excecute Fight");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Fight Exit");
    }

    //deals damage to player every (3) seconds as long as the target (player) has health
    IEnumerator FightSequence()
    {
        for (int i = 0; i < target.GetComponent<Health>().currentHealth; i++)
        {
            if (inRange)
            {
                target.GetComponent<Health>().TakeDamage(10);
                SwipeEvent?.Invoke();
                Debug.Log("Hit");
            }
            yield return new WaitForSeconds(3);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = true;
            StartCoroutine(FightSequence());
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = false;
            StopCoroutine(FightSequence());
        }
    }
    
    
}
