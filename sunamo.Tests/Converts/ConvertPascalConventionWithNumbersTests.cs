using System.Text.RegularExpressions;

public class ConvertPascalConventionWithNumbersTests
{
    [Fact]
    public void FromToWordsTests()
    {
        string[] tests = {
           "AutomaticTrackingSystem",
           "XMLEditor",
           "AnXMLAndXSLT2.0Tool",
        };


        Regex r = new Regex(
            @"(?<=[A-Z])(?=[A-Z][a-z])|(?<=[^A-Z])(?=[A-Z])|(?<=[A-Za-z])(?=[^A-Za-z])"
          );

        List<string> y = new List<string>();
        foreach (string s in tests)
        { 
            var replaced = r.Replace(s, " ");
            y.Add(replaced);
        }
    }


    [Fact]
    public void IsPascalWithNumberTest()
    {
        var input = @"HelloWorld";
        var input2 = @"HelloWorld2";
        var input3 = @"Hello World3";

        Assert.True(ConvertPascalConvention.IsPascal(input));
        Assert.False(ConvertPascalConvention.IsPascal(input2));
        Assert.False(ConvertPascalConvention.IsPascal(input3));
    }

    [Fact]
    public void FromToPascalWithNumbersTest()
    {
        var input = "hello world";
        var to = ConvertPascalConventionWithNumbers.ToConvention(input);
        var from = ConvertPascalConventionWithNumbers.FromConvention(to);

        input = SH.FirstCharUpper(input);

        Assert.Equal(input, from);
    }


}
