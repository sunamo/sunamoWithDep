public class ConvertCamelConventionTests
{
    [Fact]
    public void IsCamelTest()
    {
        var input = @"helloWorld";
        var input2 = @"HelloWorld 3";
        var input3 = @"hello World";

        //Assert.Equal(true, ConvertCamelConvention.IsCamel(input));
        Assert.Equal(false, ConvertCamelConvention.IsCamel(input2));
        Assert.Equal(false, ConvertCamelConvention.IsCamel(input3));
    }
}
