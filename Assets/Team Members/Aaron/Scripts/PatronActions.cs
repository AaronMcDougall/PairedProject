using System;
using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Tasks.Actions;
using Unity.VisualScripting;
using UnityEngine;

public class PatronActions : MonoBehaviour
{
    private Health health;
    private PatronSetup ps;
    private GoToPoint movement;
    public GameObject target;
    public AudioSource swipeSound;

    public bool inRange = false;
    public bool knockedDown = false;

    private void Start()
    {
        swipeSound = GetComponent<AudioSource>();
        movement = GetComponent<GoToPoint>();
        ps = GetComponent<PatronSetup>();
        health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        FindObjectOfType<Health>().DeathEvent += KnockedDown;
    }

    void KnockedDown()
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

        knockedDown = false;
        ResetPatron();
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