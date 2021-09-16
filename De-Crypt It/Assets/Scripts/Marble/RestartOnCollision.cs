using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnCollision : MonoBehaviour
{
    [SerializeField]
    //string strTag;

    //in case the player falls, the game will restart upon touching the bottom frame cube
    private void OnCollisionEnter(Collision collision){
        //if(collision.collider.tag == strTag)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
