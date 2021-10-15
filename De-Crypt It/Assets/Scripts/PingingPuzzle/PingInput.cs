using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This script will check if the player has pinged correctly to unlock the keypad to unlock the door and escape.
public class PingInput : MonoBehaviour
{
    // Variables used for storing user input and the correct ping input.
    public string pingInput;
    public string correctPing = "ping 192.168.20.1";
    
    // The following are GameObjects in the pinging task puzzle scene.
    public GameObject inputField;
    public GameObject userInputUneditable;
    public GameObject messageDisplay;

    public GameObject pingPassedMsg1;
    public GameObject pingPassedMsg2;
    public GameObject pingPassedMsg3;
    public GameObject pingPassedMsg4;
    public GameObject pingPassedMsg5;
    public GameObject successfulMsg;

    public GameObject pingFailedMsg1;
    public GameObject pingFailedMsg2;
    public GameObject pingFailedMsg3;
    public GameObject pingFailedMsg4;
    public GameObject pingFailedMsg5;
    public GameObject unsuccessfulMsg1;
    public GameObject unsuccessfulMsg2;

    public GameObject proceedBtn;
    public GameObject tryAgainBtn;
    public GameObject returnBtn;

    public GameObject pingingCluePopup;

    // Sound effect game objects for the ping task
    public AudioSource pingSuccessfulFX;
    public AudioSource pingUnsuccessfulFX;
    public AudioSource interactionFX;

    // boolean variable used to determine when enter can be recognised by the script
    public bool initialEnter = true;
    public bool userCanEnter = false;
   
    // When pinging task is loaded, the enter button sound effect is played.
    void Start()
    {
        interactionFX.Play(0);
    }

    void Update()
    {
        // When the user has received the clue, it will be shown on the ping task scene UI.
        if(IPaddressInteraction.clueReceived == true)
        {
            pingingCluePopup.SetActive(true);
        }
        else // When the user hasnt received the clue, the clue wont be shown in the ping task scene UI.
        {
            pingingCluePopup.SetActive(false);
        }

        // If the user presses "enter" then the "pingStatus" method will be invoked to determine what message and buttons are shown.
        if(Input.GetKeyDown(KeyCode.Return) && (initialEnter == true || userCanEnter == true))
        {
            // sets boolean to false so user cannot press enter.
            userCanEnter = false;
            initialEnter = false; 
            Debug.Log("Enter was pressed");

            userInputUneditable.SetActive(true); // shows uneditable user input text.
            inputField.SetActive(false); // hides user input text.
            
            interactionFX.Play(0); // plays the sounds effect for when enter is pressed.
            pingStatus(); // invokes the pingStatus method to determine if the ping is correct or not.
        }
    }
    
    // This method is invoked when the user presses "enter" in the terminal.
    // This method will initialise the user input and compare it to the required ping value and determine
    // what conditional statement to trigger and hence what method to invoke to show the required ping message and buttons.
    public void pingStatus()
    {

        pingInput = inputField.GetComponent<Text>().text; // initliases user input into the variable.
        userInputUneditable.GetComponent<Text>().text = pingInput; // stores user input into a text variable which will be displayed and is uneditable.
        resetPingMessages(); // hides all ping messages gameObjects that may be currently set to true.
        

        if (pingInput == correctPing) // If the user input matches the correct exepcted ping then the following is executed.
        {
            messageDisplay.GetComponent<Text>().text = "Ping successfu! - Door Keypad unlocked";
            StartCoroutine(pingPassCoroutine()); // invokes the coroutine function that will display the successful ping messages in small time increments.
            PingingTaskLoad.taskComplete = true; // sets the ping task to complete so once the user exits, they will be unable to enter it again since its completed.
            DecoyPingTaskLoad.taskComplete = true; // sets the decoy ping task to complete so once the user exits, they will be unable to enter it again since its completed.
        }
        else // If the user input does not match the correct expected ping then the following is executed
        {
            messageDisplay.GetComponent<Text>().text = "Ping unsuccessful - try again!";
            StartCoroutine(pingFailedCoroutine()); // invokes the coroutine function that will display the unsuccessful ping messages in small time increments.
        }
    }

