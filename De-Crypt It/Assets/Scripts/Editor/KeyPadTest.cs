using UnityEngine;
using NUnit.Framework;

public class KeyPadTest
{
    [Test]
    public void NumberLoad_Test(){

       var numberloading = new NumberLoad();

      //  numberloading.Update();
        //NumberLoad testNumberLoad;
        //Assert.IsFalse(testNumberLoad.firstNumber);
       Assert.IsFalse(NumberLoad.firstNumberActive);
       
       numberloading.turnNumberActive();
       Assert.IsFalse(NumberLoad.firstNumberActive);


    }
    [Test]
    public void NumberLoad_FailTest(){

        var numberloading = new NumberLoad();
        
        numberloading.turnNumberNotActive();
        Assert.IsTrue(NumberLoad.firstNumberActive);
    }
}
