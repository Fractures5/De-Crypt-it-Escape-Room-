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

    //Once the object collides it will load the next scene.
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    //Created so that we can save the task as not completed, allowing the user toi play again 
    //load the main game scene after exiting the game
    public void Exit(){
        ArcadeLoad.taskComplete = false;
        SceneManager.LoadScene(3);
        //Application.Quit();
    }
    //Upon finishing the game, load the main game and save the task as completed. so that the clue can be displayed after, and not allow the user to play again.
     public void LoadGame(){
        ArcadeLoad.taskComplete = true ;
        SceneManager.LoadScene("MainGame");
    }

}
