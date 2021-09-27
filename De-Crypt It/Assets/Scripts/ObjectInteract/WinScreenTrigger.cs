using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenTrigger : MonoBehaviour
{
    //when the player collides with the collision range, their result will be saved
    public int minutesLeft;
    public int secondsLeft;
    public int timeLeft;
    public string overallTimeLeft;
    public static string playernameInput;
    //This script will load if the player model interacts with the object collision outside the house (will load winning scene)
    void OnTriggerEnter()
    {
        keeptimer();
        SceneManager.LoadScene("WinScreen");
    }
    //this is for hard mode
    public void keeptimer()
    {
        timeLeft = TimerCountdown.timeLeft;

        minutesLeft = Mathf.FloorToInt(timeLeft / 60F);
        secondsLeft = Mathf.FloorToInt(timeLeft - minutesLeft * 60);

        overallTimeLeft = minutesLeft.ToString() + secondsLeft.ToString();

        HighScores.trackuserName = playernameInput;
        HighScores.trackuserScore = int.Parse(overallTimeLeft);
    }
}
