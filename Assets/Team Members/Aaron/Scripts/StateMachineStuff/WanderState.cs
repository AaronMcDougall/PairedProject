using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WanderState : StateBase
{
    public Wander wander;
    public MoveForward moveforward;

    public event Action Wandering;
    
    
    public override void Enter()
    {
        Wandering?.Invoke();
    }

    public override void Execute()
    {
        
    }

    public override void Exit()
    {
        
    }
    
}
