using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonScript : MonoBehaviour
{

    [SerializeField] private ConfirmationWindow RestartConfirmationWindow;

    // Start is called before the first frame update
    void Start()
    {
        OpenConfirmationWindow();
    }

    private void OpenConfirmationWindow()
    {
        RestartConfirmationWindow.gameObject.SetActive(true);
        RestartConfirmationWindow.yesButton.onClick.AddListener(YesClicked);
        RestartConfirmationWindow.noButton.onClick.AddListener(NoClicked);
    }

    private void YesClicked()
    {
        RestartConfirmationWindow.gameObject.SetActive(false);
        Debug.Log("Yes Clicked");
        Debug.Log("You chose to restart the game");
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }

    private void NoClicked()
    {
        RestartConfirmationWindow.gameObject.SetActive(false);
        Debug.Log("No Clicked");
        Debug.Log("You chose to NOT restart the game");
    }
}
