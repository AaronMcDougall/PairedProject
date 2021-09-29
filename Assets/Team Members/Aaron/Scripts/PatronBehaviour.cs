using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronBehaviour : MonoBehaviour
{
    public void WaitInLine()
    {
        //enter waiting state
        Debug.Log("Waiting in Line");
    }

    public void Fight()
    {
        //enter fighting state
        Debug.Log("Starting a Fight");
    }

    public void SneakAround()
    {
        //enter sneaking state
        Debug.Log("Sneaking In");
    }
}
