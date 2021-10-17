using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderPadLock : MonoBehaviour
{
    public void LoadGarageLevel()
    {
        //Set is closed to true for sound effect and also change the scene
        LockControl.isPadlockClosed = true;
        SceneManager.LoadScene(11);
    }

}
