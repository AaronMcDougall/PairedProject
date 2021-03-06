using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class MoveSideways : MonoBehaviour
{
    public Rigidbody rb;
    
    public float raycastDistance = 20f;
    public float turn;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, raycastDistance))
        {
            rb.AddRelativeTorque(0, (turn), 0 );
        }
        
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.yellow);
    }
}
