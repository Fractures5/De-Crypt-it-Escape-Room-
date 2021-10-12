using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //Using to change scenes
public class ReadName : MonoBehaviour
{
    //This script will check if the player has entered the correct password to enter the quiz puzzle and deal with the outcome
    public string insertName;
    int nameIndex;
    public GameObject inputField;
    public GameObject warningSign;
    public bool checkSpace = false;
    //This function checks if the player inputs the correct password, depending on that it will present the player an option to start the game if correct and error message if wrong
    //string.IsNullOrWhiteSpace(insertName))
    public void EnterGame()
    {
        insertName = inputField.GetComponent<Text>().text;
        nameIndex = insertName.Length;
        Debug.Log(nameIndex);

        /*
        foreach(char c in insertName)
        {
            if(char.IsWhiteSpace(c) == false)
            {
                checkSpace = true;
                break;
            }
        }
        */
        if (string.IsNullOrEmpty(insertName) || nameIndex > 8 || string.IsNullOrWhiteSpace(insertName))
        {
            warningSign.SetActive(true);
        }
        else
        {
            WinScreenTrigger.playernameInput = insertName;
            Debug.Log(insertName);
            SceneManager.LoadScene(1);
        }

    }
}
