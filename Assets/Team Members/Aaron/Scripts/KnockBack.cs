using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        FindObjectOfType<PlayerMovement>().KnockbackEvent += Knockback;
    }
    private void OnDisable()
    {
        FindObjectOfType<PlayerMovement>().KnockbackEvent -= Knockback;
    }

    void Knockback()
    {
        var v = transform.forward;
        v.y = 0;
        v.Normalize();
    }
}
