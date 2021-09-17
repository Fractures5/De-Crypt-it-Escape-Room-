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
    public GameObject showMessage;
    //Unpauses the game when the script is first called
    void Start()
    {
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        // If "esc" is pressed, disables the player controls and invokes the pause tutorial function
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            firstPersonController.GetComponent<Jump>().enabled=false;
            firstPersonCamera.GetComponent<FirstPersonLook>().enabled=false;
            firstPersonCamera.GetComponent<Zoom>().enabled=false;
            showMessage.GetComponent<TutorialInteraction>().enabled=false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PauseTutorial();
            
        }
    }

    //this function paues and unpauses the game
    public void PauseTutorial()
    {
        if (isPaused == false)
        {
            //Game is paused disable player controls
            Time.timeScale = 0; 
            isPaused = true; // game is paused
            pauseMenu.SetActive(true);
            firstPersonController.GetComponent<Jump>().enabled=false;
        }
        else
        { 
            //Unpauses game and enables player controls
            pauseMenu.SetActive(false);
            Cursor.visible = false;
            isPaused = false;
            Time.timeScale = 1;
            firstPersonController.GetComponent<Jump>().enabled=true;
            firstPersonCamera.GetComponent<FirstPersonLook>().enabled=true;
            firstPersonCamera.GetComponent<Zoom>().enabled=true;
            showMessage.GetComponent<TutorialInteraction>().enabled=true;
        }
    }

    // Unpauses game once resume game is clicked and enables player controls
    public void returnToMainMenu()
    {
        Cursor.visible = true;
        firstPersonController.GetComponent<Jump>().enabled=true;
        firstPersonCamera.GetComponent<FirstPersonLook>().enabled=true;
        firstPersonCamera.GetComponent<Zoom>().enabled=true;
        showMessage.GetComponent<TutorialInteraction>().enabled=true;
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    // Unpauses game once resume game is clicked and enables player controls
    public void resumeTutorial()
    {
        firstPersonController.GetComponent<Jump>().enabled=true;
        firstPersonCamera.GetComponent<FirstPersonLook>().enabled=true;
        firstPersonCamera.GetComponent<Zoom>().enabled=true;
        showMessage.GetComponent<TutorialInteraction>().enabled=true;
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        isPaused = false;
        Time.timeScale = 1;
    }
}
