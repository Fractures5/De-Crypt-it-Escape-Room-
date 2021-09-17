using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordInput : MonoBehaviour
{
    //This script will check if the player has entered the correct password to enter the quiz puzzle and deal with the outcome
    public string passwordInput;
    public string correctPassword = "COMP602";
    public GameObject inputField;
    public GameObject messageDisplay;
    public GameObject startQuizButton;
    //This function checks if the player inputs the correct password, depending on that it will present the player an option to start the game if correct and error message if wrong
    public void StoreName()
    {
        passwordInput = inputField.GetComponent<Text>().text;

        if (passwordInput == correctPassword)
        {
            messageDisplay.GetComponent<Text>().text = "Successful! " +passwordInput+ " is correct.";
            startQuizButton.SetActive(true);
        }
        else
        {
            messageDisplay.GetComponent<Text>().text = "Unsuccessful! " +passwordInput+ " is incorrect.";
        }
    }
}
