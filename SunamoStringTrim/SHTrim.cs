namespace SunamoStringTrim;

// : SHData mi způsobilo chyby Reference to type '' claims it is defined in '', but it could not be found. důvod byl jednoduchý, původně jsem chtěl dědit z SHSE který bude dědit z SHData. Pak jsem to ale obrátil. Neměl jsem zkompilované nové SunamoStringData ve kterém nebylo SunExc a VS sice ví kde hledaná třída je ale neřekne přímo ten problém. Proto to vše bylo takové matoucí. 
public class SHTrim : SHData
{
    public static string TrimStartingAndTrailingChars(string html, out StringBuilder fromStart, out StringBuilder fromEnd)
    {
        fromStart = new StringBuilder();
        fromEnd = new StringBuilder();
        char specialChar = 'a';

        for (int i = 0; i < html.Length; i++)
        {
            if (CharHelper.IsSpecialChar(i, ref html, ref specialChar, true))
            {
                fromStart.Append(specialChar);
            }
            else
            {
                break;
            }
        }

        for (int i = html.Length - 1; i >= 0; i--)
        {
            if (CharHelper.IsSpecialChar(i, ref html, ref specialChar, true))
            {
                fromEnd.Insert(0, specialChar);
            }
            else
            {
                break;
            }
        }

        return html;
    }

    /// <summary>
    /// Vrátí SE když A1 bude null, pokud null nebude, trimuje ho
    /// </summary>
    /// <param name="p"></param>
    public static string TrimIsNotNull(string p)
    {
        if (p != null)
        {
            return p.Trim();
        }
        return "";
    }

    public static string TrimNewLineAndTab(string lyricsFirstOriginal, bool replaceDoubleSpaceForSingle = false)
    {
        var result = lyricsFirstOriginal.Replace("\t", AllStrings.space).Replace("\r", AllStrings.space).Replace("\n", AllStrings.space).Replace(AllStringsSE.doubleSpace, AllStrings.space);
        if (replaceDoubleSpaceForSingle)
        {
            result = SHReplace.ReplaceAllDoubleSpaceToSingle(result, true);
        }
        return result;
    }

    public static string TrimStartAndEnd(string target, Func<char, bool> startAllowed, Func<char, bool> endAllowed)
    {
        for (int i = 0; i < target.Length; i++)
        {
            if (!startAllowed.Invoke(target[i]))
            {
                target = target.Substring(1);
                i--;
            }
            else
            {
                break;
            }
        }

        for (int i = target.Length - 1; i >= 0; i--)
        {
            if (!startAllowed.Invoke(target[i]))
            {
                target = target.Remove(target.Length - 1, 1);

            }
            else
            {
                break;
            }
        }
        return target;
    }

    public static string TrimEndSpaces(string v)
    {
        return v.TrimEnd(AllChars.space);
    }

    public static string TrimBrackets(string ratingCount)
    {
        return ratingCount.TrimStart(AllChars.lb).TrimEnd(AllChars.rb);
    }

    /// <summary>
    ///     Usage: Exc.TypeAndMethodName
    /// </summary>
    /// <param name="v"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string TrimStart(string v, string s)
    {
        while (v.StartsWith(s))
        {
            v = v.Substring(s.Length);
        }

        return v;
    }

    public static string TrimEnd(string name)
    {
        return name.TrimEnd(AllCharsSE.whiteSpacesChars.ToArray());
    }

    public static bool TrimIfStartsWith(ref string s, string p)
    {
        if (s.StartsWith(p))
        {
            s = s.Substring(p.Length);
            return true;
        }
        return false;
    }

    public static string TrimStartAndEnd(string v, string s, string e)
    {
        v = TrimEnd(v, e);
        v = TrimStart(v, s);

        return v;
    }

    /// <summary>
    /// Trim from beginning and end of A1 substring A2
    /// </summary>
    /// <param name="s"></param>
    /// <param name="args"></param>
    public static string Trim(string s, string args)
    {
        s = TrimStart(s, args);
        s = TrimEnd(s, args);

        return s;
    }

    public static string AdvancedTrim(string p)
    {
        return p.Replace(AllStringsSE.doubleSpace, AllStringsSE.space).Trim();
    }

    public static string TrimLeadingNumbersAtStart(string nameSolution)
    {
        for (int i = 0; i < nameSolution.Length; i++)
        {
            bool replace = false;
            for (int n = 0; n < 10; n++)
            {
                if (nameSolution[i] == n.ToString()[0])
                {
                    replace = true;
                    nameSolution = nameSolution.Substring(1);
                    break;
                }
            }
            if (!replace)
            {
                return nameSolution;
            }
        }
        return nameSolution;
    }

    public static string TrimTrailingNumbersAtEnd(string nameSolution)
    {
        for (int i = nameSolution.Length - 1; i >= 0; i--)
        {
            bool replace = false;
            for (int n = 0; n < 10; n++)
            {
                if (nameSolution[i] == n.ToString()[0])
                {
                    replace = true;
                    nameSolution = nameSolution.Substring(0, nameSolution.Length - 1);
                    break;
                }
            }
            if (!replace)
            {
                return nameSolution;
            }
        }
        return nameSolution;
    }



    public static string TrimNumbersAtEnd(string nameSolution)
    {
        for (int i = nameSolution.Length - 1; i >= 0; i--)
        {
            bool replace = false;
            for (int n = 0; n < 10; n++)
            {
                if (nameSolution[i] == n.ToString()[0])
                {
                    replace = true;
                    nameSolution = nameSolution.Length > 0 ? nameSolution.Substring(0, nameSolution.Length - 1) : string.Empty;
                    break;
                }
            }

            if (!replace)
            {
                return nameSolution;
            }
        }
        return nameSolution;
    }
}
