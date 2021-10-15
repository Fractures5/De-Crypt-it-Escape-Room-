using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Using to change scenes

// This script will handle loading scenes based on the user selections from the main menu
public class MainMenuScript : MonoBehaviour
{
    public void ShowMainMenu() // Will load the main menu of the game to the user
    {
        SceneManager.LoadScene(0);

    }

    public void PlayStoryboard() // Will load the storyboard scene to the user
    {
        SceneManager.LoadScene(1);

    }

    public void PlayTutorial() // Will load the tutorial mode scene to the user
    {
        Cursor.visible = false;
        SceneManager.LoadScene(2);

    }

    public void QuitGame() // This function will quit the next game
    {
        Debug.Log("You chose to quit the game"); // Quit message displayed in the console (testing)
        Application.Quit(); // Will quit the application
    }
    
    public void EnterName() // Will load the enter name scene
    {
        SceneManager.LoadScene("EnterName");
    }
    public void ViewLeaderboard() // Will load the leaderboard scene
    {
        SceneManager.LoadScene("Leaderboard");
    }
}
