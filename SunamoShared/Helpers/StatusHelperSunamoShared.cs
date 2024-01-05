namespace SunamoShared.Helpers;


public partial class StatusHelperSunamo
{
    public static TypeOfMessage IsStatusMessage(string resp)
    {
        var r = resp;
        return IsStatusMessage(ref r);
    }

    /// <summary>
    /// If dont start with none, return Ordinal
    /// </summary>
    /// <param name = "resp"></param>
    public static TypeOfMessage IsStatusMessage(ref string resp)
    {
        if (SHTrim.TrimIfStartsWith(ref resp, error))
        {
            return TypeOfMessage.Error;
        }
        else if (SHTrim.TrimIfStartsWith(ref resp, warning))
        {
            return TypeOfMessage.Warning;
        }
        else if (SHTrim.TrimIfStartsWith(ref resp, success))
        {
            return TypeOfMessage.Success;
        }
        else if (SHTrim.TrimIfStartsWith(ref resp, info))
        {
            return TypeOfMessage.Information;
        }
        else if (SHTrim.TrimIfStartsWith(ref resp, information))
        {
            return TypeOfMessage.Information;
        }
        else if (SHTrim.TrimIfStartsWith(ref resp, appeal))
        {
            return TypeOfMessage.Appeal;
        }

        return TypeOfMessage.Ordinal;
    }
}
