using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class KeyPadTest
{
    [Test]
    public void KeyPadCode_PassTest()
    {
        string expectedCodeSeq = "9607";
        string inputSeq = "9607";

        Assert.AreEqual(expectedCodeSeq, inputSeq);
    }

    [Test]
    public void KeyPadCode_FailTest()
    {
        string expectedCodeSeq = "9607";
        string inputSeq = "5434";

        Assert.AreEqual(expectedCodeSeq, inputSeq);
    }
}
