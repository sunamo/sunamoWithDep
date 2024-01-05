namespace SunamoShared.win.Powershell;


public class PowershellParser : IPowershellParser
{
    public static IPowershellParser p = null;
    public static PowershellParser ci = new PowershellParser();

    private PowershellParser()
    {

    }

    public List<string> ParseToParts(string d, string charWhichIsNotContained)
    {
        return p.ParseToParts(d, charWhichIsNotContained);
    }
}
