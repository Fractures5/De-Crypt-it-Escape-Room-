using NUnit.Framework;
using UnityEngine;

public class QuizTest 
{

    [Test]
    public void QuizPassword_Test()
    {
        var readPassword = new PasswordInput();

        Assert.IsTrue(readPassword.checkPassword("COMP602"));
        Assert.IsTrue(readPassword.checkPassword("comp602"));

        Assert.IsFalse(readPassword.checkPassword("602comp"));
        Assert.IsFalse(readPassword.checkPassword("password"));
        Assert.IsFalse(readPassword.checkPassword("    "));
        Assert.IsFalse(readPassword.checkPassword(""));
        Assert.IsFalse(readPassword.checkPassword(null));
    }

    [Test]
    public void QuizPassword_FailTest()
    {
        var readPassword = new PasswordInput();

        Assert.IsTrue(readPassword.checkPassword("602comp"));
        Assert.IsTrue(readPassword.checkPassword("password"));
        Assert.IsTrue(readPassword.checkPassword("    "));
        Assert.IsTrue(readPassword.checkPassword(""));
        Assert.IsTrue(readPassword.checkPassword(null));
    }
}
