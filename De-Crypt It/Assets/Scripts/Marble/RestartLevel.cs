using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    //Restart the game if player hits out of boundarie places.
    [SerializeField]
    KeyCode keyRestart;

    void Update()
    {
       if(Input.GetKey(keyRestart))
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
