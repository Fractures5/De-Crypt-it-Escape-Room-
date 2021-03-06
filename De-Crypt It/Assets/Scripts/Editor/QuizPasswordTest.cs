using NUnit.Framework;
using UnityEngine;

// This script is for unit testing the quiz password input.
public class QuizPasswordTest
{
    // This function will pass all the tests as all the user input will
    // be true since the password is as expected.
    [Test]
    public void QuizPassword_PassTest()
    {
        var readPassword = new PasswordInput();

        Assert.IsTrue(readPassword.checkPassword("COMP602"));
        Assert.IsTrue(readPassword.checkPassword("comp602"));
    }

    // This function will fail the unit tests because when using assert
    // the input variables is not true for the password input.
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