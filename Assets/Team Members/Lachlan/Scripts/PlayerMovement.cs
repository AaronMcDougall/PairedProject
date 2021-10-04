using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerMovement : MonoBehaviour
{
    //public InputAction MovementAction;
    //public InputActionMap gameplayActions;

    public float speed;
    public float rotationSpeed;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

            PlayerControls playerControls = new PlayerControls();
            playerControls.Movement.Enable();

        //Player Movement WASD
            playerControls.Movement.Forward.performed += UpOnperformed;
            playerControls.Movement.Right.performed += RightOnperformed;
            playerControls.Movement.Backward.performed += BackwardOnperformed;
            playerControls.Movement.Left.performed += LeftOnperformed;
        
        //MovementAction.Enable();

    }


    void UpOnperformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Up");
        rb.AddRelativeForce(new Vector3(0, 0, 1) * speed);
        obj.ReadValue<Vector2>();
    }

    void RightOnperformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Right");
        rb.AddRelativeForce(new Vector3(1, 0, 0) * speed);
    }

    void BackwardOnperformed(InputAction.CallbackContext obj)
    {
        rb.AddRelativeForce(new Vector3(0, 0, -1) * speed);
    }

    void LeftOnperformed(InputAction.CallbackContext obj)
    {
        rb.AddRelativeForce(new Vector3(-1, 0, 0) * speed);
    }

    void Rotation(Vector3 movement)
    {
        //Turn (non-physics) based on 'x' input by player
        this.transform.Rotate(new Vector3(0, movement.x, 0) * rotationSpeed, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
