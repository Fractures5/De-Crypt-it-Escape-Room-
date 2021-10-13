using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelSelection : MonoBehaviour
{
    public bool selectedEasyButton;
    public bool selectedMediumButton;
    public bool selectedHardButton;
    public Button confirmButton;
    string levelSelected;

    // Start is called before the first frame update
    void Start()
    {
        confirmButton.interactable = false;
        selectedEasyButton = false;
        selectedMediumButton = false;
        selectedHardButton = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void enableConfirmButton()
    {
        confirmButton.interactable = true;
    }

    public void disableConfirmButton()
    {
        confirmButton.interactable = false;
    }

    public void easyClicked()
    {
        selectedEasyButton = true;
        selectedMediumButton = false;
        selectedHardButton = false;
    }

    public void mediumClicked()
    {
        selectedEasyButton = false;
        selectedMediumButton = true;
        selectedHardButton = false;
    }

    public void hardClicked()
    {
        selectedEasyButton = false;
        selectedMediumButton = false;
        selectedHardButton = true;
    }

    public void backgroundClicked()
    {
        Debug.Log("background clicked");
        selectedEasyButton = false;
        selectedMediumButton = false;
        selectedHardButton = false;
        confirmButton.interactable = false;
    }

    public void loadSelectedLevel()
    {
        WinScreenTrigger.saveEasy = false;
        WinScreenTrigger.saveMedium = false;
        WinScreenTrigger.saveHard = false;
        Debug.Log("should switch scenes");
        if(selectedEasyButton == true)
        {
            restartEasyGameStatus();
            WinScreenTrigger.saveEasy = true;
            SceneManager.LoadScene("EasyGame");
        }
        else if(selectedMediumButton == true)
        {
            restartMediumGameStatus();
            WinScreenTrigger.saveMedium = true;
            SceneManager.LoadScene("MediumGame");
        }
        else if(selectedHardButton == true)
        {
            WinScreenTrigger.saveHard = true;
            restartHardGameStatus();
            SceneManager.LoadScene("MainGame"); // Load the hard level difficulty game
        }
    }

    // This function will reset the game variables if the player wishes to restart the game
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
    void restartMediumGameStatus()
    {
        StorePlayerLocation.savedPosition = new Vector3(-3.412f,0.2201252f,-16.276f);
        StorePlayerLocation.restartStatus = true;
        TimerCountdown.timeLeft = 1800;
        //TimerCountdown.timeLeft = 120;
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
