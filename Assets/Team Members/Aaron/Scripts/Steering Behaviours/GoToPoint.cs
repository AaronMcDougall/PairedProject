using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class GoToPoint : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 myPos;

    public GameObject destinationLoc;
    public Vector3 destination;

    private void OnEnable()
    {
        FindObjectOfType<PatronBehaviour>().FightingEvent += FightingAction;
    }

    void Start()
    {
        destination = destinationLoc.transform.position;
        myPos = transform.position;
    }
    
    void Update()
    {
        myPos = Vector3.MoveTowards(transform.position, destination, (speed * Time.deltaTime));
        
    }

    void FightingAction()
    {
        
    }
}
