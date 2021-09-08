using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialEscapeMenu : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenu;
    //public GameObject firstPersonController;
    //public GameObject firstPersonCamera;

    // Update is called once per frame


    void Update()
    {
        // If "esc" is pressed
        if(Input.GetButtonDown("Cancel"))
        {
            //objectToDisable.SetActive(false);
            //Screen.lockCursor = true;
            //Cursor.visible = true;

            Cursor.lockState = CursorLockMode.None;
            
            //firstPersonController.SetActive(false);
            //firstPersonCamera.SetActive(true);
            PauseTutorial();
            
        }
    }


    public void PauseTutorial()
    {
        if (isPaused == false)
        {
            //Game is paused
            Time.timeScale = 0; 
            isPaused = true; // game is paused
            Cursor.visible = true;
            pauseMenu.SetActive(true);
        }
        else
        { 
            //Unpauses game
            pauseMenu.SetActive(false);
            Cursor.visible = false;
            isPaused = false;
            Time.timeScale = 1;
        }
    }

    // Unpauses game once resume game is clicked
    public void returnToMainMenu()
    {
        Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.Confined;
        //firstPersonController.SetActive(true);
        SceneManager.LoadScene("MainMenu");
        //return;

    }

    public void resumeTutorial()
    {
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        isPaused = false;
        Time.timeScale = 1;
    }
}
