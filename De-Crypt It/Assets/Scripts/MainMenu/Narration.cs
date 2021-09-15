using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narration : MonoBehaviour
{
    public AudioSource audSource;
    public AudioClip card1;
    public AudioClip card2;
    public AudioClip card3;
    public AudioClip card4;
    public AudioClip card5;
    public AudioClip card6;
    public AudioClip card7;
    public AudioClip card8;
    int buttonClicks = 0;

    public void NarrationClick()
    {
        if (buttonClicks == 0)
        {
            audSource.clip = card2;
            audSource.Play();
            buttonClicks++;
            Debug.Log("Narration 2 is occuring!");
        }
        else if (buttonClicks == 1)
        {
            audSource.clip = card3;
            audSource.Play();
            buttonClicks++;
            Debug.Log("Narration 3 is occuring!");
        }
        else if (buttonClicks == 2)
        {
            audSource.clip = card4;
            audSource.Play();
            buttonClicks++;
            Debug.Log("Narration 4 is occuring!");
        }
        else if (buttonClicks == 3)
        {
            audSource.clip = card5;
            audSource.Play();
            buttonClicks++;
            Debug.Log("Narration 5 is occuring!");
        }
        else if (buttonClicks == 4)
        {
            audSource.clip = card6;
            audSource.Play();
            buttonClicks++;
            Debug.Log("Narration 6 is occuring!");
        }
        else if (buttonClicks == 5)
        {
            audSource.clip = card7;
            audSource.Play();
            buttonClicks++;
            Debug.Log("Narration 7 is occuring!");
        }
        else if (buttonClicks == 6)
        {
            audSource.clip = card8;
            audSource.Play();
            buttonClicks++;
            Debug.Log("Narration 8 is occuring!");
        }        
    }

    public void StartOfNarration()
    {
        audSource.clip = card1;
        audSource.Play();
        Debug.Log("Narration 1 is occuring!");
    }
}
