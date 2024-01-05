using SunamoI18N;

namespace SunamoStringSplit;



public partial class SHSplit : SHData
{
    public static List<string> SplitList(string parametry, List<string> deli)
    {
        return Split(StringSplitOptions.RemoveEmptyEntries, parametry, deli.ToArray());
    }

    public static List<string> SplitCharList(string parametry, List<char> deli)
    {
        return Split(StringSplitOptions.RemoveEmptyEntries, parametry, deli.ConvertAll(d => d.ToString()).ToArray());
    }

    public static List<string> SplitMore(string parametry, params string[] deli)
    {
        return Split(StringSplitOptions.RemoveEmptyEntries, parametry, deli);
    }

    public static List<string> SplitCharMore(string parametry, params char[] deli)
    {
        return Split(StringSplitOptions.RemoveEmptyEntries, parametry, ((IEnumerable<char>)deli).ToList().ConvertAll(d => d.ToString()).ToArray());
    }

    public static List<string> Split(string parametry, string deli)
    {
        return Split(StringSplitOptions.RemoveEmptyEntries, parametry, deli);
    }

    public static List<string> SplitChar(string parametry, char deli)
    {
        return Split(StringSplitOptions.RemoveEmptyEntries, parametry, (new List<char>([deli]).ConvertAll(d => d.ToString()).ToArray()));
    }

    public static List<string> SplitByIndexes(string input, List<int> bm)
    {
        List<string> d = new List<string>(bm.Count + 1);
        bm.Sort();
        string before, after;
        before = input;

        for (int i = bm.Count - 1; i >= 0; i--)
        {
            (before, after) = SH.GetPartsByLocationNoOutInt(before, bm[i]);
            d.Insert(0, after);
        }

        (before, after) = SH.GetPartsByLocationNoOutInt(before, bm[0]);
        d.Insert(0, before);
        d.Reverse();
        return d;
    }

    ///// <summary>
    ///// Zde to dává smysl, potřebuji i v SE
    ///// </summary>
    ///// <param name="n"></param>
    ///// <param name="v"></param>
    ///// <returns></returns>
    //public static string NullToStringOrDefault(object n, string v)
    //{
    //    return se.SH.NullToStringOrDefault(n, v);
    //}

    ///// <summary>
    /////     Nemůže to být string[], protože jak předávám třeba AllCharsSE.whiteSpacesChars tak mi to z List
    /////     <char>
    /////         udělá Object[]<List
    /////         <char>
    /////             >
    /////             Usage: Exc.TypeAndMethodName
    ///// </summary>
    ///// <param name="parametry"></param>
    ///// <param name="deli"></param>
    ///// <returns></returns>
    //public static List<string> Split(string parametry, params string[] deli)
    //{
    //    return Split(StringSplitOptions.RemoveEmptyEntries, parametry, deli);
    //}


    //public static List<string> Split(string parametry, List<string> deli)
    //{
    //    return Split(StringSplitOptions.RemoveEmptyEntries, parametry, deli);
    //}

    //public static List<string> Split(string parametry, List<char> deli)
    //{
    //    return Split(StringSplitOptions.RemoveEmptyEntries, parametry, deli);
    //}

    /// <summary>
    /// With these
    /// </summary>
    /// <param name="stringSplitOptions"></param>
    /// <param name="text"></param>
    /// <param name="deli"></param>
    public static List<string> Split(StringSplitOptions stringSplitOptions, string text, params string[] deli)
    {
        if (deli == null || deli.Count() == 0)
        {
            ThrowEx.Custom(sess.i18n(XlfKeys.NoDelimiterDetermined));
        }
        //var ie = CA.OneElementCollectionToMulti(deli);
        //var deli3 = CA.ToListStringIEnumerable2(ie);
        var result = text.Split(deli, stringSplitOptions).ToList();
        CASE.Trim(result);
        if (stringSplitOptions == StringSplitOptions.RemoveEmptyEntries)
        {
            result = result.Where(d => d.Trim() != string.Empty).ToList();
        }

        return result;
    }

    private static List<string> Split(StringSplitOptions removeEmptyEntries, string parametry, List<char> deli)
    {
        List<char> t = deli.ToList();

        string[] sep = new string[t.Count()];
        for (int i = 0; i < sep.Length; i++)
        {
            sep[i] = t[i].ToString();
        }

        List<string> result = parametry.Split(sep, removeEmptyEntries).ToList();

        return result;
    }

