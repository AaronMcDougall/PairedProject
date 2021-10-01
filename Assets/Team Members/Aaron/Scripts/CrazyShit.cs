using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyShit : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject destinationLoc;

    private Vector3 destination;
    public bool goTo;

    public float turn;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        destination = destinationLoc.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (goTo)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, (speed * Time.deltaTime));
        }

        else
        {
            rb.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.VelocityChange);
            turn = Mathf.PerlinNoise(0, Time.time) * 2 -1;
            rb.AddRelativeTorque(0,turn,0 );
        }
    }

    private void OnEnable()
    {
        FindObjectOfType<PatronBehaviour>().WaitingEvent += ChangeBool;
    }

    private void ChangeBool()
    {
        StartCoroutine(WanderAround());
    }

    IEnumerator WanderAround()
    {
        //change bool, start 5 second countdown, change bool back
        yield return new WaitForSeconds(3);
    }
}
