using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PuzzleExit : MonoBehaviour
{
    public void ExitPuzzle()
    {
        SceneManager.LoadScene("MediumGame");
    }
}
