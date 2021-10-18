using NUnit.Framework;
using UnityEngine;

public class UvLightTest 
{
    //This script is used to check if the UV light has been turned or off (toggle)
    [Test]
    public void UvLight_PassTest()
    {
        var testUvLight = new UvLightController();

        Assert.IsFalse(UvLightController.UvLightActive);

        testUvLight.TurnOnLight();
        Assert.IsTrue(UvLightController.UvLightActive);

        testUvLight.TurnOffLight();
        Assert.IsFalse(UvLightController.UvLightActive);
    }

    [Test]
    public void UvLight_FailTest()
    {
        var testUvLight = new UvLightController();

        Assert.IsFalse(UvLightController.UvLightActive);

        testUvLight.TurnOffLight();
        Assert.IsTrue(UvLightController.UvLightActive);

        testUvLight.TurnOnLight();
        Assert.IsFalse(UvLightController.UvLightActive);
    }
}