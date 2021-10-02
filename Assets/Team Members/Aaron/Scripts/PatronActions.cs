using System;
using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Tasks.Actions;
using Unity.VisualScripting;
using UnityEngine;

public class PatronActions : MonoBehaviour
{
    public GameObject target;
    public AudioSource swipeSound;

    public bool fighting = false;
    public bool inRange = false;

    private void Start()
    {
        swipeSound = GetComponent<AudioSource>();
    }
    
    //starts fighting when in collider of player
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("In Range to fight");
            inRange = true;
            target = other.gameObject;
            StartCoroutine(FightSequence());
        }
    }

    //stops fighting when out of range
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerModel>())
        {
            inRange = false;
            target = null;
        }
    }

    //deals damage to player every (3) seconds as long as the target (player) has health
    IEnumerator FightSequence()
    {
        for (int i = 0; i < target.GetComponent<Health>().currentHealth; i++)
        {
            if (inRange)
            {
                target.GetComponent<Health>().TakeDamage(10);
                swipeSound.Play();
                Debug.Log("Hit");
            }
            yield return new WaitForSeconds(3);
        }
    }
}
