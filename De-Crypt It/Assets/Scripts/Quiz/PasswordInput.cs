using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordInput : MonoBehaviour
{
    public string passwordInput;
    public string correctPassword = "COMP602";
    public GameObject inputField;
    public GameObject messageDisplay;
    public GameObject startQuizButton;

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
