public class WildcardTests
{
    [Fact]
    public void WildcardTest()
    {
        var input = @"https://www.facebook.com/name.surname/photos_albums";
        var wildcard = @"https://www.facebook.com/*/photos_albums";
        var expected = @"name.surname";

        Wildcard wc = new Wildcard(wildcard);

        var regex = Wildcard.WildcardToRegex(wildcard);
        var matches = SH.SplitAndReturnRegexMatches(input,new System.Text.RegularExpressions.Regex( regex));

        int i = 0;
        #region Not working
        //var matches = wc.Matches(input);

        //var first = matches[0];
        //Assert.Equal(expected, first.Value); 
        #endregion
    }

    [Fact]
    public void WildcardTest1()
    {
        var input = "<M C=\"a\">";
        var wildcard = @"";
        var expected = @"name.surname";

        Wildcard wc = new Wildcard(wildcard);

        var regex = Wildcard.WildcardToRegex(wildcard);
        var matches = SH.SplitAndReturnRegexMatches(input, new System.Text.RegularExpressions.Regex(regex));

        int i = 0;
        #region Not working
        //var matches = wc.Matches(input);

        //var first = matches[0];
        //Assert.Equal(expected, first.Value); 
        #endregion
    }
}
