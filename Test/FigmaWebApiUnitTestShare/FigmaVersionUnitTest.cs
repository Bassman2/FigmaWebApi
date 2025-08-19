namespace FigmaWebApiUnitTest;

[TestClass]
public class FigmaVersionUnitTest : FigmaBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetUserAsync()
    {
        using var Figma = new Figma(storeKey, appName);

        var health = await Figma.GetHealthAsync();

        Assert.IsNotNull(health, "Figma version is null");
        Assert.AreEqual(new Version(11,6,1), new Version(health.Version!), nameof(health.Version));
    }
}
