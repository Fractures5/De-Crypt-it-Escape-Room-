using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    //This script will handle the main menu music interaction
    public AudioSource AudioSource;

    private float bgMusicVolume = 1f;

    void Start()
    {
        AudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = bgMusicVolume;
    }
    //Updates the volume if the player wishes to change the sound volume
    public void updateVolume(float volume)
    {
        bgMusicVolume = volume;
    }
}
