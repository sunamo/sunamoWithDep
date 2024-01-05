namespace SunamoDateTime.DT;


/// <summary>
/// When date parts are delimited by -
/// Next relative methods are in DTHelperFormalizedWithT / DTHelperCode
/// </summary>
public partial class DTHelperFormalized
{
    public static string DateTimeToStringDashed(DateTime dt)
    {
        return DateTimeToStringFormalizeDate(dt);
    }

    public static bool IsFormalizedDate(string v)
    {
        var dt = DTHelperFormalized.StringToDateTimeFormalizeDate(v);
        return dt != DateTime.MinValue;
    }
}
