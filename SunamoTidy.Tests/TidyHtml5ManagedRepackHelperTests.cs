/* TidyHtml is not possible use with .NET5
 * Before in NET4 UT works fine
 * Now in net472 app works fine
 * But NET5 UT just not see any of classes from nuget package
*/

//using TidyManaged;

//[TestClass]
//public class TidyHtml5ManagedRepackHelperTests
//{
//    [TestMethod]
//    public void TidyHtml5ManagedRepackHelperTest()
//    {
//        var content = TF.ReadAllText(@"D:\_Test\sunamo\SunamoTidy\FormatHtml\1.html");
//        string actual = null;
//        //actual = TidyHtml5ManagedRepackHelper.FormatHtml(content);
//        TF.WriteAllText(@"D:\_Test\sunamo\SunamoTidy\FormatHtml\1_Out.html", actual);
//    }

//    [TestMethod]
//    public void TidyHtml5ManagedRepackHelperTest2()
//    {
//        string dirtyHtml = "<p>Test";
//        string expected = "<p>Test</p>";
//        string actual = null;

//        using (Document doc = Document.FromString(dirtyHtml))
//        {
//            doc.OutputBodyOnly = AutoBool.Yes;
//            doc.Quiet = true;
//            doc.CleanAndRepair();
//            // Add 2x newline, therefore Trim()
//            actual = doc.Save().Trim();
//        }

//        Assert.AreEqual(expected, actual);
//    }
//}
