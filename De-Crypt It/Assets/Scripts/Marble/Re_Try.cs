using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Re_Try : MonoBehaviour
{   
    //Move Scene to the MarblePuzzle so player can play the game again.
    public void LoadGame(){
        SceneManager.LoadScene("MarblePuzzle");
    }
}
