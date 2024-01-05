namespace SunamoConverters.Converts;

public class ConvertCamelConventionWithNumbers
{
    public static bool IsCamelWithNumber(string r)
    {
        if (r.ToLower() == r && !r.Contains(" "))
        {
            return true;
        }
        var s = ToConvention(r);

        return s == r;
    }

    /// <summary>
    /// wont include numbers
    /// </summary>
    /// <param name="p"></param>
    public static string ToConvention(string p)
    {
        return SH.FirstCharLower(ConvertPascalConvention.ToConvention(p));
    }

    public static string FromConvention(string p, bool firstCharUpper = false)
    {
        var r = Regex.Replace(p, "[a-z][A-Z]", m => $"{m.Value[0]} {char.ToLower(m.Value[1])}").ToLower();
        if (firstCharUpper)
        {
            return SH.FirstCharUpper(r);
        }
        return r;
    }
}
