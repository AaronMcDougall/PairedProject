using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DefaultState : StateBase
{
    public GameObject Default;
    public StateBase finishDefaultState;

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Default Enter");
        //if(gameObject.tag=="Default")
        {
            //Default.gameObject.SetActive(true);
        }
        Default.SetActive(!Default.activeInHierarchy);
        
    }

    public override void Execute()
    {
        base.Execute();
        Debug.Log("Default Execute");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Default Exit");
        //if (gameObject.tag == "Default")
        {
           // Default.gameObject.SetActive(false);
        }
        Default.SetActive(!Default.activeInHierarchy);
        //GetComponent<StateManager>().ChangeState(finishDefaultState);
        
    }

}
