[TestClass]
public class CLTests
{
    public void ClearCurrentConsoleLineTest()
    {
        CL.WriteLine("abcde");
        CL.ClearCurrentConsoleLine();
        CL.WriteLine("12");
    }

    //[TestMethod]
    public void CmdTableTest()
    {
        var els = "Extra long string";
        els = "C";

        List<List<string>> l = new List<List<string>>();
        l.Add(CA.ToList<string>("A", els));
        l.Add(CA.ToList<string>("B", els));

        CL.CmdTable(l);
    }


}
