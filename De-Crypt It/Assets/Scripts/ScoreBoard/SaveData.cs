using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SaveData : MonoBehaviour
{   
    public int minutesLeft;
    public int secondsLeft;
    public int timeLeft;
    public string overallTimeLeft;
    public void keeptimer()
    {
        timeLeft = TimerCountdown.timeLeft;

        minutesLeft = Mathf.FloorToInt(timeLeft / 60F);
        secondsLeft = Mathf.FloorToInt(timeLeft - minutesLeft * 60);

        overallTimeLeft = minutesLeft.ToString() + secondsLeft.ToString();

        HighScores.playerName = "test";
        HighScores.playerScore = int.Parse(overallTimeLeft);
    }
}
