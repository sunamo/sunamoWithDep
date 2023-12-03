using sunamo.Tests.Helpers.List;

namespace Runner
{
    /// <summary>
    /// It was originally for Roslyn
    /// Maybe I will be use for another big unit testing
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Pokud proměnná bude v metodě a ne v třídě, nedávat comment

            //RoslynHelperTests r = new RoslynHelperTests();
            //r.AddXmlDocumentationCommentTest();

            //SqlAOTests sql = new SqlAOTests();
            //ReClasserTests reClasserTests = new ReClasserTests();

            //reClasserTests.FixMeUpTest();
            //sql.FillWithDefaultValuesTest();

            SHTests sh = new SHTests();
            //sh.ReplaceInLineTest();
            //sh.HasTextRightFormatTest();
            //sh.MultiWhitespaceLineToSingleTest();
            sh.SplitAndKeepTest();

            //FSTests fs = new FSTests();

            CATests ca = new CATests();
            //ca.DivideByPercentTest();
            //ca.DivideByPercent2Test();
            //ca.EqualRangesTest2();

            RHCopyTests rHCopyTests = new RHCopyTests();
            //rHCopyTests.CopyTest();


        }
    }
}

