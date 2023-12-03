namespace SunamoTidy.Tests
{
    [TestClass]
    public class TidyManagedHelperWithoutMockTests
    {
        //[TestMethod]
        public void FormatHtmlTest()
        {
            var content = TF.ReadAllText(@"D:\_Test\sunamo\SunamoTidy\FormatHtml\1.html");
            string actual = null;
            //actual = TidyManagedHelper.FormatHtml(content);
            TF.WriteAllText(@"D:\_Test\sunamo\SunamoTidy\FormatHtml\1_Out.html", actual);
        }
    }
}
