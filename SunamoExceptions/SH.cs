namespace SunamoExceptions;

public class SHSE
{
    public static string JoinNL(List<string> l)
    {
        StringBuilder sb = new();
        foreach (var item in l) sb.AppendLine(item);
        var r = string.Empty;
        r = sb.ToString();
        return r;
    }

    public static List<string> SplitNone(string text, params string[] deli)
    {
        return text.Split(deli, StringSplitOptions.None).ToList();
    }

    /// <summary>
    ///     Usage: Exc.MethodOfOccuredFromStackTrace
    ///     Not auto remove empty
    /// </summary>
    /// <param name="p"></param>
    public static List<string> GetLines(string p, bool autoTrim = false)
    {
        List<string> vr = new();
        StringReader sr = new(p);
        string f;
        while ((f = sr.ReadLine()) != null) vr.Add(f);

        if (autoTrim)
        {
            CASE.Trim(vr);
        }

        return vr;
    }

    public static string FirstCharLower(string nazevPP)
    {
        if (nazevPP.Length < 2) return nazevPP;

        var sb = nazevPP.Substring(1);
        return nazevPP[0].ToString().ToLower() + sb;
    }

    /// <summary>
    ///     Convert \r\n to NewLine etc.
    /// </summary>
    /// <param name="delimiter"></param>
    public static string ConvertTypedWhitespaceToString(string delimiter)
    {
        const string nl = @"
";

        switch (delimiter)
        {
            // must use \r\n, not Environment.NewLine (is not constant)
            case "\\r\\n":
            case "\\n":
            case "\\r":
                return nl;
            case "\\t":
                return "\t";
        }

        return delimiter;
    }


    /// <summary>
    ///     Musí tu být. split z .net vrací []
    ///     krom toho je instanční. musel bych měnit hodně kódu kvůli toho
    /// </summary>
    /// <param name="s"></param>
    /// <param name="dot"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static List<string> SplitChar(string s, params char[] dot)
    {
        return s.Split(dot, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    public static List<string> Split(string s, params string[] dot)
    {
        return s.Split(dot, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    /// <summary>
    ///     Usage: BadFormatOfElementInList
    ///     If null, return Consts.nulled
    ///     nemůžu odstranit z sunamo, i tam se používá.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="v"></param>
    /// <returns></returns>
    public static string NullToStringOrDefault(object n, string v)
    {
        ThrowEx.Custom(
        "Tahle metoda vypadala jinak ale jak idiot jsem ji změnil. Tím jak jsem poté přesouval metody tam zpět už je těžké se k tomu dostat.");
        return null;
        //return n == null ? " " + ConstsSE.nulled : AllStringsSE.space + v.ToString();
    }

    /// <summary>
    ///     Usage: BadFormatOfElementInList
    ///     If null, return Consts.nulled
    ///     jsem
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static string NullToStringOrDefault(object n)
    {
        //return NullToStringOrDefault(n, null);
        return n == null ? " " + Consts.nulled : AllStringsSE.space + n;
    }

    /// <summary>
    ///     Usage: Exceptions.MoreCandidates
    ///     není v .net (pouze char), přes split to taky nedává smysl (dá se to udělat i s .net ale bude to pomalejší)
    /// </summary>
    /// <param name="name"></param>
    /// <param name="ext"></param>
    /// <returns></returns>
    public static string TrimEnd(string name, string ext)
    {
        while (name.EndsWith(ext)) return name.Substring(0, name.Length - ext.Length);

        return name;
    }
}
