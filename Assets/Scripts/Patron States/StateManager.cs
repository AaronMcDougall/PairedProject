using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{

    public StateBase currentState;

    public StateBase newState;

    void Update()
    {
        UpdateCurrentState();
    }

    void UpdateCurrentState()
    {
        currentState?.Execute();
    }

    public void ChangeState(StateBase newState)
    {
        if (currentState !=null)
        {
            currentState.Exit();
        }
        if(newState!=null)
        {
            newState.Enter();
            currentState = newState;
        }
    }

}
