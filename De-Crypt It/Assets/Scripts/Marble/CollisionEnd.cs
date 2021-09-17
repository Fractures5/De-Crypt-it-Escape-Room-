using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public void Exit(){
        ArcadeLoad.taskComplete = false;
        SceneManager.LoadScene(3);
        //Application.Quit();
    }
     public void LoadGame(){
        ArcadeLoad.taskComplete = true ;
        SceneManager.LoadScene("MainGame");
    }

}
