using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMechanic : MonoBehaviour
{
    //The array of images
    [SerializeField]
    private Transform[] puzzles;
    //A boolean variable which keeps track whether the task has been completed
    public static bool isWin;
    //Notifies the player if task is completed
    public GameObject WinText;
    //Start sets the game to false
    void Start()
    {
        isWin = false;
    }
    //This function checks if all the images has been correctly rotated
    void Update()
    {
        if(puzzles[0].rotation.z == 0 &&
           puzzles[1].rotation.z == 0 &&
           puzzles[2].rotation.z == 0 &&
           puzzles[3].rotation.z == 0 &&
           puzzles[4].rotation.z == 0 &&
           puzzles[5].rotation.z == 0 &&
           puzzles[6].rotation.z == 0 &&
           puzzles[7].rotation.z == 0)
        {
            isWin = true;
            WinText.SetActive(true);
        }
    }
}
