using NUnit.Framework;
using UnityEngine;

public class ReadNameTest
{
    [Test]
    public void ReadnName_Test()
    {
        var readName = new ReadName();

        Assert.IsTrue(readName.IsValid("john"));
        Assert.IsTrue(readName.IsValid("mary"));
        Assert.IsFalse(readName.IsValid("TestingAllSorts#1"));
        
    }

    [Test]
    public void readNameFail_Test()
    {
        var readName = new ReadName();
        
        Assert.IsTrue(readName.IsValid("MyNameIsJef123"));
        Assert.IsFalse(readName.IsValid(""));
        Assert.IsFalse(readName.IsValid(" "));
        Assert.IsFalse(readName.IsValid(null));
    }
}
