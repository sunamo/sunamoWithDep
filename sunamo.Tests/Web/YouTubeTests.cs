public class YouTubeTests
{
    [Fact]
    public void ParseYtCodeTest()
    {
        var actual = YouTube.ParseYtCode("https://www.youtube.com/watch?v=7JoitjrFLlU");
        var expected = "7JoitjrFLlU";

        Assert.Equal(actual, expected);
    }
}
