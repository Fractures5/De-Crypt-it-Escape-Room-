using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
public class LeaderboardTest : MonoBehaviour
{
    [Test]
    public void LeaderboardTestPass()
    {
        string expectedTime = "3000";

        int minutesLeft;
        int secondsLeft;
        int timeLeft;
        string overallTimeLeft;

        timeLeft = 1800;
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
        //Checks if the expected minute is the same as the minutes left
        Assert.AreEqual(expectedTime, overallTimeLeft);
    }

    [Test]
    public void LeaderboardTestWithAddedZeroPass()
    {
        string expectedTime = "0200";

        int minutesLeft;
        int secondsLeft;
        int timeLeft;
        string overallTimeLeft;

        timeLeft = 120;
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
        //Checks if the expected minute is the same as the minutes left
        Assert.AreEqual(expectedTime, overallTimeLeft);
    }

    [Test]
    public void LeaderboardTestFail()
    {
        string expectedTime = "2900";

        int minutesLeft;
        int secondsLeft;
        int timeLeft;
        string overallTimeLeft;

        timeLeft = 1800;
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
        //Checks if the expected minute is the same as the minutes left
        Assert.AreEqual(expectedTime, overallTimeLeft);
    }

}
