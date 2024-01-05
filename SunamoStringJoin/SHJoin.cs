namespace SunamoStringJoin;

public class SHJoin
{
    static Type type = typeof(SHJoin);

    #region MyRegion

    ///// <summary>
    /////     This can be only one
    ///// </summary>
    ///// <param name="delimiter"></param>
    ///// <param name="parts"></param>
    //public static string JoinIList(object delimiter, IList parts)
    //{
    //    // TODO: Delete after all app working
    //    return JoinString(delimiter, parts);
    //} //

    #endregion

    /// <summary>
    ///     Usage: Exceptions.MoreCandidates
    ///     Will be delete after final refactoring
    ///     Automaticky o�e�e posledn� A1
    /// </summary>
    /// <param name="delimiter"></param>
    /// <param name="parts"></param>
    [ObjectObsolete]
    public static string JoinString(string delimiter, List<string> parts)
    {
        // TODO: Delete after all app working, has here method Join with same arguments
        return Join(delimiter.ToString(), parts);
    }

    #region MyRegion
    ///// <summary>
    /////     A2 Must be string due to The call is ambiguous between the following methods or properties: 'string.Join(object,
    /////     IList)' and 'SHJoin.JoinIList, object)'
    ///// </summary>
    ///// <param name="delimiter"></param>
    ///// <param name="parts"></param>
    //public static string Join(object delimiter, IList parts)
    //{
    //    string s = delimiter.ToString();
    //    StringBuilder sb = new StringBuilder();
    //    if (parts.Count() == 1 && parts.FirstOrNull().GetType() == Types.tString)
    //    {
    //        sb.Append(ListToString(parts.FirstOrNull()) + s);
    //    }
    //    else if (parts.GetType() == Types.tString)
    //    {
    //        return parts.ToString();
    //    }
    //    else
    //    {
    //        foreach (object item in parts)
    //        {
    //            sb.Append(ListToString(item) + s);
    //        }
    //    }

    //    string d = sb.ToString();
    //    //return d.Remove(d.Length - (name.Length - 1), name.Length);
    //    int to = d.Length - s.Length;
    //    return to > 0 ? d.Substring(0, to) : d;
    //    //return d;
    //}

    //    /// <summary>
    /////     Usage: Exc.TypeAndMethodName
    ///// </summary>
    ///// <param name="dot"></param>
    ///// <param name="p"></param>
    ///// <returns></returns>
    //public static string Join(string dot, List<string> p)
    //{
    //    return string.Join(dot, p);
    //}

    ///// <summary>
    /////     Automaticky o�e�e posledn� znad A1
    /////     Pokud m� inty v A2, pou�ij metodu JoinMakeUpTo2NumbersToZero
    ///// </summary>
    ///// <param name="delimiter"></param>
    ///// <param name="parts"></param>
    //public static string Join(object delimiter, params string[] parts)
    //{
    //    if (parts.Length == 0)
    //    {
    //        ThrowEx.Custom("Not passed any parts, only delimiter: " + delimiter);
    //    }

    //    var enu = /*CA.ToEnumerable*/ CA.ToListString(parts);
    //    if (delimiter is IList enumerable && delimiter.GetType() != Types.tString)
    //    {
    //        IList ie = enumerable;

    //        if (ie.Count() > 1 && enu.Count() == 1)
    //        {
    //            ThrowEx.Custom(sess.i18n(XlfKeys.ProbablyWasCalledWithSwithechDelimiterAndParts));
    //        }
    //    }

    //    // JoinString point to Join with implementation
    //    return JoinString(delimiter.ToString(), enu);
    //}
    #endregion

    ///// <summary>
    /////     Start at 0
    /////     Usage: MethodOfOccuredFromStackTrace
    ///// </summary>
    ///// <param name="input"></param>
    ///// <param name="lenght"></param>
    ///// <returns></returns>
    //public static string SubstringIfAvailable(string input, int lenght)
    //{
    //    return input.Length > lenght ? input.Substring(0, lenght) : input;
    //}

    ////
    ///// <summary>
    /////     Usage: Exc.TypeAndMethodName
    /////     Remove with A2
    ///// </summary>
    ///// <param name="t"></param>
    ///// <param name="ch"></param>
    //public static string RemoveAfterFirst(string t, char ch)
    //{
    //    int dex = t.IndexOf(ch);
    //    return dex == -1 || dex == t.Length - 1 ? t : t.Substring(0, dex);
    //}

