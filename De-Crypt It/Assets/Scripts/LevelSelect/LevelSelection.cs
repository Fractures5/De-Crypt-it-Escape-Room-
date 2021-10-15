using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

// This script handles the interaction and manages the controls for the level selection UI in the single player mode
public class LevelSelection : MonoBehaviour
{
    // Boolean variables used to check what level button was selected
    public bool selectedEasyButton;
    public bool selectedMediumButton;
    public bool selectedHardButton;

    // The confirm button variable used to check if confirm was selected.
    public Button confirmButton;

    // Start is called before the first frame update
    void Start()
    {
        // At the start of the scene, all the button are set to false to indicate unselected
        confirmButton.interactable = false;
        selectedEasyButton = false;
        selectedMediumButton = false;
        selectedHardButton = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Makes the confirm button interactable to the user
    public void enableConfirmButton()
    {
        confirmButton.interactable = true;
    }

    // Makes the confirm button disabled and not interactable for the user
    public void disableConfirmButton()
    {
        confirmButton.interactable = false;
    }

    // This function is invoked when the user clicks the easy level button.
    // The boolean for the easy button is set to true indicate the easy level has been selected.
    // Other level booleans are set to false to indicate they have not been selected by the user.
    public void easyClicked()
    {
        selectedEasyButton = true;
        selectedMediumButton = false;
        selectedHardButton = false;
    }

    // This function is invoked when the user clicks the medium level button.
    // The boolean for the medium button is set to true indicate the medium level has been selected.
    // Other level booleans are set to false to indicate they have not been selected by the user.
    public void mediumClicked()
    {
        selectedEasyButton = false;
        selectedMediumButton = true;
        selectedHardButton = false;
    }

    // This function is invoked when the user clicks the hard level button.
    // The boolean for the hard button is set to true indicate the hard level has been selected.
    // Other level booleans are set to false to indicate they have not been selected by the user.
    public void hardClicked()
    {
        selectedEasyButton = false;
        selectedMediumButton = false;
        selectedHardButton = true;
    }

    // This function is invoked when the user clicks the background of the level select UI.
    // It will reset all button level selection booleans to false and will disable the confirm button.
    public void backgroundClicked()
    {
        Debug.Log("background clicked");
        selectedEasyButton = false;
        selectedMediumButton = false;
        selectedHardButton = false;
        confirmButton.interactable = false;
    }

    // This function is invoked when the user clicks the confirm and proceed button.
    // This function is responsible to load the required level scene the user has selected in its restarded state.
    public void loadSelectedLevel()
    {
        // Initialises the WinScreenTrigger booleans for each level
        WinScreenTrigger.saveEasy = false;
        WinScreenTrigger.saveMedium = false;
        WinScreenTrigger.saveHard = false;
        Debug.Log("should switch scenes");

        // When easy level button is selected the easy level is loaded.
        if(selectedEasyButton == true)
        {
            restartEasyGameStatus(); // resets all variables in the easy game
            WinScreenTrigger.saveEasy = true;
            SceneManager.LoadScene("EasyGame"); // loads the easy game
        }
        else if(selectedMediumButton == true) // When medium level button is selected the medium level is loaded
        {
            restartMediumGameStatus(); // resets all variables in the medium game
            WinScreenTrigger.saveMedium = true;
            SceneManager.LoadScene("MediumGame"); // loads the medium game
        }
        else if(selectedHardButton == true) // When the hard level button is selected the hard level is loaded
        {
            WinScreenTrigger.saveHard = true; // resets all variables in the hard game
            restartHardGameStatus();
            SceneManager.LoadScene("MainGame"); // Load the hard level difficulty game
        }
    }

    // This function will reset the hard game variables if the player wishes to restart the game.
    // This function is invoked just before the hard game is loaded to reset the game variables for the user to start fresh.
    void restartHardGameStatus()
    {
        StorePlayerLocation.savedPosition = new Vector3(-3.412f,0.2201252f,-16.276f);
        StorePlayerLocation.restartStatus = true;
        GameObject[] allLights= GameObject.FindGameObjectsWithTag("SwitchLight");
        //Getting audio source component
        foreach (GameObject i in allLights)
        { 
            i.SetActive(false); 
        } 
        FuseboxLoad.taskComplete = false;
        KeyPadLoad.taskComplete = false;
        QuizLoad.taskComplete = false;
        PasswordInput.loginSuccessful = false;
        LoginStatusCheck.startQuizStatus = false;
        PhoneDecoy.taskComplete = false;
        ArcadeLoad.taskComplete = false;
        FlashlightController.FlashlightActive = false;
        TimerCountdown.timeLeft = 3600;
    }

    // This function will reset the medium game variables if the player wishes to restart the game.
    // This function is invoked just before the medium game is loaded to reset the game variables for the user to start fresh.    
    void restartMediumGameStatus()
    {
        StorePlayerLocation.savedPosition = new Vector3(-3.412f,0.2201252f,-16.276f);
        StorePlayerLocation.restartStatus = true;
        TimerCountdown.timeLeft = 1800;
        FlashlightController.FlashlightActive = false;
        ServerRoomKeypad.taskComplete = false;
        ServerRoomKeypad.keypadActive = false;
        JigsawPuzzle.taskComplete = false;
        CardSwipe.isComplete = false;
        SwipeTask.isComplete = false;
        IPaddressInteraction.clueReceived = false;
        DecoyPingTaskLoad.taskComplete = false;
        PingingTaskLoad.taskComplete = false;
        LightSwitch.isOn = false;
        SRLockedDoor.taskComplete = false;
        CardInteraction.cardPickUp = false;
        GameObject[] allLights= GameObject.FindGameObjectsWithTag("SwitchLight");
        //Getting audio source component
        foreach (GameObject i in allLights)
        { 
            i.SetActive(false); 
        } 
    }

    // This function will reset the easy game variables if the player wishes to restart the game.
    // This function is invoked just before the easy game is loaded to reset the game variables for the user to start fresh.    
    void restartEasyGameStatus()
    {
        StorePlayerLocation.savedPosition = new Vector3(-3.412f,0.2201252f,-16.276f);
        StorePlayerLocation.restartStatus = true;
        TimerCountdown.timeLeft = 900;
        PadLockDrop.hasClipPlayed = false;
        PadLockDrop.hasEnumeratorRan = false;
        BatteryInteraction.isBatteryCollected = false;
        EnvironmentKey.hasWrongEnvKeyClltd = false;
        Target.isKeyCollected = false;
        LockControl.isPadlockOpened = false;
        FlashlightController.FlashlightActive = false;
        UvLightController.UvLightActive = false;
    }
}
