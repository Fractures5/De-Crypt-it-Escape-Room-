using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class NumberLoadTest
{
    //This script is used for unit testing of the visibility of the firstNumber game object
    [Test]
    public void NumberLoadPass_Test()
    {
        //This function will pass all the tests as all expected results will be provided
        var numberloading = new NumberLoad();

        //invoke the turnNumberActive function which will return the boolean variable firstNumberActive
        numberloading.turnNumberActive();
        //Checks if the firstNumber game object's state is true or visible
        //if the firstNumber game object's state is true or visible then the unit test will pass
        Assert.IsTrue(NumberLoad.firstNumberActive);

    }
    [Test]
    public void NumberLoadFail_Test()
    {
        //This function will fail all units tests as the expected result will not be provided
        var numberloading = new NumberLoad();

        //invoke the turnNumberActive function which will return the boolean variable firstNumberActive
        numberloading.turnNumberNotActive();
        //Checks if the firstNumber game object's state is true or visible
        //if the firstNumber game object's state is not true or not visible then the unit test will fail
        Assert.IsTrue(NumberLoad.firstNumberActive);
    }
}