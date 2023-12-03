public class RHTests
{
    //

    [Fact] 
    public void DumpAsStringTest()
    {

    }

        [Fact]
    public void GetValuesOfPropertyOrFieldTest()
    {
        // FromTo - simple variables
        FromTo ft = new FromTo(0, 1);

        List<string> onlyNames = new List<string>();

        var r = SH.Join(Environment.NewLine, RH.GetValuesOfPropertyOrField(ft, onlyNames.ToArray()));

        onlyNames.Add("from");
        var r2 = SH.Join(Environment.NewLine, RH.GetValuesOfPropertyOrField(ft, onlyNames.ToArray()));

        // UploadFile - properties
        UploadFile uf = new UploadFile();
        uf.Filename = "d";
        uf.Name = "name";

        onlyNames.Clear();
        
        var r3 = SH.Join(Environment.NewLine, RH.GetValuesOfPropertyOrField(uf, onlyNames.ToArray()));

        onlyNames.Add("Name");
        var r4 = SH.Join(Environment.NewLine, RH.GetValuesOfPropertyOrField(uf, onlyNames.ToArray()));

        int i = 0;
    }
}
