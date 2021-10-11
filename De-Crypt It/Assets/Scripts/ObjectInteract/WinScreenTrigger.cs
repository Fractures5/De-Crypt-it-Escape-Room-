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

    public static bool saveEasy = false;
    public static bool saveMedium = false;
    public static bool saveHard = false;

    //This script will load if the player model interacts with the object collision outside the house (will load winning scene)
    void OnTriggerEnter()
    {

        if(saveEasy == true)
        {
            easyTimer();
            
        }
        else if(saveHard == true)
        {
            hardtimer();
            
        }
        else if(saveMedium == true)
        {
            mediumTimer();
            
        }
        SceneManager.LoadScene("WinScreen");
    }
    //this is for hard mode
    public void hardtimer()
    {
        timeLeft = TimerCountdown.timeLeft;

        minutesLeft = Mathf.FloorToInt(timeLeft / 60F);
        secondsLeft = Mathf.FloorToInt(timeLeft - minutesLeft * 60);

        overallTimeLeft = minutesLeft.ToString() + secondsLeft.ToString();

        HighScores.trackuserName = playernameInput;
        HighScores.trackuserScore = int.Parse(overallTimeLeft);
    }

    public void mediumTimer()
    {
        timeLeft = TimerCountdown.timeLeft;

        minutesLeft = Mathf.FloorToInt(timeLeft / 60F);
        secondsLeft = Mathf.FloorToInt(timeLeft - minutesLeft * 60);

        overallTimeLeft = minutesLeft.ToString() + secondsLeft.ToString();

        HighScoresMedium.trackuserName = playernameInput;
        HighScoresMedium.trackuserScore = int.Parse(overallTimeLeft);
    }

    public void easyTimer()
    {
        timeLeft = TimerCountdown.timeLeft;

        minutesLeft = Mathf.FloorToInt(timeLeft / 60F);
        secondsLeft = Mathf.FloorToInt(timeLeft - minutesLeft * 60);

        overallTimeLeft = minutesLeft.ToString() + secondsLeft.ToString();

        HighScoresEasy.trackuserName = playernameInput;
        HighScoresEasy.trackuserScore = int.Parse(overallTimeLeft);
    }
}
