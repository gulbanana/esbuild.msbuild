namespace test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var output = File.ReadAllText("bundle.js");
        Assert.StartsWith("\"use test\"", output);
    }
}