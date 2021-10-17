using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButtonScript : MonoBehaviour
{
    //This script will handle the interaction between the player and the quit button
    [SerializeField] private ConfirmationWindow QuitConfirmationWindow;

    void Start()
    {
        OpenConfirmationWindow();
    }

    private void OpenConfirmationWindow()
    {
        QuitConfirmationWindow.gameObject.SetActive(true);
        QuitConfirmationWindow.yesButton.onClick.AddListener(YesClicked);
        QuitConfirmationWindow.noButton.onClick.AddListener(NoClicked);
    }

    private void YesClicked()
    {
        QuitConfirmationWindow.gameObject.SetActive(false);
        Debug.Log("Yes Clicked");
        Debug.Log("You chose to quit the game");
        Application.Quit();
    }

    private void NoClicked()
    {
        QuitConfirmationWindow.gameObject.SetActive(false);
        Debug.Log("No Clicked");
        Debug.Log("You chose to NOT quit the game");
    }
}
