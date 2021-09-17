using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderLightBox : MonoBehaviour
{
    public void LoadMainGame()
    {
        //Set is closed to true for sound effect and also change the scene
        FuseboxLoad.isClosed = true;
        SceneManager.LoadScene(3);
    }
}
