using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenTrigger : MonoBehaviour
{
    void OnTriggerEnter()
    {
        SceneManager.LoadScene("WinScreen");
    }
}
