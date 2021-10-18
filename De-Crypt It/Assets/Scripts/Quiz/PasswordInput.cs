using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script will check if the player has entered the correct password to enter the quiz puzzle and deal with the outcome.
public class PasswordInput : MonoBehaviour
{
    public string passwordInput;
    public string correctPasswordUpCase = "COMP602";
    public string correctPasswordLowCase = "comp602";
    public GameObject inputField;
    public GameObject messageDisplay;
    public GameObject startQuizButton;
    public static bool loginSuccessful = false;

    //T his function checks if the player inputs the correct password, depending on that it will present the player an option to start the game if correct and error message if wrong
    public void StoreName()
    {
        passwordInput = inputField.GetComponent<Text>().text; // Initalises user input into password input variable.
        checkPassword(passwordInput); // invoke check password method to check if user has inputted the correct quiz UI password.

        if (loginSuccessful == true) // if the password matches the expected password the start button is shown and a correct message is shown to the user.
        {
            messageDisplay.GetComponent<Text>().text = "Successful! " +passwordInput+ " is correct.";
            startQuizButton.SetActive(true);
        }
        else // if the password input is incorrect then the user is displayed an unsucessful message prompting try again.
        {
            messageDisplay.GetComponent<Text>().text = "Unsuccessful! " +passwordInput+ " is incorrect.";
        }
    }

    // This function will check if the password the user enters matches the correct password and based on that sets if the login is succeesful or not.
    // This function takes in the string parameter of the user password input.
    // This function will return a boolean "loginSuccessful" which specifies if the password is valid and hence is the login successful or not.
    public bool checkPassword(string passwordInput)
    {
        // if password input matches then user login is successful.
        if (passwordInput == correctPasswordUpCase || passwordInput == correctPasswordLowCase)
        {   
            loginSuccessful = true;
            return loginSuccessful;
        }
        else // if password input doesnt matches then the user login is not successful.
        {
            loginSuccessful = false;
            return loginSuccessful;
        } 
    }

}