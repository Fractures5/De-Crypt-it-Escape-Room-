using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
public class LeaderboardTest : MonoBehaviour
{
    
    [Test]
    public static void calculateTimeLeftPass()
    {
        //The expected time to come out after the calculate time method it is set in string as we are casting it to int when saving it into leaderboard
        //This is done as an int variable, would sometimes cut the 0 at the front eg. 02 becomes 2.
        string expectedTime = "3000";
        //Result time is the overall time left after the calculatetimeleft method is ran, the information stored here is by calculating the 
        //time left remaining and putting them into the corresponding minutes and seconds left. eg. 1800 becomes 30minutes and 00 seconds
        string resulltTime = "";

        WinScreenTrigger calculateTimeLeftTest = new WinScreenTrigger();

        //Setting up the time left, 1800, could be any value and this will format it to their corresponding minutes:seconds
        calculateTimeLeftTest.calculateTimeLeft(1800);

        //Accessing the overalltimeleft variable in the winscreen trigger class
        resulltTime = calculateTimeLeftTest.overallTimeLeft;

        //Checking to see if both values are equal
        Assert.AreEqual(expectedTime, resulltTime);
    }

    [Test]
    public static void calculateTimeLeftFail()
    {
        //The expected time to come out after the calculate time method it is set in string as we are casting it to int when saving it into leaderboard
        //This is done as an int variable, would sometimes cut the 0 at the front eg. 02 becomes 2.
        string expectedTime = "2548";
        //Result time is the overall time left after the calculatetimeleft method is ran, the information stored here is by calculating the 
        //time left remaining and putting them into the corresponding minutes and seconds left. eg. 1800 becomes 30minutes and 00 seconds
        string resulltTime = "";

        WinScreenTrigger calculateTimeLeftTest = new WinScreenTrigger();

        //Setting up the time left, 1800, could be any value and this will format it to their corresponding minutes:seconds
        calculateTimeLeftTest.calculateTimeLeft(1800);

        //Accessing the overalltimeleft variable in the winscreen trigger class
        resulltTime = calculateTimeLeftTest.overallTimeLeft;

        //Checking to see if both values are equal
        Assert.AreEqual(expectedTime, resulltTime);
    }
    
}
