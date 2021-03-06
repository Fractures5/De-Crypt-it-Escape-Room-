using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonScript : MonoBehaviour
{
    [SerializeField] private ConfirmationWindow MainMenuConfirmationWindow;
    // Start is called before the first frame update
    void Start()
    {
        OpenConfirmationWindow();
    }
    //This fuction will open the confirmation window
    private void OpenConfirmationWindow()
    {
        MainMenuConfirmationWindow.gameObject.SetActive(true);
        MainMenuConfirmationWindow.yesButton.onClick.AddListener(YesClicked);
        MainMenuConfirmationWindow.noButton.onClick.AddListener(NoClicked);
    }
    //This function will run the contents inside when the player has clicked yes button
    private void YesClicked()
    {
        MainMenuConfirmationWindow.gameObject.SetActive(false);
        Debug.Log("Yes Clicked");
        Debug.Log("You chose to restart the game");
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    //This function will run the contents inside when the player has clicked no button
    private void NoClicked()
    {
        MainMenuConfirmationWindow.gameObject.SetActive(false);
        Debug.Log("No Clicked");
        Debug.Log("You chose to NOT restart the game");
    }
}
