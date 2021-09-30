using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPoint : MonoBehaviour
{
    public float speed = 10f;

    public GameObject destinationLoc;
    public Vector3 destination;

    void Start()
    {
        destination = destinationLoc.transform.position;
    }
    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, (speed * Time.deltaTime));
    }
}
