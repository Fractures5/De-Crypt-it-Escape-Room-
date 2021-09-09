using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialEscapeMenu : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject firstPersonController;
    public GameObject firstPersonCamera;

    // Update is called once per frame

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        // If "esc" is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //objectToDisable.SetActive(false);
            //Screen.lockCursor = true;
            firstPersonController.GetComponent<Jump>().enabled=false;
            firstPersonCamera.GetComponent<FirstPersonLook>().enabled=false;
            firstPersonCamera.GetComponent<Zoom>().enabled=false;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            
            //firstPersonController.GetComponent("Jump").enabled=false;
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
            pauseMenu.SetActive(true);
            firstPersonController.GetComponent<Jump>().enabled=false;
        }
        else
        { 
            //Unpauses game
            pauseMenu.SetActive(false);
            Cursor.visible = false;
            isPaused = false;
            Time.timeScale = 1;
            firstPersonController.GetComponent<Jump>().enabled=true;
            firstPersonCamera.GetComponent<FirstPersonLook>().enabled=true;
            firstPersonCamera.GetComponent<Zoom>().enabled=true;
        }
    }

    // Unpauses game once resume game is clicked
    public void returnToMainMenu()
    {
        //pauseMenu.SetActive(false);
        Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.Confined;
        //firstPersonController.SetActive(true);

        firstPersonController.GetComponent<Jump>().enabled=true;
        firstPersonCamera.GetComponent<FirstPersonLook>().enabled=true;
        firstPersonCamera.GetComponent<Zoom>().enabled=true;

        SceneManager.LoadScene(0);
       // Time.timeScale = 1;
        //return;

    }

    public void resumeTutorial()
    {
        firstPersonController.GetComponent<Jump>().enabled=true;
        firstPersonCamera.GetComponent<FirstPersonLook>().enabled=true;
        firstPersonCamera.GetComponent<Zoom>().enabled=true;

        pauseMenu.SetActive(false);
        Cursor.visible = false;
        isPaused = false;
        Time.timeScale = 1;
      
        

    }
}
