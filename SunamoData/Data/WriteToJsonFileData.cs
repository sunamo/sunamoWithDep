namespace SunamoData.Data;

public class WriteToJsonFileData
{
    public Newtonsoft.Json.Formatting formatting = Newtonsoft.Json.Formatting.None;
    public bool append = false;
    public Action<string> phWinCode = null;
}
