using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Using to change scenes

public class LoadMainGame : MonoBehaviour
{
    public void loadMainGame()
    {
        SceneManager.LoadScene(3);
    }
}
