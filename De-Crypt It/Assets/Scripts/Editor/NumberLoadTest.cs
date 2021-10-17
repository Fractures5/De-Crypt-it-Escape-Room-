using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class NumberLoadTest
{
    [Test]
    public void NumberLoad_Test()
    {

        var numberloading = new NumberLoad();

        Assert.IsFalse(NumberLoad.firstNumberActive);

        numberloading.turnNumberActive();
        Assert.IsFalse(NumberLoad.firstNumberActive);

    }
    [Test]
    public void NumberLoad_FailTest()
    {

        var numberloading = new NumberLoad();

        Assert.IsTrue(NumberLoad.firstNumberActive);
        numberloading.turnNumberNotActive();
        Assert.IsTrue(NumberLoad.firstNumberActive);
    }
}