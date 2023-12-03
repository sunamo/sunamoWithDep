public class RoslynParserTests
{
    [Fact]
    public static void ParseVariablesTest()
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
}
";

        const string var1 = "var1";
        const string var2 = "var2";
        const string var3 = "var3";

        var actual = RoslynParser.ParseVariables(s);
        Assert.Equal<string>(CA.ToListString(var1, var2, var3), CA.ToListString(actual.Item1));
        Assert.Equal<string>(CA.ToListString(var3, var2), actual.Item2);
    }

    [Fact]
    /// <summary>
    /// 
    /// </summary>
    public static void IsCSharpCodeTest()
    {
        // Unfortunately is c# code
        var input1 = "abc";
        var input2 = @"using System;

";

        // Everything here is c#
        var input3 = @"Nebyly nalezeny žádné sloupce
foreach (DataRow item in dt.Rows)
[i] = o[
Uloženo do souboru
Base
Tables.
if (o != null)
= MSTableRowParse.
protected void ParseRow(object[] o)
Base
V prvním sloupci není řádek ID nebo ID*
public void SelectInTable()
Tabulka nemůže mít jen 1 sloupec.
void InsertToTable3(
public static string Get
return MSStoredProceduresI.ci.SelectNameOfID(Tables.
public static string Get
return MSStoredProceduresI.ci.SelectNameOfID(Tables.
Snažíte se převést na int strukturovaný(složitý) datový typ
Snažíte se převést datový typ, pro který není implementována větev
Datový typ DateTimeOffset a Timestamp není podporován.
Not supported convert binary data to string
Strukturované datové typy nejsou podporovány.
Univerzální datové typy nejsou podporovány.
Variantní datové typy nejsou podporovány.
Xml datový typ není podporován
public void DisplayInfo()
private void SetP(string p, HtmlGenericControl lblName, HtmlGenericControl pName)
string t = p.Trim();
        if (t !=
protected void SetPDateTime(DateTime dt, string p, HtmlGenericControl lblName, HtmlGenericControl pName)
private void SetVisible(bool b)";
        var input3L = SH.GetLines(input3);

        //Assert.False(RoslynParser.IsCSharpCode(input1));
        Assert.True(RoslynParser.IsCSharpCode(input2));

        StringBuilder isCs = new StringBuilder();
        StringBuilder isNotCs = new StringBuilder();

        foreach (var item in input3L)
        {
            if (RoslynParser.IsCSharpCode(item))
            {
                isCs.AppendLine(item);
            }
            else
            {
                isNotCs.AppendLine(item);
            }
        }

        TextOutputGenerator t = new TextOutputGenerator();
        t.Header("Is c#");
        t.AppendLine(isCs);
        t.Header("Is not c#");
        t.AppendLine(isNotCs);

        var s = t.ToString();

        // Cant be use because Presentation is not on nuget and UT projets does nto have Assemblies tab
        //Clipboard.SetText(s);

        //DebugLogger.Instance.WriteLine(s);
    }
}
