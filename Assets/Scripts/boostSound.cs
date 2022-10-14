using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostSound : MonoBehaviour
{
    public GameObject Rocket;
    AudioSource audioSource;
    public enum State {Playing,Dead,NextLevel,NoFuel,Pause,};
    State state = State.Playing;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    
    private void Update()
    {
        KeyBoost();
        
    }
    private void StopBAudio() 
    {

        audioSource.Stop();
    }
    private void KeyBoost()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            boost();
        }
        else
        {
       
        }
    }
    private void boost() 
    {
        if (state == State.Playing) 
        {
            audioSource.Play();
        }
        else 
        {
            audioSource.Stop();
        }
    }
    

}