    private static List<string> SplitChar(StringSplitOptions removeEmptyEntries, string parametry,
        params char[] deli)
    {
        List<char> t = deli.ToList();

        string[] sep = new string[t.Count()];
        for (int i = 0; i < sep.Length; i++)
        {
            sep[i] = t[i].ToString();
        }

        List<string> result = parametry.Split(sep, removeEmptyEntries).ToList();

        return result;
    }




    public static List<string> SplitBySpaceAndPunctuationCharsAndWhiteSpaces(string s)
    {
        return s.Split(s_spaceAndPuntactionCharsAndWhiteSpaces).ToList();
    }



    public static List<string> SplitAndKeepDelimiters(string originalString, List<string> ienu)
    {
        //var ienu = (IList)deli;
        var vr = Regex.Split(originalString, @"(?<=[" + string.Join("", ienu) + "])");
        return vr.ToList();
    }

    /// <summary>
    /// In case that delimiter cannot be found, to A2,3 set null
    /// Before calling this method I must assure that A1 havent A4 on end
    /// </summary>
    /// <param name="input"></param>
    /// <param name="filePath2"></param>
    /// <param name="fileName"></param>
    /// <param name="backslash"></param>
    public static void SplitByLastCharToTwoParts(string input, out string filePath, out string fileName, char delimiter)
    {
        int dex = input.LastIndexOf(delimiter);
        if (dex != -1)
        {
            SplitByIndex(input, dex, out filePath, out fileName);
        }
        else
        {
            filePath = null;
            fileName = null;
        }
    }

    public static List<string> SplitByLetterCount(string s, int c)
    {
        int sl = s.Length;
        int e = sl / c;
        int remain = sl % c;
        if (remain != 0)
        {
            ThrowEx.Custom(sess.i18n(XlfKeys.NumbersOfLetters) + " " + s + " is not dividable with " + c);
        }

        List<string> ls = new List<string>(c);
        int from = 0;

        while (s.Length > from + c - 2)
        {

            ls.Add(s.Substring(from, c));

            from += c;
            if (from == sl)
            {
                break;
            }


        }
        return ls;
    }

    public static void SplitToParts2(string df, string deli, ref string before, ref string after)
    {
        var p = SHSplit.Split(df, deli);
        before = p[0];
        after = p[1];
    }

    public static void RemoveWhichHaveWhitespaceAtBothSides(string s, List<int> bold)
    {
        for (int i = bold.Count - 1; i >= 0; i--)
        {
            if (char.IsWhiteSpace(s[bold[i] - 1]) && char.IsWhiteSpace(s[bold[i] + 1]))
            {
                bold.RemoveAt(i);
            }
        }

    }





    /// <summary>
    /// Do výsledku zahranu i mezery a punktační znaménka
    /// </summary>
    /// <param name="veta"></param>
    public static List<string> SplitBySpaceAndPunctuationCharsLeave(string veta)
    {
        List<string> vr = new List<string>();
        vr.Add("");
        foreach (var item in veta)
        {
            bool jeMezeraOrPunkce = false;
            foreach (var item2 in spaceAndPuntactionChars)
            {
                if (item == item2)
                {
                    jeMezeraOrPunkce = true;
                    break;
                }
            }

            if (jeMezeraOrPunkce)
            {
                if (vr[vr.Count - 1] == "")
                {
                    vr[vr.Count - 1] += item.ToString();
                }
                else
                {
                    vr.Add(item.ToString());
                }

                vr.Add("");
            }
            else
            {
                vr[vr.Count - 1] += item.ToString();
            }
        }
        return vr;
    }

    public static List<int> SplitToIntListNone(string stringToSplit, params string[] delimiter)
    {
        List<int> nt = null;
        stringToSplit = stringToSplit.Trim();
        if (stringToSplit != "")
        {
            var f = SHSplit.SplitNone(stringToSplit, delimiter);
            nt = new List<int>(f.Count);
            foreach (string item in f)
            {
                nt.Add(int.Parse(item));
            }
        }
        else
        {
            nt = new List<int>();
        }
        return nt;
    }



    public static List<string> SplitBySpaceAndPunctuationChars(string s)
    {
        return SHSplit.SplitChar(s, spaceAndPuntactionChars);
    }