    // This method when invoked after every few seconds as specified will set the gameobject for the succesfull ping messages to true to show
    // the messages on the terminal and set the proceed button to show and hide the other buttons.
    // This method will return the IEnumerator type variable.
    IEnumerator pingPassCoroutine()
    {
        yield return new WaitForSeconds(2);
        pingPassedMsg1.SetActive(true);
        yield return new WaitForSeconds(1);
        pingPassedMsg2.SetActive(true);
        yield return new WaitForSeconds(1);
        pingPassedMsg3.SetActive(true);
        yield return new WaitForSeconds(1);
        pingPassedMsg4.SetActive(true);
        yield return new WaitForSeconds(1);
        pingPassedMsg5.SetActive(true);
        yield return new WaitForSeconds(2);
        successfulMsg.SetActive(true);

        proceedBtn.SetActive(true); // Will enable and show the proceed button
        tryAgainBtn.SetActive(false); // Will hide the try again button
        returnBtn.SetActive(false); // Will hide the return button

        pingSuccessfulFX.Play(0); // play the successful audio effect once the ping is complete
    }

    // This method when invoked after every few seconds as specified will set the gameobject for the unsuccesfull ping messages to true to show
    // the ping fail messages on the terminal.
    // This method will return the IEnumerator type variable.
    IEnumerator pingFailedCoroutine()
    {
        yield return new WaitForSeconds(2);
        pingFailedMsg1.SetActive(true);
        yield return new WaitForSeconds(1);
        pingFailedMsg2.SetActive(true);
        yield return new WaitForSeconds(1);
        pingFailedMsg3.SetActive(true);
        yield return new WaitForSeconds(1);
        pingFailedMsg4.SetActive(true);
        yield return new WaitForSeconds(1);
        pingFailedMsg5.SetActive(true);
        yield return new WaitForSeconds(2);
        unsuccessfulMsg1.SetActive(true);
        yield return new WaitForSeconds(1);
        unsuccessfulMsg2.SetActive(true);

        pingUnsuccessfulFX.Play(0); // play the error audio effect once the ping is failed by the user input.
        userInputUneditable.SetActive(false); // hides the uneditable user input text.
        inputField.SetActive(true); // shows the orginal user input text.
        userCanEnter = true; // sets boolean to true so user can now press enter for their new ping.

    }

    // This function will be invoked when the try again button is clicked to reset the ping messages and the scene for the user to try again.
    public void tryAgain()
    {
        resetPingMessages();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }   

    // This function when invoked will hide all the ping messages which are meant to be shown in the terminal after their input.
    public void resetPingMessages()
    {
        pingPassedMsg1.SetActive(false);
        pingPassedMsg2.SetActive(false);
        pingPassedMsg3.SetActive(false);
        pingPassedMsg4.SetActive(false);
        pingPassedMsg5.SetActive(false);
        successfulMsg.SetActive(false);

        pingFailedMsg1.SetActive(false);
        pingFailedMsg2.SetActive(false);
        pingFailedMsg3.SetActive(false);
        pingFailedMsg4.SetActive(false);
        pingFailedMsg5.SetActive(false);
        unsuccessfulMsg1.SetActive(false);
        unsuccessfulMsg2.SetActive(false);
    }

    // This function will be invoked when the return button is clicked to return back to the medium game scene when they have not completed the puzzle.
    public void returnBtnClick()
    {
        resetPingMessages(); // Invokes the method which will hide all the ping messages to the default state.
        SceneManager.LoadScene("MediumGame");
    }

    // This function will be invoked when the proceed button is clicked to return the user back to the medium game scene.
    public void proceedBtnClick()
    {
        SceneManager.LoadScene("MediumGame");
    }
}
