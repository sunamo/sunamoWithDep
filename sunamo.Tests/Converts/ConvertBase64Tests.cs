public class ConvertBase64Tests
{
    [Fact]
    public void FromTest()
    {
        var input = "N0pvaXRqckZMbFU=";
        var expected = "7JoitjrFLlU";

        var s = ConvertBase64.From(input);
        Assert.Equal(expected, s);
    }

    [Fact]
    public void ToTest()
    {
        var input = "7JoitjrFLlU";
        var expected = "N0pvaXRqckZMbFU=";

        var s = ConvertBase64.To(input);
        Assert.Equal(expected, s);
    }

    [Fact]
    public void FromTest2()
    {
        var input = "blktYVZkY19xdTQ=";
        var expected = "nY-aVdc_qu4";

        var s = ConvertBase64.From(input);
        Assert.Equal(expected, s);
    }

    [Fact]
    public void ToTest2()
    {
        var input = "nY-aVdc_qu4";
        var expected = "blktYVZkY19xdTQ=";

        var s = ConvertBase64.To(input);
        Assert.Equal(expected, s);
    }
}
