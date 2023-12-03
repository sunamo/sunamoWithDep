public class RoslynHelperTests
{
    [Fact]
    public void AddXmlDocumentationCommentTest()
    {
        var s = @"
class C1{
   private int var1;
   public string var2;

   void action1()
    {
       int var3;
       var3=var1*var1;
       var2=""Completed"";
   }


   void action2()
    {
var1 = 5;
       var2=""Completed"";
   }
}";

        RoslynHelper.AddWhereIsUsedVariablesInMethods(s);
    }

    /// <summary>
    /// better is use D:\pa\CodeFormatter\ with lang attr
    /// </summary>
    [Fact]
    public void FormatTest()
    {
        string input = @"    public partial class InsertIntoXlfAndConstantCsUC : UserControl, IUserControl, IKeysHandler, IUserControlWithSettingsManager, IUserControlWithSuMenuItemsList, IWindowOpener, IUserControlWithSizeChange
    {
        #region Class data
        static InsertIntoXlfAndConstantCsUC instance = null;
#endregion
}";



        var s = RoslynHelper.Format(input);
        Debug.WriteLine(s);
    }


}
