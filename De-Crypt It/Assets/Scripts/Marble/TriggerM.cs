using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerM : MonoBehaviour
{
    public AudioSource audioTouch;

    //Plays audio when collider is in range
    public void OnTriggerEnter(Collider other)
    {
        audioTouch.Play();
    }

    void Start()
    {
        audioTouch = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
}
