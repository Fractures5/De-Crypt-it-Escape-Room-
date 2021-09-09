using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBoxPlaySound : MonoBehaviour
{
    public AudioSource openSound;
    // Start is called before the first frame update
    void Start()
    {
        openSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
