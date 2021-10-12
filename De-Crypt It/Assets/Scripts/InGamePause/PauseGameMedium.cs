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
    public static bool isFlashlightOn = false;
    
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
            /*//House
            Pantry.GetComponent<MoveObjectController>().enabled = false;
            Kitchen.GetComponent<MoveObjectController>().enabled = false;
            Television.GetComponent<MoveObjectController>().enabled = false;
            DoorOne.GetComponent<MoveObjectController>().enabled = false;
            Bathroom.GetComponent<MoveObjectController>().enabled = false;
            DoorTwo.GetComponent<MoveObjectController>().enabled = false;
            Drawers.GetComponent<MoveObjectController>().enabled = false;
            Closet.GetComponent<MoveObjectController>().enabled = false;
            BedDrawerOne.GetComponent<MoveObjectController>().enabled = false;
            DoorFinal.GetComponent<MoveObjectController>().enabled = false;
            //Puzzle
            FuseBox.GetComponent<FuseboxLoad>().enabled = false;
            Keypad.GetComponent<KeyPadLoad>().enabled = false;
            Quiz.GetComponent<QuizLoad>().enabled = false;
            Arcade.GetComponent<ArcadeLoad>().enabled = false;
            Note.GetComponent<InstructionImage>().enabled = false;
            Phone.GetComponent<PhoneDecoy>().enabled = false;*/
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
            /*//House
            Pantry.GetComponent<MoveObjectController>().enabled = true;
            Kitchen.GetComponent<MoveObjectController>().enabled = true;
            Television.GetComponent<MoveObjectController>().enabled = true;
            DoorOne.GetComponent<MoveObjectController>().enabled = true;
            Bathroom.GetComponent<MoveObjectController>().enabled = true;
            DoorTwo.GetComponent<MoveObjectController>().enabled = true;
            Drawers.GetComponent<MoveObjectController>().enabled = true;
            Closet.GetComponent<MoveObjectController>().enabled = true;
            BedDrawerOne.GetComponent<MoveObjectController>().enabled = true;
            DoorFinal.GetComponent<MoveObjectController>().enabled = true;
            //Puzzle
            FuseBox.GetComponent<FuseboxLoad>().enabled = true;
            Keypad.GetComponent<KeyPadLoad>().enabled = true;
            Quiz.GetComponent<QuizLoad>().enabled = true;
            Arcade.GetComponent<ArcadeLoad>().enabled = true;
            Note.GetComponent<InstructionImage>().enabled = true;
            Phone.GetComponent<PhoneDecoy>().enabled = true;*/

            FlashlightController.FlashlightActive = isFlashlightOn;
            playerAudio.gameObject.SetActive(true);
        }
        
    }
}
