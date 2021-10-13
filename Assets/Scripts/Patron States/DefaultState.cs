using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DefaultState : StateBase
{
    public StateBase finishDefaultState;

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Default Enter");
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
    }

    
}
