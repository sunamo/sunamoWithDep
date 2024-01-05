namespace SunamoShared.Helpers.FileSystem;


public static partial class SF
{
    static Type type = typeof(SF);

    public const string replaceForSeparatorString = AllStrings.lowbar;
    public static readonly char replaceForSeparatorChar = AllChars.lowbar;
    public static string dDeli = "|";


    /// <summary>
    /// Without last |
    /// DateTime is format with DTHelperEn.ToString
    /// </summary>
    /// <param name="o"></param>
    public static string PrepareToSerialization(params string[] o)
    {
        return PrepareToSerializationWorker(CAG.ToList<string>(o), true, dDeli);
    }

    ///// <summary>
    ///// Return without last
    ///// DateTime is serialize always in english format
    ///// Opposite method: DTHelperEn.ToString<>DTHelperEn.ParseDateTimeUSA
    ///// </summary>
    ///// <param name="pr"></param>
    //public static string PrepareToSerialization2(params string[] pr)
    //{
    //    var ts = CA.ToListString(pr);
    //    return PrepareToSerializationWorker(ts, true, separatorString);
    //}

    /// <summary>
    ///
    /// DateTime is format with DTHelperEn.ToString
    /// </summary>
    /// <param name="o"></param>
    /// <param name="removeLast"></param>
    /// <param name="separator"></param>
    private static string PrepareToSerializationWorker(IList<string> o, bool removeLast, string separator)
    {
        var list = o.ToList();
        if (separator == replaceForSeparatorString)
        {
            ThrowEx.Custom("replaceForSeparatorString is the same as separator");
        }
        CA.Replace(list, separator, replaceForSeparatorString);
        CA.Replace(list, Environment.NewLine, AllStrings.space);
        CA.Trim(list);
        string vr = SH.GetString(list, separator.ToString());

        if (removeLast)
        {
            if (vr.Length > 0)
            {
                return vr.Substring(0, vr.Length - 1);
            }
        }

        return vr;
    }


}
