public class DTHelperEnTests
{
    [Fact]
    public void ParseDateTimeUSATest()
    {
        var input = "5/19/2021 09:59 AM";
        var actual = DTHelperEn.ParseDateTimeUSA(input);
    }
}
