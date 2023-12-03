public class UnixDateConverterTests
{
    [Fact]
    public void From_ToTest()
    {
        var expected = Consts.DateTimeMinVal.AddHours(3);
        var r = UnixDateConverter.To(expected);
        var actual = UnixDateConverter.From(r);
        Assert.Equal<DateTime>(expected, actual);
    }
}
