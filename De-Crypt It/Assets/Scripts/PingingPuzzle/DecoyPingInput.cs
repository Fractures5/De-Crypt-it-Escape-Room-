using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This script controls the input and the text output and button functionality for the decoy pinging task
public class DecoyPingInput : MonoBehaviour
{
    // The following are GameObjects in the decoy pinging task puzzle scene
    public GameObject inputField;
    public GameObject messageDisplay;

    public GameObject pingFailedMsg1;
    public GameObject pingFailedMsg2;
    public GameObject pingFailedMsg3;
    public GameObject unsuccessfulMsg1;
    public GameObject unsuccessfulMsg2;

    public GameObject tryAgainBtn;
    public GameObject returnBtn;

    void Update()
    {
        // If the user presses "enter" then the "pingStatus" method will be invoked to reset the ping messages 
        // and start showing the fail messages in increments of few seconds.
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter was pressed");
            pingStatus();
        }
    }
    
    // This method is invoked when the user presses "enter" in the terminal.
    // This method will call the method to hide the previous failed ping messages and then call the
    // coroutine method where the failed ping messages will be shown in the terminal every few seconds as specified.
    public void pingStatus()
    {
        resetPingMessages(); // hides all ping messages gameObjects that may be currently set to true
        StartCoroutine(pingFailedCoroutine()); // invokes the coroutine function that will display the unsuccessful ping messages in small increments of time
    }

    // This method when invoked after every few seconds as specified will set the gameobject for the unsuccesful ping messages to true to show
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
        yield return new WaitForSeconds(2);
        unsuccessfulMsg1.SetActive(true);
        yield return new WaitForSeconds(1);
        unsuccessfulMsg2.SetActive(true);
    }

    // This function will be invoked when the try again button is clicked to reset the ping messages and the scene for the user to try again
    public void tryAgain()
    {
        resetPingMessages();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }   

    // This function when invoked will hide all the failed ping messages which are meant to be shown in the terminal after their input.
    public void resetPingMessages()
    {
        pingFailedMsg1.SetActive(false);
        pingFailedMsg2.SetActive(false);
        pingFailedMsg3.SetActive(false);
        unsuccessfulMsg1.SetActive(false);
        unsuccessfulMsg2.SetActive(false);
    }

    // This function will be invoked when the return button is clicked to return back to the medium game scene when they have not completed the puzzle.
    public void returnBtnClick()
    {
        resetPingMessages(); // Invokes the method which will hide all the ping messages to the default state.
        SceneManager.LoadScene("MediumGame");
    }
}
