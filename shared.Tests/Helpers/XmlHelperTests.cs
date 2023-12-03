namespace shared.Tests
{
    public class XmlHelperTests
    {
        [TestMethod]
        public
#if ASYNC
    async void
#else
    void 
#endif
   ParseAndRemoveNamespacesTest()
        {
            var file = @"D:\_Test\sunamo\SunamoCode\ParseAndRemoveNamespacesTest\a.xlf";
            var c = 
#if ASYNC
    await
#endif
 TF.ReadAllText(file);
            XmlNamespacesHolder h = new XmlNamespacesHolder();


            XmlDocument x = null;

            x = h.ParseAndRemoveNamespacesXmlDocument(c, x.NameTable);
        }
    }
}
