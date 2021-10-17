using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockedDownState : StateBase
{
    private Health health;
    private PatronSetup ps;
    private GoToPoint movement;

    public bool knockedDown = false;

    public override void Enter()
    {
        base.Enter();
        movement = GetComponent<GoToPoint>();
        ps = GetComponent<PatronSetup>();
        health = GetComponent<Health>();
    }

    public override void Execute()
    {
        base.Execute();
    }

    public override void Exit()
    {
        base.Exit();
    }

    private void OnEnable()
    {
        FindObjectOfType<Health>().DeathEvent += KnockedDown;
    }

    private void KnockedDown()
    {
        if (health.currentHealth == 0)
        {
            knockedDown = true;
            StartCoroutine(KnockDownSequence());
        }
    }

    //knocks player over, halts movement, then fires restoring function
    IEnumerator KnockDownSequence()
    {
        for (int i = 0; i < 5; i++)
        {
            if (knockedDown)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                movement.enabled = false;
                yield return new WaitForSeconds(1);
            }
        }

        CheckAction();
        knockedDown = false;
        ResetPatron();
    }

    private void CheckAction()
    {
        int leaveCheck = Random.Range(0, 99);
        if (leaveCheck < 49)
        {
            ResetPatron();
        }
        else
        {
            GetComponent<StateManager>().Leaving();
        }
        
    }
    //resets rotation, restores movement; resets health
    void ResetPatron()
    {
        float aggression = GetComponent<PatronSetup>().aggression;
        ps.aggression = ps.aggression + 5;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        movement.enabled = true;
        Health health = GetComponent<Health>();
        health.AddHealth(20);
    }
}