    ///// <summary>
    /////     Usage: Exc.MethodOfOccuredFromStackTrace
    ///// </summary>
    ///// <param name="item"></param>
    ///// <returns></returns>
    //public static string FirstLine(string item)
    //{
    //    List<string> lines = GetLines(item);
    //    return lines.Count == 0 ? string.Empty : lines[0];
    //}

    ///// <summary>
    /////     Usage: Exc.TypeAndMethodName
    ///// </summary>
    ///// <param name="v"></param>
    ///// <param name="s"></param>
    ///// <returns></returns>
    //public static string TrimStart(string v, string s)
    //{
    //    while (v.StartsWith(s))
    //    {
    //        v = v.Substring(s.Length);
    //    }

    //    return v;
    //}

    /// <summary>
    ///     Usage: Exc.TypeAndMethodName
    /// </summary>
    /// <param name="dot"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    public static string Join(string dot, List<string> p)
    {
        return string.Join(dot, p);
    }

    /// <summary>
    /// Can be use also with IList<string> - will take first element of A2
    ///
    ///     Automaticky o�e�e posledn� znad A1
    ///     Pokud m� inty v A2, pou�ij metodu JoinMakeUpTo2NumbersToZero
    /// </summary>
    /// <param name="delimiter"></param>
    /// <param name="parts"></param>
    [ObjectParamsObsolete]
    public static string Join(object delimiter, params string[] parts)
    {
        //if (parts.Length == 0)
        //{
        //    // házelo mi to chybu, takže vrátím prostě SE
        //    //ThrowEx.Custom("Not passed any parts, only delimiter: " + delimiter);
        //    return Consts.se;
        //}

        //IList enu = parts.ToList();
        //if (delimiter is IList enumerable && delimiter.GetType() != Types.tString)
        //{
        //    IList ie = enumerable;

        //    if (ie.Count > 1 && enu.Count == 1)
        //    {
        //        ThrowEx.Custom(sess.i18n(XlfKeys.ProbablyWasCalledWithSwithechDelimiterAndParts));
        //    }
        //}

        //// JoinString point to Join with implementation
        //return JoinString(delimiter.ToString(), enu);

        return null;
    }


    /// <summary>
    ///     Usage: Exceptions.StringContainsUnallowedSubstrings
    ///     Automaticky o�e�e posledn� znad A1
    ///     Pokud m� inty v A2, pou�ij metodu JoinMakeUpTo2NumbersToZero
    /// </summary>
    /// <param name="delimiter"></param>
    /// <param name="parts"></param>
    public static string JoinArray(object delimiter, params string[] enu)
    {
        //IList enu = CA.ToListStringIEnumerable2(parts);
        if (delimiter is IList /*enumerable*/ && delimiter.GetType() != Types.tString)
        {
            IList ie = enu/*merable*/;

            if (ie.Count > 1 && enu.Length == 1)
            {
                ThrowEx.Custom(sess.i18n(XlfKeys.ProbablyWasCalledWithSwithechDelimiterAndParts));
            }
        }

        // JoinString point to Join with implementation
        return SHJoin.Join(delimiter.ToString(), enu);
    }

    public static string JoinNL(StringBuilder sb, List<string> l)
    {
        sb.Clear();
        foreach (var item in l)
        {
            sb.AppendLine(item);
        }
        return sb.ToString();
    }

