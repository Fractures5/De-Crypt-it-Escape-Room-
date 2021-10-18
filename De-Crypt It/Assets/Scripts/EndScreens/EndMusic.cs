using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMusic : MonoBehaviour
{
    //This script will play the winning music when the winning screen has been activated
    public AudioSource AudioSource;
    public static float bgMusicVolume = 1f;

    void Start()
    {
        AudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = bgMusicVolume;
    }
}
