public class CSharpHelperSunamoTests
{
    [Fact]
    public void IndentAsPreviousLineTest()
    {
        var input = SH.GetLines( @"for (int i = 0; i < args.Length; i++)
{
    string nazev = args[i];
HttpCookie cook = new HttpCookie(nazev, args[++i]);
cook.Expires = DateTime.Now.AddYears(1);
    Response.Cookies.Set(cook);
 
}");

        var excepted = SH.GetLines( @"for (int i = 0; i < args.Length; i++)
{
    string nazev = args[i];
    HttpCookie cook = new HttpCookie(nazev, args[++i]);
    cook.Expires = DateTime.Now.AddYears(1);
    Response.Cookies.Set(cook);
 
}");


        SH.IndentAsPreviousLine(input);

        Assert.Equal(excepted, input);
    }
}
