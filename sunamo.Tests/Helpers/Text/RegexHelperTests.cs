public class RegexHelperTests
{
    [Fact]
    public void IsUriTest()
    {
        var u = RegexHelper.IsUri(@"https://www.microsoft.com/en-us/security/portal/submission/submit.aspx");
        Assert.True(u);
    }
}
