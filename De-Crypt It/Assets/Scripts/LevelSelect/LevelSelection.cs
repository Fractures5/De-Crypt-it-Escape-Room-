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
        // if (selectedEasyButton == true || selectedMediumButton == true || selectedHardButton == true)
        // {
        //     confirmButton.interactable = true;
        // }
        // else{
        //     confirmButton.interactable = false;
        // }
    }

    public void enableConfirmButton()
    {
        confirmButton.interactable = true;
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
        Debug.Log("should switch scenes");
        if(selectedEasyButton == true)
        {
            SceneManager.LoadScene("EasyGame");
        }
        else if(selectedMediumButton == true)
        {
            SceneManager.LoadScene("MediumGame");
        }
        else if(selectedHardButton == true)
        {
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
        PhoneDecoy.taskComplete = false;
        ArcadeLoad.taskComplete = false;
        FlashlightController.FlashlightActive = false;
        TimerCountdown.timeLeft = 1800;
    }    

}
