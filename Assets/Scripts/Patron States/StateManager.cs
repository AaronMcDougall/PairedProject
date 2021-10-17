using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public StateBase currentState;
    
    public StateBase patientState;
    public StateBase fightingState;
    public StateBase knockedDownState;
    public StateBase leavingState;
    public StateBase sneakingState;
    
    //public StateBase newState;

    void FixedUpdate()
    {
        UpdateCurrentState();
    }

    void UpdateCurrentState()
    {
        currentState?.Execute();
    }

    public void ChangeState(StateBase newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        if (newState != null)
        {
            newState.Enter();
            currentState = newState;
        }
    }

    
    //Changing to different states
    public void StartAFight()
    {
        ChangeState(fightingState);
        //enter fighting state
        Debug.Log("Had Enough");
    }

    public void WaitInLine()
    {
        ChangeState(patientState);
        //enter waiting state
        Debug.Log("Waiting in Line");
    }

    public void SneakAround()
    {
        ChangeState(sneakingState);
        //enter sneaking state
        Debug.Log("Sneaking In");
    }

    public void GetKnockedDown()
    {
        ChangeState(knockedDownState);
        Debug.Log("Knocked Down");
    }

    public void Leaving()
    {
        ChangeState(leavingState);
        Debug.Log("Giving up and Leaving");
    }
}