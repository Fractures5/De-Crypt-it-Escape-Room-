using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuReturnToMm : MonoBehaviour
{
    public void ShowMainMenu() // Will load the main menu of the game to the user
    {
        SceneManager.LoadScene(0);

    }

    public void QuitGame()
    {
        Debug.Log("You chose to quit the game"); //Quit message displayed in the console
        Application.Quit(); //quits application
    }
}
