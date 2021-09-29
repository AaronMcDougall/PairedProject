using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void Death();
    public static event Death DeathEvent;

    public static void DeathEventFunction()
    {

        if(DeathEvent!=null)
        {
            DeathEvent();
        }
    }

   
}
