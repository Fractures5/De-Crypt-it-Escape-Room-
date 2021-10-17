using NUnit.Framework;
using UnityEngine;

public class UvLightTest 
{
    [Test]
    public void UvLight_Test()
    {
        var testUvLigth = new UvLightController();

        Assert.IsFalse(UvLightController.UvLightActive);

        testUvLigth.TurnOnLight();
        Assert.IsTrue(UvLightController.UvLightActive);

        testUvLigth.TurnOffLight();
        Assert.IsFalse(UvLightController.UvLightActive);
    }
}