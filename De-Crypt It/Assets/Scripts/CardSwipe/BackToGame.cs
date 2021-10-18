using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToGame : MonoBehaviour
{
    //When this class is called, it will use scenemanager to load the medium game back up
    public void ReturnToGame()
    {
        SceneManager.LoadScene("MediumGame");
    }
}