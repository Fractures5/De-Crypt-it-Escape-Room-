using NUnit.Framework;
using UnityEngine;

public class ReadNameTest
{
    
    [Test]
    public void ReadnName_Test(){

        var readName = new ReadName();
        //checking the name validation, whether is valid or not.
        Assert.IsTrue(readName.IsValid("john"));
        Assert.IsTrue(readName.IsValid("mary"));
        Assert.IsFalse(readName.IsValid("TestingAllSorts#1"));
        
    }

    //For this method we will be testing for a couple of issues inside the read name class.
    [Test]
    public void readNameFail_Test(){

        var readName = new ReadName();
        //checking the name validation, if is inside the description set in the script.
        //checking for white spaces, null, and over 8 characters.
        Assert.IsTrue(readName.IsValid("MyNameIsJef123"));
        Assert.IsFalse(readName.IsValid(""));
        Assert.IsFalse(readName.IsValid(" "));
        Assert.IsFalse(readName.IsValid(null));
    }
}