    public static List<string> SplitNoneCharList(string text, List<string> deli)
    {
        return Split(StringSplitOptions.None, text, deli.ToArray());
    }

    public static List<string> SplitNoneChar(string text, params char[] deli)
    {
        return SplitChar(StringSplitOptions.None, text, deli);
    }



    public static List<string> SplitByWhiteSpaces(string s, bool removeEmpty = false)
    {
        List<string> r = null;
        if (removeEmpty)
        {
            r = SplitCharMore(s, AllCharsSE.whiteSpacesChars.ToArray()).ToList();
        }
        else
        {
            r = SplitNone(s, SunamoValues.AllStrings.whiteSpacesChars.ToArray()).ToList();
        }

        return r;
    }

    /// <summary>
    /// Pokud něco nebude číslo, program vyvolá výjimku, protože parsuje metodou int.Parse
    /// </summary>
    /// <param name="stringToSplit"></param>
    /// <param name="delimiter"></param>
    public static List<int> SplitToIntList(string stringToSplit, params string[] delimiter)
    {
        var f = SHSplit.Split(stringToSplit, delimiter);
        List<int> nt = new List<int>(f.Count);
        foreach (string item in f)
        {
            nt.Add(int.Parse(item));
        }
        return nt;
    }

    /// <summary>
    /// Get null if count of getted parts was under A2.
    /// Automatically add empty padding items at end if got lower than A2
    /// Automatically join overloaded items to last by A2.
    ///
    /// </summary>
    /// <param name="p"></param>
    /// <param name="p_2"></param>
    public static List<string> SplitToParts(string what, int parts, string deli)
    {
        var s = SHSplit.Split(what, deli);
        if (s.Count < parts)
        {
            // Pokud je pocet ziskanych partu mensi, vlozim do zbytku prazdne retezce
            if (s.Count > 0)
            {
                List<string> vr2 = new List<string>();
                for (int i = 0; i < parts; i++)
                {
                    if (i < s.Count)
                    {
                        vr2.Add(s[i]);
                    }
                    else
                    {
                        vr2.Add("");
                    }
                }
                return vr2;
                //return new string[] { s[0] };
            }
            else
            {
                return null;
            }
        }
        else if (s.Count == parts)
        {
            // Pokud pocet ziskanych partu souhlasim presne, vratim jak je
            return s;
        }

        // Pokud je pocet ziskanych partu vetsi nez kolik ma byt, pripojim ty co josu navic do zbytku
        parts--;
        List<string> vr = new List<string>();
        for (int i = 0; i < s.Count; i++)
        {
            if (i < parts)
            {
                vr.Add(s[i]);
            }
            else if (i == parts)
            {
                vr.Add(s[i] + deli);
            }
            else if (i != s.Count - 1)
            {
                vr[parts] += s[i] + deli;
            }
            else
            {
                vr[parts] += s[i];
            }
        }
        return vr;
    }

    public static Tuple<string, string> SplitFromReplaceManyFormat(string input)
    {
        StringBuilder to = new StringBuilder();
        StringBuilder from = new StringBuilder();

        if (input.Contains(Consts.transformTo))
        {

            var lines = SHSE.GetLines(input);

            lines = lines.ConvertAll(d => d.Trim());

            foreach (var item in lines)
            {
                var p = SHSplit.Split(item, Consts.transformTo);
                from.AppendLine(p[0]);
                to.AppendLine(p[1]);
            }
        }
        else
        {
            from.AppendLine(input);
        }


        return new Tuple<string, string>(from.ToString(), to.ToString());

    }

    public static Tuple<List<string>, List<string>> SplitFromReplaceManyFormatList(string input)
    {
        var t = SplitFromReplaceManyFormat(input);
        return new Tuple<List<string>, List<string>>(SHSE.GetLines(t.Item1), SHSE.GetLines(t.Item2));
    }

