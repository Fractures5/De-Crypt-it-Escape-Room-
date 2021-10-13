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
            //saveEasy = false;
        }
        else if(saveHard == true)
        {
            hardtimer();
            //saveHard = false;
        }
        else if(saveMedium == true)
        {
            mediumTimer();
            //saveMedium = false;
        }
        SceneManager.LoadScene("WinScreen");
    }
    //this is for hard mode
    public void hardtimer()
    {
        //Acesses the time left in the time script
        timeLeft = TimerCountdown.timeLeft;
        //Performs calculation to get the minutes left and seconds left using the time left in the time script
        minutesLeft = Mathf.FloorToInt(timeLeft / 60F);
        secondsLeft = Mathf.FloorToInt(timeLeft - minutesLeft * 60);

        //Accesses the winning screen to show the player result
        ShowEndResult.recordMinutesLeft = minutesLeft.ToString();
        ShowEndResult.recordSecondsLeft = secondsLeft.ToString();

        overallTimeLeft = minutesLeft.ToString() + secondsLeft.ToString();

        //Checks if the result has 0 infront, since integer takes the 0 at the front, we are using .tostring to add 0
        //This is needed as we want to format inconsistent integer produced by the data
        if(secondsLeft < 10 && minutesLeft < 10)
        {
            overallTimeLeft = "0" + minutesLeft.ToString() + "0" + secondsLeft.ToString();
            ShowEndResult.recordMinutesLeft = "0" + minutesLeft.ToString();
            ShowEndResult.recordSecondsLeft = "0" + secondsLeft.ToString();
        }
        else if(secondsLeft < 10)
        {
            overallTimeLeft = minutesLeft.ToString() + "0" + secondsLeft.ToString();
            ShowEndResult.recordSecondsLeft = "0" + secondsLeft.ToString();
        }
        else if(minutesLeft < 10)
        {
            overallTimeLeft = "0" + minutesLeft.ToString() + secondsLeft.ToString();
            ShowEndResult.recordMinutesLeft = "0" + minutesLeft.ToString();
        }
        //Saves the player result into the hard difficulty leaderboard script
        HighScores.trackuserName = playernameInput;
        HighScores.trackuserScore = int.Parse(overallTimeLeft);
    }

    public void mediumTimer()
    {
        //Acesses the time left in the time script
        timeLeft = TimerCountdown.timeLeft;

        //Performs calculation to get the minutes left and seconds left using the time left in the time script
        minutesLeft = Mathf.FloorToInt(timeLeft / 60F);
        secondsLeft = Mathf.FloorToInt(timeLeft - minutesLeft * 60);

        //Accesses the winning screen to show the player result
        ShowEndResult.recordMinutesLeft = minutesLeft.ToString();
        ShowEndResult.recordSecondsLeft = secondsLeft.ToString();

        overallTimeLeft = minutesLeft.ToString() + secondsLeft.ToString();

        //Checks if the result has 0 infront, since integer takes the 0 at the front, we are using .tostring to add 0
        //This is needed as we want to format inconsistent integer produced by the data
        if(secondsLeft < 10 && minutesLeft < 10)
        {
            overallTimeLeft = "0" + minutesLeft.ToString() + "0" + secondsLeft.ToString();
            ShowEndResult.recordMinutesLeft = "0" + minutesLeft.ToString();
            ShowEndResult.recordSecondsLeft = "0" + secondsLeft.ToString();
        }
        else if(secondsLeft < 10)
        {
            overallTimeLeft = minutesLeft.ToString() + "0" + secondsLeft.ToString();
            ShowEndResult.recordSecondsLeft = "0" + secondsLeft.ToString();
        }
        else if(minutesLeft < 10)
        {
            overallTimeLeft = "0" + minutesLeft.ToString() + secondsLeft.ToString();
            ShowEndResult.recordMinutesLeft = "0" + minutesLeft.ToString();
        }
        //Saves the player result into the medium difficulty leaderboard script
        HighScoresMedium.trackuserName = playernameInput;
        HighScoresMedium.trackuserScore = int.Parse(overallTimeLeft);
    }

    public void easyTimer()
    {
        //Acesses the time left in the time script
        timeLeft = TimerCountdown.timeLeft;
        
        //Performs calculation to get the minutes left and seconds left using the time left in the time script
        minutesLeft = Mathf.FloorToInt(timeLeft / 60F);
        secondsLeft = Mathf.FloorToInt(timeLeft - minutesLeft * 60);

        //Accesses the winning screen to show the player result
        ShowEndResult.recordMinutesLeft = minutesLeft.ToString();
        ShowEndResult.recordSecondsLeft = secondsLeft.ToString();

        overallTimeLeft = minutesLeft.ToString() + secondsLeft.ToString();

        //Checks if the result has 0 infront, since integer takes the 0 at the front, we are using .tostring to add 0
        //This is needed as we want to format inconsistent integer produced by the data
        if(secondsLeft < 10 && minutesLeft < 10)
        {
            overallTimeLeft = "0" + minutesLeft.ToString() + "0" + secondsLeft.ToString();
            ShowEndResult.recordMinutesLeft = "0" + minutesLeft.ToString();
            ShowEndResult.recordSecondsLeft = "0" + secondsLeft.ToString();
        }
        else if(secondsLeft < 10)
        {
            overallTimeLeft = minutesLeft.ToString() + "0" + secondsLeft.ToString();
            ShowEndResult.recordSecondsLeft = "0" + secondsLeft.ToString();
        }
        else if(minutesLeft < 10)
        {
            overallTimeLeft = "0" + minutesLeft.ToString() + secondsLeft.ToString();
            ShowEndResult.recordMinutesLeft = "0" + minutesLeft.ToString();
        }
        //Saves the player result into the easy difficulty leaderboard script
        HighScoresEasy.trackuserName = playernameInput;
        HighScoresEasy.trackuserScore = int.Parse(overallTimeLeft);
    }
}
