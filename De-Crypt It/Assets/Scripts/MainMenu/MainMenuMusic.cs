using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script will handle the main menu music interaction.
public class MainMenuMusic : MonoBehaviour
{
    // Declares the audio source object and the music slider game object.
    public AudioSource AudioSource;
    public GameObject bgMusicSlider;

    // The static float variable for the music volume will make the volume stay consistent.
    // when switching scenes.
    public static float bgMusicVolume = 1f;

    // At the start the background music will be played automatically.
    void Start()
    {
        AudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // The background music will be set to the static volume value.
        AudioSource.volume = bgMusicVolume; 
        // The slider will be updated based on the value of the background music volume level.
        bgMusicSlider.GetComponent<Slider>().value = bgMusicVolume; 

    }

    // Updates the volume if the player wishes to change the sound volume
    public void updateVolume(float volume)
    {
        bgMusicVolume = volume;
    }
}