    /// <summary>
    /// FUNGUJE ale může být pomalá, snaž se využívat co nejméně
    /// Pokud někde bude více delimiterů těsně za sebou, ve výsledku toto nebude, bude tam jen poslední delimiter v té řadě příklad z 1,.Par při delimiteru , a . bude 1.Par
    /// </summary>
    /// <param name="what"></param>
    /// <param name="parts"></param>
    /// <param name="deli"></param>
    public static List<string> SplitToPartsFromEnd(string what, int parts, params char[] deli)
    {
        List<char> chs = null;
        List<bool> bw = null;
        List<int> delimitersIndexes = null;
        SHSplit.SplitCustom(what, out chs, out bw, out delimitersIndexes, deli);

        List<string> vr = new List<string>(parts);
        StringBuilder sb = new StringBuilder();
        for (int i = chs.Count - 1; i >= 0; i--)
        {
            if (!bw[i])
            {
                while (i != 0 && !bw[i - 1])
                {
                    i--;
                }
                string d = sb.ToString();
                sb.Clear();
                if (d != "")
                {
                    vr.Add(d);
                }
            }
            else
            {
                sb.Insert(0, chs[i]);
                //sb.Append(chs[i]);
            }
        }
        string d2 = sb.ToString();
        sb.Clear();
        if (d2 != "")
        {
            vr.Add(d2);
        }
        List<string> v = new List<string>(parts);
        for (int i = 0; i < vr.Count; i++)
        {
            if (v.Count != parts)
            {
                v.Insert(0, vr[i]);
            }
            else
            {
                string ds = what[delimitersIndexes[i - 1]].ToString();
                v[0] = vr[i] + ds + v[0];
            }
        }
        return v;
    }

    /// <summary>
    /// V A2 vrátí jednotlivé znaky z A1, v A3 bude false, pokud znak v A2 bude delimiter, jinak True
    /// </summary>
    /// <param name="what"></param>
    /// <param name="chs"></param>
    /// <param name="bs"></param>
    /// <param name="reverse"></param>
    /// <param name="deli"></param>
    public static void SplitCustom(string what, out List<char> chs, out List<bool> bs, out List<int> delimitersIndexes, params char[] deli)
    {
        chs = new List<char>(what.Length);
        bs = new List<bool>(what.Length);
        delimitersIndexes = new List<int>(what.Length / 6);
        for (int i = 0; i < what.Length; i++)
        {
            bool isNotDeli = true;
            var ch = what[i];
            foreach (var item in deli)
            {
                if (item == ch)
                {
                    delimitersIndexes.Add(i);
                    isNotDeli = false;
                    break;
                }
            }
            chs.Add(ch);
            bs.Add(isNotDeli);
        }
        delimitersIndexes.Reverse();
    }

    public static List<string> SplitAndReturnRegexMatches(string input, Regex r, params char[] del)
    {
        List<string> vr = new List<string>();
        var ds = SHSplit.SplitChar(input, del);
        foreach (var item in ds)
        {
            if (r.IsMatch(item))
            {
                vr.Add(item);
            }
        }
        return vr;
    }

    /// <summary>
    /// TODO: Zatím NEfunguje 100%ně, až někdy budeš mít chuť tak se můžeš pokusit tuto metodu opravit. Zatím ji nepoužívej, místo ní používej pomalejší ale funkční SplitToPartsFromEnd
    /// Vrátí null v případě že řetězec bude prázdný
    /// Pokud bude mít A1 méně částí než A2, vratí nenalezené části jako SE
    /// </summary>
    /// <param name="what"></param>
    /// <param name="parts"></param>
    /// <param name="deli"></param>
    public static List<string> SplitToPartsFromEnd2(string what, int parts, params char[] deli)
    {
        List<int> indexyDelimiteru = new List<int>();
        foreach (var item in deli)
        {
            indexyDelimiteru.AddRange(SH.ReturnOccurencesOfString(what, item.ToString()));
        }
        //indexyDelimiteru.OrderBy(d => d);
        indexyDelimiteru.Sort();
        var s = SHSplit.SplitChar(what, deli);
        if (s.Count < parts)
        {
            //ThrowEx.Custom("");
            if (s.Count > 0)
            {
                List<string> vr2 = new List<string>();
                for (int i = 0; i < parts; i++)
                {
                    if (i < s.Count)
                    {
                        vr2.Add(s[i]);
                    }
                    else
                    {
                        vr2.Add("");
                    }
                }
                return vr2;
                //return new List<string> { s[0] };
            }
            else
            {
                return null;
            }
        }
        else if (s.Count == parts)
        {
            return s;
        }
        int parts2 = s.Count - parts - 1;
        //parts += povysit;
        if (parts < s.Count - 1)
        {
            parts++;
        }
        List<string> vr = new List<string>(parts);
        // Tady musí být 4 menší než 1, protože po 1. iteraci to bude 3,pak 2, pak 1
        for (; parts > parts2; parts--)
        {
            vr.Insert(0, s[parts]);
        }
        parts++;
        for (int i = 1; i < parts; i++)
        {
            vr[0] = s[i] + what[indexyDelimiteru[i]].ToString() + vr[0];
            //}
        }
        vr[0] = s[0] + what[indexyDelimiteru[0]].ToString() + vr[0];
        return vr;
    }



