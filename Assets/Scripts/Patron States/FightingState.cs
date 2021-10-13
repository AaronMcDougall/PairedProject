using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FightingState : StateBase
{
    public GameObject Fight;
    public StateBase finishFightingState;
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Fight");
        //if (gameObject.tag == "Fight")
        {
            //Fight.gameObject.SetActive(true);
        }
        Fight.SetActive(!Fight.activeInHierarchy);
        AggressionThreshold();

    }
       

    public override void Execute()
    {
        base.Execute();
        Debug.Log("Excecute Fight");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Fight Exit");
        //if (gameObject.tag == "Fight")
        {
            //Fight.gameObject.SetActive(false);
        }
        Fight.SetActive(!Fight.activeInHierarchy);
        //GetComponent<StateManager>().ChangeState(finishFightingState);
    }

    public void AggressionThreshold()
    {
        

    }
}
