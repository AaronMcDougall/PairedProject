using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PatientState : StateBase
{
    public event Action GoToWaitingEvent;
    public override void Enter()
    {
        GoToWaitingEvent?.Invoke();
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