    private static bool IsEndOfSentence(int dxDot, string s1, out string delimitingChars)
    {
        delimitingChars = null;
        var s = SH.SubstringIfAvailableStart(s1, dxDot);
        var c0 = s[0];
        char c1, c2;
        c1 = '@';
        c2 = '@';
        if (s.Length > 1)
        {
            c1 = s[1];
        }
        else
        {
            delimitingChars = SH.SubstringIfAvailableStart(s, 0);
            Result = true;
        }
        if (s.Length > 2)
        {
            c2 = s[2];
        }
        else
        {
            delimitingChars = s.Substring(1);
            Result = true;
        }
        if (c1 == AllCharsSE.space && char.IsUpper(c2))
        {
            delimitingChars = string.Join(string.Empty, c0, c1, c2);
            Result = true;
        }
        if (char.IsUpper(c1))
        {
            delimitingChars = string.Join(string.Empty, c0, c1);
            Result = true;
        }
        return Result;
    }

    public static string SplitParagraphToMaxChars(string text, int maxChars)
    {
        var parts = SHSplit.Split(text, Environment.NewLine);
        List<List<string>> d = new List<List<string>>();
        foreach (var item in parts)
        {
            ThrowEx.NotImplementedMethod();
            //d.Add(CA.ToListString(item));
        }
        var index = -1;
        foreach (var item in d)
        {
            bool d1 = false;
            index++;
            List<string> copy = item.ToList();
            var s1 = item[0];
            var f = s1.Length;
            if (f > maxChars)
            {
                var dxDots = SH.ReturnOccurencesOfString(s1, AllStringsSE.dot);
                int i = 0;
                int dx = 0;
                int alreadyProcessed = 0;
                int alreadyTrimmed = 0;
                foreach (var dxDot2 in dxDots)
                {
                    i++;
                    var dxDot = dxDot2 - alreadyTrimmed;
                    int s1C = s1.Length;
                    if (s1C > maxChars)
                    {
                        if (i > 1)
                        {
                            if (dxDot > maxChars)
                            {
                                string delimitingChars = null;
                                if (IsEndOfSentence(dxDot, s1, out delimitingChars))
                                {
                                    string before, after;
                                    // Zde jsem dal -1 místo -2, vracelo mi to na začátku rok
                                    // Může mi to občas přetáhnout limit 250 znaků ale furt je to lepší než mít na začátku rok
                                    var ddx = dxDots[i - 1] + 1;
                                    ddx -= alreadyTrimmed;
                                    (before, after) = SH.GetPartsByLocationNoOutInt(s1, ddx);
                                    after = after.Trim();
                                    if (after == string.Empty)
                                    {
                                        after = "   ";
                                    }
                                    if (char.IsLower(after[0]))
                                    {
                                        continue;
                                    }
                                    //dx++;
                                    alreadyProcessed++;
                                    ////DebugLogger.Instance.WriteLine("dx", dx);
                                    ////DebugLogger.Instance.WriteLine("alreadyProcessed", alreadyProcessed);
                                    ////DebugLogger.Instance.WriteLine("dx-alreadyProcessed", dx - alreadyProcessed);
                                    if (dx > 1)
                                    {
                                        dx--;
                                    }
                                    //dx -= alreadyProcessed;
                                    if (d1)
                                    {
                                        ////DebugLogger.Instance.WriteLine("i", i);
                                    }
                                    s1 = s1.Substring(ddx);
                                    //after = delimitingChars + after;
                                    int beforeC, afterC;
                                    beforeC = before.Length;
                                    afterC = after.Length;
                                    s1C = s1.Length;
                                    alreadyTrimmed += beforeC;
                                    if (d1)
                                    {
                                        ////DebugLogger.Instance.WriteLine("beforeC", beforeC);
                                        ////DebugLogger.Instance.WriteLine("afterC", afterC);
                                        ////DebugLogger.Instance.WriteLine("s1C", s1C);
                                    }
                                    var ls = d[index];
                                    if (d1)
                                    {
                                        var bC = SH.OccurencesOfStringIn(before, sess.i18n(XlfKeys.ThisParagraphIsLongerThan500Characters) + ".");
                                        var aC = SH.OccurencesOfStringIn(after, sess.i18n(XlfKeys.ThisParagraphIsLongerThan500Characters) + ".");
                                        ////DebugLogger.Instance.WriteLine("bC", bC);
                                        ////DebugLogger.Instance.WriteLine("aC", aC);
                                    }
                                    if (dx < 0)
                                    {
                                        StringBuilder sb2 = new StringBuilder();
                                        foreach (var item3 in ls)
                                        {
                                            sb2.AppendLine(item3);
                                        }
                                        var txt = sb2.ToString();
                                    }
                                    ls.AddOrSet(dx, before);
                                    dx++;
                                    ls.AddOrSet(dx, after);
                                    dx++;
                                    if (d1)
                                    {
                                        ////DebugLogger.Instance.WriteLine("dx1", dx - 1);
                                        ////DebugLogger.Instance.WriteLine("dx2", dx);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        var ls = d[index];
                        s1 = s1.Replace(ls.Last(), string.Empty).Trim();
                        if (s1 != string.Empty)
                        {
                            ls.AddOrSet(dx, s1);
                        }
                        break;
                    }
                }
            }
        }
        StringBuilder sb = new StringBuilder();
        foreach (var item in d)
        {
            foreach (var line in item)
            {
                sb.AppendLine(line);
                sb.AppendLine();
            }
        }
        return sb.ToString();
    }



    /// <summary>
    /// Před voláním této metody se musíš ujistit že A2 není úplně na konci
    /// </summary>
    /// <param name="p"></param>
    /// <param name="firstNormal"></param>
    /// <param name="title"></param>
    /// <param name="remix"></param>
    public static void SplitByIndex(string p, int firstNormal, out string title, out string remix)
    {
        title = p.Substring(0, firstNormal);
        remix = p.Substring(firstNormal + 1);
    }

    public static List<string> SplitByNewLines(string pull)
    {
        return SHSplit.Split(pull, AllStrings.nl, AllStrings.cr);
    }

    /// <summary>
    /// Use postfixSpaceCommaNewline in askingUserDialogs
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static List<string> SplitSpaceCommaNewline(string d)
    {
        return SHSplit.Split(d, spaceCommaNewline.ToArray());

    }

    /// <param name="what"></param>
    /// <param name="parts"></param>
    /// <param name="deli"></param>
    /// <param name="addEmptyPaddingItems"></param>
    /// <param name="joinOverloadedPartsToLast"></param>
    public static List<string> SplitToParts(string what, int parts, string deli, bool addEmptyPaddingItems /*, bool joinOverloadedPartsToLast - not used */)
    {
        var s = SHSplit.Split(what, deli);
        if (s.Count < parts)
        {
            // Pokud je pocet ziskanych partu mensi, vlozim do zbytku prazdne retezce
            if (s.Count == 0)
            {
                List<string> vr2 = new List<string>();
                for (int i = 0; i < parts; i++)
                {
                    if (i < s.Count)
                    {
                        vr2.Add(s[i]);
                    }
                    else
                    {
                        vr2.Add("");
                    }
                }
                return vr2;
                //return new List<string> { s[0] };
            }
            else
            {
                return null;
            }
        }
        else if (s.Count == parts)
        {
            // Pokud pocet ziskanych partu souhlasim presne, vratim jak je
            return s;
        }
        // Pokud je pocet ziskanych partu vetsi nez kolik ma byt, pripojim ty co josu navic do zbytku
        parts--;
        List<string> vr = new List<string>();
        for (int i = 0; i < s.Count; i++)
        {
            if (i < parts)
            {
                vr.Add(s[i]);
            }
            else if (i == parts)
            {
                vr.Add(s[i] + deli);
            }
            else if (i != s.Count - 1)
            {
                vr[parts] += s[i] + deli;
            }
            else
            {
                vr[parts] += s[i];
            }
        }
        return vr;
    }


}
