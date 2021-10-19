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
        fightingSpeech = gameObject.AddComponent<AudioSource>();
        leavingSpeech = gameObject.AddComponent<AudioSource>();
        sneakingSpeech = gameObject.AddComponent<AudioSource>();
        swipe = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
