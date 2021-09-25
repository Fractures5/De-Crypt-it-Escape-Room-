using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenTrigger : MonoBehaviour
{
    //This script will load if the player model interacts with the object collision outside the house (will load winning scene)
    void OnTriggerEnter()
    {
        SceneManager.LoadScene("WinScreen");
    }
}
