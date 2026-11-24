namespace Test101.Common.Tests;

public class UtilsTests
{
    [Fact]
    public void Test1()
    {
        int result = Utils.Fattoriale(6);

        Assert.Equal(720, result);
    }

    [Fact]
    public void Test2()
    {
        int result = Utils.Fattoriale(4);

        Assert.Equal(24, result);
    }

    [Fact]
    public void TestThrowsException()
    {
        Assert.Throws<ArgumentException>(() => Utils.Fattoriale(-2));
    }

    [Theory]
    [InlineData(2, 2)]
    [InlineData(3, 6)]
    [InlineData(4, 24)]
    [InlineData(5, 120)]
    public void TestMultiple(int a, int exp)
    {
        int result = Utils.Fattoriale(a);

        Assert.Equal(exp, result);
    }
}
