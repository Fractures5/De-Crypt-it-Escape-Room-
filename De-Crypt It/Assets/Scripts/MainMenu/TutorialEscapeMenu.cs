using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script will handle the interactions and process for when the tutorial mode is paused
public class TutorialEscapeMenu : MonoBehaviour
{
    // bool to check if tutorial is paused
    public bool isPaused = false;

    // Declare gameobjects for the player movement, interaction, message and menu UI
    public GameObject pauseMenu;
    public GameObject firstPersonController;
    public GameObject firstPersonCamera;
    public GameObject Capsule;
    public GameObject showMessage;
    public GameObject Flashlight;
    public GameObject UVLight;
    public GameObject playerAudio;

    // Declare static bools to use in determining whether the lights should be off or on when pausing
    public static bool isFlashlightOn = false;
    public static bool isUVlightOn = false;

    //Unpauses the game when the script is first called
    void Start()
    {
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        // intialises the status of the UV and flash light
        isFlashlightOn = FlashlightController.FlashlightActive;
        isUVlightOn = TutorialUVLight.UvLightActive;

        // If "esc" is pressed, disables the player controls and invokes the pause tutorial function
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            firstPersonController.GetComponent<Jump>().enabled=false;
            firstPersonController.GetComponent<FirstPersonMovement>().enabled=false;
            firstPersonCamera.GetComponent<FirstPersonLook>().enabled=false;
            firstPersonCamera.GetComponent<Zoom>().enabled=false;
            firstPersonCamera.GetComponent<FlashlightController>().enabled = false;
            firstPersonCamera.GetComponent<TutorialUVLight>().enabled = false;
            showMessage.GetComponent<TutorialInteraction>().enabled=false;
            playerAudio.gameObject.SetActive(false);
            Flashlight.SetActive(false);
            Capsule.SetActive(false);
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
            firstPersonController.GetComponent<FirstPersonMovement>().enabled=true;
            firstPersonController.GetComponent<Jump>().enabled=true;
            firstPersonCamera.GetComponent<FirstPersonLook>().enabled=true;
            firstPersonCamera.GetComponent<Zoom>().enabled=true;
            firstPersonCamera.GetComponent<FlashlightController>().enabled = true;
            firstPersonCamera.GetComponent<TutorialUVLight>().enabled = true;
            showMessage.GetComponent<TutorialInteraction>().enabled=true;
            playerAudio.gameObject.SetActive(true);
            Capsule.SetActive(true);
            FlashlightController.FlashlightActive = isFlashlightOn;
            TutorialUVLight.UvLightActive = isUVlightOn;
        }
    }

    // Unpauses game once resume game is clicked and enables player controls
    public void returnToMainMenu()
    {
        Cursor.visible = true;
        firstPersonController.GetComponent<FirstPersonMovement>().enabled=true;
        firstPersonController.GetComponent<Jump>().enabled=true;
        firstPersonCamera.GetComponent<FirstPersonLook>().enabled=true;
        firstPersonCamera.GetComponent<Zoom>().enabled=true;
        showMessage.GetComponent<TutorialInteraction>().enabled=true;
        firstPersonCamera.GetComponent<FlashlightController>().enabled = true;
        firstPersonCamera.GetComponent<TutorialUVLight>().enabled = true;
        playerAudio.gameObject.SetActive(true);
        Capsule.SetActive(true);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    // Unpauses game once resume game is clicked and enables player controls
    public void resumeTutorial()
    {
        firstPersonController.GetComponent<FirstPersonMovement>().enabled=true;
        firstPersonController.GetComponent<Jump>().enabled=true;
        firstPersonCamera.GetComponent<FirstPersonLook>().enabled=true;
        firstPersonCamera.GetComponent<Zoom>().enabled=true;
        firstPersonCamera.GetComponent<FlashlightController>().enabled = true;
        firstPersonCamera.GetComponent<TutorialUVLight>().enabled = true;
        showMessage.GetComponent<TutorialInteraction>().enabled=true;
        playerAudio.gameObject.SetActive(true);
        FlashlightController.FlashlightActive = isFlashlightOn;
        TutorialUVLight.UvLightActive = isUVlightOn;
        pauseMenu.SetActive(false);
        Capsule.SetActive(true);
        Cursor.visible = false;
        isPaused = false;
        Time.timeScale = 1;
    }
}
