using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultState : StateBase
{
    public GameObject Default;
    public override void Enter()
    {
        Debug.Log("Default Enter");
        //if(gameObject.tag=="Default")
        {
            //Default.gameObject.SetActive(true);
        }
        Default.SetActive(!Default.activeInHierarchy);
    }

    public override void Execute()
    {
        Debug.Log("Default Execute");
    }

    public override void Exit()
    {
        Debug.Log("Default Exit");
        //if (gameObject.tag == "Default")
        {
           // Default.gameObject.SetActive(false);
        }
        Default.SetActive(!Default.activeInHierarchy);
        GetComponent<StateManager>().ChangeState(newState);
    }

}
