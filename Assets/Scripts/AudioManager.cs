using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource fightingSpeech;
    public AudioSource leavingSpeech;
    public AudioSource sneakingSpeech;
    public AudioSource swipe;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        FindObjectOfType<FightingState>().GoToBouncerEvent += FightingSpeechFunction;
        FindObjectOfType<FightingState>().SwipeEvent += SwipeSoundFunction;
        FindObjectOfType<LeavingState>().GoToExitEvent += LeavingSpeechFunction;
        FindObjectOfType<SneakingState>().GoToSneakingEvent += SneakingSpeechFunction;
    }

    private void OnDisable()
    {
        FindObjectOfType<FightingState>().GoToBouncerEvent -= FightingSpeechFunction;
        FindObjectOfType<FightingState>().SwipeEvent -= SwipeSoundFunction;
        FindObjectOfType<LeavingState>().GoToExitEvent -= LeavingSpeechFunction;
        FindObjectOfType<SneakingState>().GoToSneakingEvent -= SneakingSpeechFunction;
    }

    private void FightingSpeechFunction()
    {
        Debug.Log("SHOULD BE SOUND HERE");
        
        fightingSpeech.Play();
    }

    void SwipeSoundFunction()
    {
        swipe.Play();
    }

    void LeavingSpeechFunction()
    {
        leavingSpeech.Play();
    }

    void SneakingSpeechFunction()
    {
        sneakingSpeech.Play();
    }
}