    public static string JoinChars(params char[] ch)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in ch)
        {
            sb.Append(item);
        }
        return sb.ToString();
    }

    public static string JoinComma(params string[] args)
    {
        return SHJoin.Join(AllStringsSE.comma, args);
    }

    public static string JoinDictionary(IDictionary<string, string> dict, string delimiterBetweenKeyAndValue, string delimAfter)
    {
        return JoinKeyValueCollection(dict.Keys.ToList(), dict.Values.ToList(), delimiterBetweenKeyAndValue, delimAfter);
    }
    public static string JoinDictionary(Dictionary<string, string> dictionary, string delimiter)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in dictionary)
        {
            sb.AppendLine(item.Key + delimiter + item.Value);
        }
        return sb.ToString();
    }

    public static string JoinKeyValueCollection(IList v1, IList v2, string delimiterBetweenKeyAndValue, string delimAfter)
    {
        StringBuilder sb = new StringBuilder();
        var v2List = new List<object>(v2.Count);
        foreach (var item in v2)
        {
            v2List.Add(item);
        }
        int i = 0;
        foreach (var item in v1)
        {
            sb.Append(item + delimiterBetweenKeyAndValue + v2List[i++] + delimAfter);
        }

        return SHSE.TrimEnd(sb.ToString(), delimAfter);
    }

    public static string JoinPairs(params string[] parts)
    {
        return JoinPairs(AllStringsSE.sc, AllStringsSE.cs, parts);
    }
    public static string JoinPairs(string firstDelimiter, string secondDelimiter, params string[] parts)
    {
        InitApp.TemplateLogger.NotEvenNumberOfElements(type, "JoinPairs", @"args", parts);
        InitApp.TemplateLogger.AnyElementIsNull(type, "JoinPairs", @"args", parts);

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < parts.Length; i++)
        {
            sb.Append(parts[i++] + firstDelimiter);
            sb.Append(parts[i] + secondDelimiter);
        }
        return sb.ToString();
    }

    //public static string JoinStringParams(string name, params string[] labels) { return null; }
    //public static string JoinStringParams(object delimiter, params string[] parts) { return null; }
    //public static string JoinPairs(params string[] args){return null;}
    //public static string JoinString(object delimiter, IList parts){return null;}
    //public static string Join(IList parts, object delimiter){return null;}
    //public static string JoinIList(object delimiter, IList parts){return null;}
    //public static string Join(char p, IList vsechnyFotkyVAlbu){return null;}
    //public static string Join(char p, int[] vsechnyFotkyVAlbu){return null;}
    //public static string Join(char name, params string[] labels){return null;}
    //public static string Join(List<string> labels, char name){return null;}
    //public static string JoinNL(IList p){return null;}
    //public static string JoinNL(params string[] p){return null;}
    //public static string JoinSpace(IList<string> nazev){return null;}
    //public static string JoinString(string name, IList labels){return null;}
    //public static string JoinStringExceptIndexes(string name, IList labels, params int[] v2){return null;}
    //public static string JoinMoreWords(char v, params string[] fields){return null;}
    //public static string JoinWithoutTrim(string p, IList ownedCatsLI){return null;}
    //public static string JoinIList(char name, IList labels){return null;}
    //public static string JoinWithoutEndTrimDelimiter(string name, params string[] labels){return null;}
    //public static string JoinFromIndex(int p, char delimiter, IList<string> tokeny){return null;}
    //public static string JoinFromIndex(int dex, string delimiter, IList<string> parts){return null;}
    //public static string JoinToIndex(int dex, string delimiter, IList<string> parts){return null;}
    //public static string JoinMakeUpTo2NumbersToZero(char p, params int[] args){return null;}
    //public static string JoinDictionary(Dictionary<string, string> dictionary, string v){return null;}
    /* Result of refactoring Join methods:
    * params have only two:
    * Join
    * JoinString
    */
    [ObjectParamsObsolete]
    public static string JoinStringParams(object delimiter, params string[] parts)
    {
        return null;
        // TODO: Delete after all app working, has here method Join with same arguments
        //return SHJoin.Join(delimiter, CA.ToListStringIEnumerable2(parts));
    }


    public static bool IsNumber(string input, string value, bool invert)
    {
        input = SHReplace.ReplaceAll(input, "", AllLists.numberPoints.ToArray());
        long l = 0;
        return BTS.Invert(long.TryParse(input, out l), invert);
    }

    // refaktorovat to tady, nemuzu zavolat params z IEnum . Teprve ve working method zkontroluji co je za typ a pripadne pretypuji
    /// <summary>
    /// If element will be number, wont wrap with qm.
    /// </summary>
    /// <param name="delimiter"></param>
    /// <param name="parts"></param>
    public static string JoinMoreWords(object delimiter, params string[] parts)
    {
        parts = CA.WrapWithIfFunc(IsNumber, true, AllStringsSE.space, AllStringsSE.qm, parts).ToArray();
        return SHJoin.Join(delimiter, parts);
    }
    public static string JoinStringExceptIndexes(object delimiter, IList parts, params int[] v2)
    {
        string s = delimiter.ToString();
        StringBuilder sb = new StringBuilder();
        int i = -1;
        foreach (string item in parts)
        {
            i++;
            if (v2.Any(d => d == i))
            {
                continue;
            }
            sb.Append(item + s);
        }
        string d = sb.ToString();
        //return d.Remove(d.Length - (name.Length - 1), name.Length);
        int to = d.Length - s.Length;
        if (to > 0)
        {
            return d.Substring(0, to);
        }
        return d;
        //return d;
    }
    /// <summary>
    /// Ořeže poslední znak - delimiter
    /// </summary>
    /// <param name="dex"></param>
    /// <param name="delimiter2"></param>
    /// <param name="parts"></param>
    public static string JoinFromIndex(int dex, object delimiter2, IList parts)
    {
        string delimiter = delimiter2.ToString();
        StringBuilder sb = new StringBuilder();
        int i = 0;
        foreach (var item in parts)
        {
            if (i >= dex)
            {
                sb.Append(item + delimiter);
            }
            i++;
        }
        string vr = sb.ToString();
        return vr.Substring(0, vr.Length - 1);
        //return SH.SubstringLength(vr, 0, vr.Length - 1);
    }

    /// <summary>
    ///     Usage: Exceptions.MoreCandidates
    /// </summary>
    /// <param name="parts"></param>
    /// <param name="removeLastNl"></param>
    /// <returns></returns>
    public static string JoinNL(List<string> parts, bool removeLastNl = false)
    {
        string nl = Consts.nl;
        string result = JoinString(nl, parts);
        if (removeLastNl)
        {
            result = SHSE.TrimEnd(result, nl);
        }

        return result;
    }

    /// <summary>
    ///
    ///
    ///     Usage: Exceptions.MoreCandidates
    ///     Will be delete after final refactoring
    ///     Automaticky o�e�e posledn� A1
    /// </summary>;
    /// <param name="delimiter"></param>
    /// <param name="parts"></param>
    public static string JoinString(object delimiter, List<string> parts)
    {
        // TODO: Delete after all app working, has here method Join with same arguments
        return SHJoin.Join(delimiter.ToString(), parts);
    }

    /// <summary>
    /// A1 won't be included
    /// </summary>
    /// <param name="dex"></param>
    /// <param name="delimiter"></param>
    /// <param name="parts"></param>
    public static string JoinToIndex(int dex, object delimiter2, IList parts)
    {
        string delimiter = delimiter2.ToString();
        StringBuilder sb = new StringBuilder();
        int i = 0;
        foreach (var item in parts)
        {
            if (i < dex)
            {
                sb.Append(item + delimiter);
            }
            i++;
        }
        string vr = sb.ToString();
        return vr.Substring(0, vr.Length - 1);
    }
    public static string JoinWithoutEndTrimDelimiter(object name, params string[] parts)
    {
        // TODO: Delete after making all solutions working
        return JoinWithoutTrim(name, parts);
    }

    public static string JoinSpace(List<string> parts)
    {
        return SHJoin.JoinString(AllStrings.space, parts);
    }

    public static string JoinTimes(int times, string dds)
    {
        // Working just for char
        //return new String(dds, times);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < times; i++)
        {
            sb.Append(dds);
        }
        return sb.ToString();
    }

    public static string JoinNL(params string[] parts)
    {
        return SHJoin.JoinString(Environment.NewLine, parts.ToList());
    }

    public static string JoinWithoutTrim(object p, IList parts)
    {
        StringBuilder sb = new StringBuilder();
        foreach (object item in parts)
        {
            sb.Append(item.ToString() + p);
        }
        return sb.ToString();
    }

    public static string JoinSentences(bool addAfterLast, params string[] pDescription)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in pDescription)
        {
            var t = item.Trim();
            if (!string.IsNullOrEmpty(item))
            {
                sb.Append(item);
                if (!item.EndsWith(AllStrings.dotSpace))
                {
                    sb.Append(AllStrings.dotSpace);
                }
            }
        }

        var result = sb.ToString();

        if (!addAfterLast)
        {
            result = SHSE.TrimEnd(result, AllStrings.dotSpace);
        }
        return result;
    }
}
