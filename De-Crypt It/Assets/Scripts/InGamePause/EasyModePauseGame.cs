using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyModePauseGame : MonoBehaviour
{
    public Transform pauseMenuCanvas;
    public GameObject crosshairCanvas;
    public GameObject Capsule;
    public GameObject Flashlight;
    public GameObject Camera;
    public GameObject playerAudio;

    public GameObject uvLight;

    //Puzzles
    public GameObject GarageBox;

    public static bool isFlashlightOn = false;

    public static bool isUVLighton = false;


    // Update is called once per frame
    void Update()
    {
        isFlashlightOn = FlashlightController.FlashlightActive;
        isUVLighton = UvLightController.UvLightActive;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Pause();
        }
    }
    //Disables the script of necessary game objects
    public void Pause()
    {
        //Disables the script when the player opens the pause menu
        if (pauseMenuCanvas.gameObject.activeInHierarchy == false)
        {
            crosshairCanvas.SetActive(false);
            pauseMenuCanvas.gameObject.SetActive(true);
            Capsule.SetActive(false);
            Flashlight.SetActive(false);
            uvLight.SetActive(false);
            Time.timeScale = 0; //pauses time, regular time is 1
            Camera.GetComponent<FirstPersonLook>().enabled = false; //Getting script for flashlight and disables
            Camera.GetComponent<FlashlightController>().enabled = false;
            Camera.GetComponent<UvLightController>().enabled = false;
            Camera.GetComponent<Zoom>().enabled = false;
            playerAudio.gameObject.SetActive(false);
        } 
        //enables the script when the player has left the pause menu
        else
        {
            crosshairCanvas.SetActive(true);
            pauseMenuCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Capsule.SetActive(true);
            Camera.GetComponent<FirstPersonLook>().enabled = true; //Getting script for flashlight and enables
            Camera.GetComponent<FlashlightController>().enabled = true;
            Camera.GetComponent<UvLightController>().enabled = true;
            Camera.GetComponent<Zoom>().enabled = true;



            FlashlightController.FlashlightActive = isFlashlightOn;
            UvLightController.UvLightActive = isUVLighton;
            playerAudio.gameObject.SetActive(true);
        }
        
    }
}