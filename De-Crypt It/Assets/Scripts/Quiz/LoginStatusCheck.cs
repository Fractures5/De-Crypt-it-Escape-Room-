using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will always update and check if the user has successfully logged on and clicked start so that
// once they exit the quiz they will not be required to log on once again.
public class LoginStatusCheck : MonoBehaviour
{
    // GameObject variables of the quiz UI used to determine what is shown to the user
    public GameObject quizUI;
    public GameObject startQuizButton;
    public GameObject quizMenu;

    // static boolean variable used to determine if the start quiz button was selected by the user
    public static bool startQuizStatus = false;

    // Update is called once per frame
    void Update()
    {
        // If the user has logged on and pressed start for the quiz, then the will be shown the quizUI only and the login UI and start button will disappear.
        if (PasswordInput.loginSuccessful == true && startQuizStatus == true)
        {
            quizUI.SetActive(true);
            startQuizButton.SetActive(false);
            quizMenu.SetActive(false);
        }
    }

    // If start quiz is pressed, the status will be set to true to be used in the update method above to show the quizUI and hide the login UI.
    public void startClicked()
    {
        startQuizStatus = true;
    }
}
