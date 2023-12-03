public class ConvertCamelConventionWithNumbersTests
{
    [Fact]
    public void IsCamelWithNumberTest()
    {
        var input = @"helloWorld1";
        var input2 = @"helloWorld 2";
        var input3 = @"hello World3";
        var input4 = @"hello";

        //Assert.Equal(true, ConvertCamelConventionWithNumbers.IsCamelWithNumber(input));
        Assert.Equal(false, ConvertCamelConventionWithNumbers.IsCamelWithNumber(input2));
        Assert.Equal(false, ConvertCamelConventionWithNumbers.IsCamelWithNumber(input3));
        Assert.Equal(true, ConvertCamelConventionWithNumbers.IsCamelWithNumber(input4));
    }

    [Fact]
    public void FromToCamelWithNumbersTest()
    {
        // w must be lower
        var input = "hello world";
        var to = ConvertCamelConventionWithNumbers.ToConvention(input);
        var from = ConvertCamelConventionWithNumbers.FromConvention(to);

        Assert.Equal(input, from);
    }
}
