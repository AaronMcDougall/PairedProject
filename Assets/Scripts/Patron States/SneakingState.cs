using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SneakingState : StateBase
{
    public event Action GoToSneakingEvent;
    public override void Enter()
    {
        GoToSneakingEvent?.Invoke();
        base.Enter();
    }

    public override void Execute()
    {
        base.Execute();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
