using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBoxPlaySound : MonoBehaviour
{
    //Gathers the open sound effect
    public AudioSource openSound;
    // Start is called before the first frame update
    void Start()
    {
        //Gets the audio source in the object
        openSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
