using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPuzzle : MonoBehaviour
{
    public AudioSource clickSound;

    //This class allows the images to rotate when pressed, it will then play a sound when the images are clicked
    public void OnMouseDown()
    {
        if(!PuzzleMechanic.isWin)
        {
            transform.Rotate(0f, 0f, 90f);
        }
        if(PuzzleMechanic.isWin == false)
        {
            clickSound.Play();
        }
    }
}
