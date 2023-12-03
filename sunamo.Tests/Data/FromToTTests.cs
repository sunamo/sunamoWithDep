using TestValues;

public class FromToTTests
{
    [Fact]
    public void ParseTest()
    {
        FromToT<int> ft = new FromToT<int>();
        // Musí být vždy From-To (oddělené -)
        Assert.Throws(ExcTypes.ArgumentOutOfRangeException_, () => ft.Parse("20"));
    }
}
