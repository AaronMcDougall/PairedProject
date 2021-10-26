using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarInput : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    Vector3 localVelocity;
    
    private bool Forward;
    private bool Backward;
    private bool Right;
    private bool Left;
    private bool LookLeft;
    private bool LookRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        localVelocity = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        Forward = InputSystem.GetDevice<Keyboard>().upArrowKey.isPressed;
        Backward = InputSystem.GetDevice<Keyboard>().downArrowKey.isPressed;
        Right = InputSystem.GetDevice<Keyboard>().rightArrowKey.isPressed;
        Left = InputSystem.GetDevice<Keyboard>().leftArrowKey.isPressed;

        //Rotation
        LookLeft=InputSystem.GetDevice<Keyboard>().aKey.isPressed;
        LookRight=InputSystem.GetDevice<Keyboard>().dKey.isPressed;


        //var MoveForward = InputSystem.GetDevice<Keyboard>().upArrowKey.isPressed;
        //Input.GetButtonDown($"W");
        //Forward();
        MoveForward();
        MoveDownward();
        MoveLeft();
        MoveRight();
        LookRotation();
    }

    void MoveForward()
    {
        if (Forward == true)
        {
            rb.AddRelativeForce(new Vector3(0, 0, 1) * speed);
            //frictional force
            rb.AddRelativeForce(new Vector3(0, 0, -1) * speed/2);
        }
    }

    void MoveDownward()
    {
        if (Backward == true)
        {
            rb.AddRelativeForce(new Vector3(0, 0, -1) * speed);
            rb.AddRelativeForce(new Vector3(0, 0, -1) * speed/2);
        }
    }

    void MoveRight()
    {
        if (Right == true)
        {
            rb.AddRelativeForce(new Vector3(1, 0, 0) * speed);
            rb.AddRelativeForce(new Vector3(0, 0, -1) * speed/2);
        }
    }

    void MoveLeft()
    {
        if (Left == true)
        {
            rb.AddRelativeForce(new Vector3(-1, 0, 0) * speed);
            rb.AddRelativeForce(new Vector3(0, 0, -1) * speed/2);
        }
    }

    void LookRotation()
    {
        if (LookLeft == true)
        {
            rb.AddRelativeTorque(0,-1,0);
        }
        if (LookRight == true)
        {
            rb.AddRelativeTorque(0,1,0);
        }
    }
}

