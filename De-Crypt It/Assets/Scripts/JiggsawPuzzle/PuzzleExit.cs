using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PuzzleExit : MonoBehaviour
{
    //This script is related to the exit button, if the player wishes to exit the puzzle, they will be able to
    public void ExitPuzzle()
    {
        //This function is ran when the exit button is clicked
        SceneManager.LoadScene("MediumGame");
    }
}
