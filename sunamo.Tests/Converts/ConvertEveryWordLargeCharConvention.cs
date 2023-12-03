public class ConvertEveryWordLargeCharConventionTests
{
    [Fact]
    public void ToConventionTest()
    {
        var input = "Grace - You Don't Own";
        var expected = "Grace  You Don't Own";

        var actual = ConvertEveryWordLargeCharConvention.ToConvention(input);
        Assert.Equal(expected, actual);

        input = "Grace - You1 Don's Own Me 5 (Ft. g eazy)";
        expected = "Grace  You1 Don's Own Me 5 (Ft. G Eazy)";

         actual = ConvertEveryWordLargeCharConvention.ToConvention(input);
        Assert.Equal(expected, actual);
    }
}
