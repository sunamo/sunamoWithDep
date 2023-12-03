public class XmlAgilityDocumentManipulationWithoutMockTests
{
    //[Fact]
    public void XmlAgilityDocumentTest()
    {
        var c = @"D:\_Test\sunamo\sunamo\Xml\XmlAgilityDocumentTests\input.csproj";
        XmlAgilityDocument x = new XmlAgilityDocument();
        x.Load(c);
        var nodes = HtmlAgilityHelper.NodesWithAttrWildCard(x.hd.DocumentNode, true, "Compile", Consts.Include, "*.cs", true);

        foreach (var item in nodes)
        {
            item.Remove();
        }

        x.path = FS.ChangeFilename(x.path, "output.csproj", false);
        x.Save();
    }
}
