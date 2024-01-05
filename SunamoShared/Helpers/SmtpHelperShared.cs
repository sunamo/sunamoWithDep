namespace SunamoShared.Helpers;

public partial class SmtpHelper
{
    public static int ParsePort(string s)
    {
        return BTS.ParseInt(s, NumConsts.defaultPortIfCannotBeParsed);
    }
}
