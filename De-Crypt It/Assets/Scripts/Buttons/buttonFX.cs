using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonFX : MonoBehaviour
{

    public AudioSource buttonClickFx;
    public AudioClip hoverOverFx;
    public AudioClip clickFx;

    public void HoverSound(){

        buttonClickFx.PlayOneShot(hoverOverFx);
    }

    public void ClickSound(){

        buttonClickFx.PlayOneShot(clickFx);

    }

}
