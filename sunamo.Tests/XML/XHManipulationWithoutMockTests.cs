public class XHManipulationWithoutMockTests : XmlTestsBase
{
    //[Fact]
    public
#if ASYNC
    async void
#else
    void
#endif
 RemoveFirstElementTest()
    {
        var content =
#if ASYNC
    await
#endif
 TF.ReadAllText(pathXlf);

        var xd = XDocument.Parse(content);
        // return zero
        var descendants = xd.Descendants("trans-unit");
        foreach (var item in descendants)
        {
            item.Remove();
        }

        var outer = xd.ToString();
    }
}
