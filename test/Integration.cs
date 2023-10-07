namespace test;

public class Integration
{
    [Fact]
    public void LowLevel()
    {
        var output = File.ReadAllText("bundle.js");
        Assert.StartsWith("\"use test\"", output);
    }

    [Fact]
    public void HighLevel()
    {
        var output = File.ReadAllText("index.js");
        Assert.StartsWith("\"use test\"", output);
    }
}