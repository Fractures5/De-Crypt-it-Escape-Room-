using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    // Start is called before the first frame update

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

    public void updateVolume(float volume)
    {
        bgMusicVolume = volume;
    }
}
