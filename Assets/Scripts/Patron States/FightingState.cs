using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingState : StateBase
{
    public GameObject Fight;
    public override void Enter()
    {
        Debug.Log("Fight");
        //if (gameObject.tag == "Fight")
        {
            //Fight.gameObject.SetActive(true);
        }
        Fight.SetActive(!Fight.activeInHierarchy);

    }
       

    public override void Execute()
    {
        Debug.Log("Excecute Fight");
    }

    public override void Exit()
    {
        Debug.Log("Fight Exit");
        //if (gameObject.tag == "Fight")
        {
            //Fight.gameObject.SetActive(false);
        }
        Fight.SetActive(!Fight.activeInHierarchy);
    }
}
