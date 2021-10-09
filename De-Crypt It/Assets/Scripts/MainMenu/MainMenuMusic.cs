using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuMusic : MonoBehaviour
{
    //This script will handle the main menu music interaction
    public AudioSource AudioSource;
    public GameObject bgMusicSlider;
    public static float bgMusicVolume = 1f;

    void Start()
    {
        AudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = bgMusicVolume;
        bgMusicSlider.GetComponent<Slider>().value = bgMusicVolume;

    }
    //Updates the volume if the player wishes to change the sound volume
    public void updateVolume(float volume)
    {
        bgMusicVolume = volume;
    }
}
