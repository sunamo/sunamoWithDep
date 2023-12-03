[TestClass]
public class HttpRequestHelperTests
{
    [TestMethod]
    public void GetResponseTextTest()
    {

        var t = HttpClientHelper.GetResponseText(@"https://ws.audioscrobbler.com/2.0/?method=artist.gettoptags&artist=Soundtrack+Ledov%C3%A9+kr%C3%A1lovstv%C3%AD+II&user=sunamoDevProg&api_key=68ae15739cd690ce04679a15b5583fd4", HttpMethod.Get, null);

        int i = 0;
    }
}
