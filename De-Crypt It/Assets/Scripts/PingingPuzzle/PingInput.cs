using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PingInput : MonoBehaviour
{
    // This script will check if the player has pinged correctly to unlock the keypad to unlock the door and escape.
    public string pingInput;
    public string correctPing = "ping 192.168.20.1";
    public GameObject inputField;
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

    public static bool taskComplete = false;

    public GameObject proceedBtn;
    public GameObject tryAgainBtn;
    public GameObject returnBtn;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter was pressed");
            pingStatus();
        }
    }
    
    public void pingStatus()
    {

        pingInput = inputField.GetComponent<Text>().text;
        resetPingMessages();
        

        if (pingInput == correctPing)
        {
            messageDisplay.GetComponent<Text>().text = "Ping successfu! - Door Keypad unlocked";
            // add code here to show the hidden text showing the congrats message and next steps.
            StartCoroutine(pingPassCoroutine());
        }
        else
        {
            messageDisplay.GetComponent<Text>().text = "Ping unsuccessful - try again!";
            //add code here to show the hiddent text showing the unsuccesful ping message.
            
            StartCoroutine(pingFailedCoroutine());
        }
    }

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

        proceedBtn.SetActive(true);
        tryAgainBtn.SetActive(false);
        returnBtn.SetActive(false);
    }

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
    }

    public void tryAgain()
    {
        resetPingMessages();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }   

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

    public void returnBtnClick()
    {
        resetPingMessages();
        SceneManager.LoadScene("MediumGame");
    }

    public void proceedBtnClick()
    {
        taskComplete = true;
        SceneManager.LoadScene("MediumGame");
    }
}
