namespace SunamoIni.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void WriteIni()
        {
            IniFile ini = new IniFile(@"E:\vs\Projects\sunamo.Tests\SunamoIni.Tests\test.ini");
            ini.IniWriteValue("Section", "Key", "Value");
            
        }
    }
}
