using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction MovementAction;
    //public InputActionMap gameplayActions;

    // Start is called before the first frame update
    void Start()
    {
        
        
            PlayerControls playerControls = new PlayerControls();
            playerControls.Movement.Enable();

            //playerControls.Movement.Up.performed += UpOnperformed;
            //playerControls.Movement.Right.performed += RightOnperformed;
        
        //MovementAction.Enable();

    }


    void UpOnperformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Up");
    }

    void RightOnperformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Right");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            print("W pressed");

        }
    }
}
