using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameMedium : MonoBehaviour
{
    public Transform pauseMenuCanvas;
    public GameObject crosshairCanvas;
    public GameObject Capsule;
    public GameObject Flashlight;
    public GameObject Camera;
    public GameObject playerAudio;

    public GameObject lockedDoor;
    public GameObject unlockedDoor;
    public GameObject keypad;
    public GameObject card;
    public GameObject jigsawPuzzle;
    public GameObject decoyPingTask;
    public GameObject pingTask;
    public GameObject cardSwipe;
    public GameObject lightSwitch;
    public GameObject lightsPoster;
    public GameObject clockPoster;
    public GameObject portalPoster;
    public GameObject globePoster;
    public GameObject clueInteraction;


    public static bool isFlashlightOn = false;
    
    //Assets in the server room

    // Update is called once per frame
    void Update()
    {
        isFlashlightOn = FlashlightController.FlashlightActive;
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
            Time.timeScale = 0; //pauses time, regular time is 1
            Camera.GetComponent<FirstPersonLook>().enabled = false; //Getting script for flashlight and disables
            Camera.GetComponent<FlashlightController>().enabled = false;
            Camera.GetComponent<Zoom>().enabled = false;
            
            lockedDoor.GetComponent<SRLockedDoor>().enabled = false;
            unlockedDoor.GetComponent<MoveableObject>().enabled = false;
            unlockedDoor.GetComponent<MoveObjectController>().enabled = false;
            unlockedDoor.GetComponent<MoveObjectController>().enabled = false;
            keypad.GetComponent<ServerRoomKeypad>().enabled = false;
            card.GetComponent<CardInteraction>().enabled = false;
            jigsawPuzzle.GetComponent<JigsawPuzzle>().enabled = false;
            decoyPingTask.GetComponent<DecoyPingTaskLoad>().enabled = false;
            pingTask.GetComponent<PingingTaskLoad>().enabled = false;
            cardSwipe.GetComponent<CardSwipe>().enabled = false;
            lightSwitch.GetComponent<LightSwitch>().enabled = false;
            lightsPoster.GetComponent<LightPlan>().enabled = false;
            clockPoster.GetComponent<LightPlan>().enabled = false;
            portalPoster.GetComponent<LightPlan>().enabled = false;
            globePoster.GetComponent<LightPlan>().enabled = false;
            clueInteraction.GetComponent<IPaddressInteraction>().enabled = false;
            playerAudio.gameObject.SetActive(false);

        } 
        //enables the script when the player has left the pause menu
        else
        {
            crosshairCanvas.SetActive(true);
            pauseMenuCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            Cursor.visible = false;
            Capsule.SetActive(true);
            Camera.GetComponent<FirstPersonLook>().enabled = true; //Getting script for flashlight and enables
            Camera.GetComponent<FlashlightController>().enabled = true;
            Camera.GetComponent<Zoom>().enabled = true;
            
            lockedDoor.GetComponent<SRLockedDoor>().enabled = true;
            unlockedDoor.GetComponent<MoveableObject>().enabled = true;
            unlockedDoor.GetComponent<MoveObjectController>().enabled = true;
            unlockedDoor.GetComponent<MoveObjectController>().enabled = true;
            keypad.GetComponent<ServerRoomKeypad>().enabled = true;
            card.GetComponent<CardInteraction>().enabled = true;
            jigsawPuzzle.GetComponent<JigsawPuzzle>().enabled = true;
            decoyPingTask.GetComponent<DecoyPingTaskLoad>().enabled = true;
            pingTask.GetComponent<PingingTaskLoad>().enabled = true;
            cardSwipe.GetComponent<CardSwipe>().enabled = true;
            lightSwitch.GetComponent<LightSwitch>().enabled = true;
            lightsPoster.GetComponent<LightPlan>().enabled = true;
            clockPoster.GetComponent<LightPlan>().enabled = true;
            portalPoster.GetComponent<LightPlan>().enabled = true;
            globePoster.GetComponent<LightPlan>().enabled = true;
            clueInteraction.GetComponent<IPaddressInteraction>().enabled = true;

            FlashlightController.FlashlightActive = isFlashlightOn;
            playerAudio.gameObject.SetActive(true);
        }
    }
}
