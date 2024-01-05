namespace SunamoCollections;

public partial class CA : CASE
{
    public static List<int> ParseInt(string v, string comma)
    {
        var s = SHSE.Split(v, comma);
        return BTS.CastCollectionStringToInt(s);
    }

    public static List<List<string>> Split(List<string> s, string determining)
    {
        List<List<string>> ls = new List<List<string>>();
        List<string> actual = new List<string>();
        foreach (var item in s)
        {
            if (item == determining)
            {
                ls.Add(actual);
                actual.Clear();
            }
        }
        return ls;
    }

    public static string GetFirstWordOfList(string t2)

    {
        StringBuilder sb = new StringBuilder();

        var text = SHGetLines.GetLines(t2);
        foreach (var item in text)
        {
            string t = item.Trim();

            if (t.EndsWith(AllStrings.colon))
            {
                sb.AppendLine(item);
            }
            else if (t == "")
            {
                sb.AppendLine(t);
            }
            else
            {
                sb.AppendLine(SH.GetFirstWord(t));
            }
        }

        return sb.ToString();
    }

    public static void RemoveEmptyLinesToFirstNonEmpty(List<string> content)
    {
        for (int i = 0; i < content.Count; i++)
        {
            var line = content[i];
            if (line.Trim() == string.Empty)
            {
                content.RemoveAt(i);
                i--;
            }
            else
            {
                break;
            }
        }
    }

    //public static object FirstOrNull(IList e)
    //{
    //    if (e == null)
    //    {
    //        return null;
    //    }

    //    //var tName = e.GetType().Name;
    //    //if (ThreadHelper.NeedDispatcher(tName))
    //    //{
    //    //    var result = CA.dFirstOrNull(e);
    //    //    return result;
    //    //}

    //    return e.FirstOrNull();
    //}
    public static void KeepOnlyWordsToFirstSpecialChars(List<string> l)
    {
        for (int i = 0; i < l.Count; i++)
        {
            l[i] = SH.RemoveAfterFirstFunc(l[i], CharHelper.IsSpecial, EmptyArrays.Chars);
        }
    }



    public static List<string> LinesIndexes(List<string> cOnlyNamesBy10, int from, int to, bool indexedFrom1)
    {
        if (indexedFrom1)
        {
            from--;
            to--;
        }

        List<string> s = new List<string>();

        for (int i = from; i < to + 1; i++)
        {
            s.Add(cOnlyNamesBy10[i]);
        }

        return s;
    }

    // In order to convert any 2d array to jagged one
    // let's use a generic implementation
    public static List<List<int>> ToJagged(bool[,] value)
    {
        List<List<int>> result = new List<List<int>>();
        for (int i = 0; i < value.GetLength(0); i++)
        {
            List<int> ca = new List<int>();
            for (int y = 0; y < value.GetLength(1); y++)
            {
                ca.Add(SunamoBts.BTS.BoolToInt(value[i, y]));
            }
            result.Add(ca);
        }
        return result;
    }


    /// <summary>
    /// Direct edit
    /// </summary>
    /// <param name="input"></param>
    public static string GetNumberedList(List<string> input, int startFrom)
    {
        CA.RemoveStringsEmpty2(input);
        CA.PrependWithNumbered(input, startFrom);
        return SHSE.JoinNL(input);
    }
    /// <summary>
    /// Direct edit
    /// </summary>
    /// <param name="input"></param>
    private static void PrependWithNumbered(List<string> input, int startFrom)
    {
        var numbered = SunamoBts.BTS.GetNumberedListFromTo(startFrom, input.Count - 1, ") ");
        Prepend(numbered, input);
    }
    public static ABL<string, string> CompareListDifferent(List<string> c1, List<string> c2)
    {
        List<string> existsIn1 = new List<string>();
        List<string> existsIn2 = new List<string>();
        int dex = -1;
        for (int i = c2.Count - 1; i >= 0; i--)
        {
            string item = c2[i];
            dex = c1.IndexOf(item);
            if (dex == -1)
            {
                existsIn2.Add(item);
            }
        }
        for (int i = c1.Count - 1; i >= 0; i--)
        {
            string item = c1[i];
            dex = c2.IndexOf(item);
            if (dex == -1)
            {
                existsIn1.Add(item);
            }
        }
        ABL<string, string> abl = new ABL<string, string>();
        abl.a = existsIn1;
        abl.b = existsIn2;
        return abl;
    }



    /// <summary>
    /// Direct edit
    /// </summary>
    /// <param name="v"></param>
    /// <param name="l"></param>
    /// <returns></returns>
    public static List<string> StartingWith(string v, List<string> l)
    {
        for (int i = l.Count - 1; i >= 0; i--)
        {
            if (!l[i].StartsWith(v))
            {
                l.RemoveAt(i);
            }
        }
        return l;
    }

    /// <summary>
    /// A2,3 can be null, then no header will be append
    /// A4 nameOfSolution - main header, also can be null
    ///
    /// </summary>
    /// <param name="alsoFileNames"></param>
    /// <param name="nameForFirstFolder"></param>
    /// <param name="nameForSecondFolder"></param>
    /// <param name="nameOfSolution"></param>
    /// <param name="files1"></param>
    /// <param name="files2"></param>
    /// <param name="inBoth"></param>
    public static string CompareListResult(bool alsoFileNames, string nameForFirstFolder, string nameForSecondFolder, string nameOfSolution, List<string> files1, List<string> files2, List<string> inBoth)
    {
        int files1Count = files1.Count;
        int files2Count = files2.Count;
        string result;
        TextOutputGenerator textOutput = new TextOutputGenerator();
        int inBothCount = inBoth.Count;
        double sumBothPlusManaged = inBothCount + files2Count;
        PercentCalculator percentCalculator = new PercentCalculator(sumBothPlusManaged);
        if (nameOfSolution != null)
        {
            textOutput.sb.AppendLine(nameOfSolution);
        }
        textOutput.sb.AppendLine("Both (" + inBothCount + AllStrings.swda + percentCalculator.PercentFor(inBothCount, false) + "%):");
        if (alsoFileNames)
        {
            textOutput.List(inBoth);
        }
        if (nameForFirstFolder != null)
        {
            textOutput.sb.AppendLine(nameForFirstFolder + AllStrings.lb + files1Count + AllStrings.swda + percentCalculator.PercentFor(files1Count, true) + "%):");
        }
        if (alsoFileNames)
        {
            textOutput.List(files1);
        }
        if (nameForSecondFolder != null)
        {
            textOutput.sb.AppendLine(nameForSecondFolder + AllStrings.lb + files2Count + AllStrings.swda + percentCalculator.PercentFor(files2Count, true) + "%):");
        }
        if (alsoFileNames)
        {
            textOutput.List(files2);
        }
        textOutput.SingleCharLine(AllChars.asterisk, 10);
        result = textOutput.ToString();
        return result;
    }


    public static List<string> PaddingByEmptyString(List<string> list, int columns)
    {
        for (int i = list.Count - 1; i < columns - 1; i++)
        {
            list.Add(string.Empty);
        }
        return list;
    }
    public static int CountOfEnding(List<string> winrarFiles, string v)
    {
        int count = 0;
        for (int i = 0; i < winrarFiles.Count; i++)
        {
            if (winrarFiles[i].EndsWith(v))
            {
                count++;
            }
        }
        return count;
    }

    public static bool IsInRange(int od, int to, int index)
    {
        return od >= index && to <= index;
    }

    public static List<string> DummyElementsCollection(int count)
    {
        return Enumerable.Repeat<string>(string.Empty, count).ToList();
    }


    /// <summary>
    /// Is useful when want to wrap and also join with string. Also last element will have delimiter
    /// </summary>
    /// <param name="list"></param>
    /// <param name="wrapWith"></param>
    /// <param name="delimiter"></param>
    public static List<string> WrapWithAndJoin(IList<string> list, string wrapWith, string delimiter)
    {
        return list.Select(i => wrapWith + i + wrapWith + delimiter).ToList();
    }
    public static int PartsCount(int count, int inPart)
    {
        int celkove = count / inPart;
        if (count % inPart != 0)
        {
            celkove++;
        }
        return celkove;
    }
    public static List<string> WrapWithIfFunc(Func<string, string, bool, bool> f, bool invert, string mustContains, string wrapWith, params string[] whereIsUsed2)
    {
        for (int i = 0; i < whereIsUsed2.Length; i++)
        {
            if (f.Invoke(whereIsUsed2[i], mustContains, invert))
            {
                whereIsUsed2[i] = wrapWith + whereIsUsed2[i] + wrapWith;
            }
        }
        return whereIsUsed2.ToList();
    }
    /// <summary>
    /// If some of A1 is match with A2
    /// </summary>
    /// <param name="list"></param>
    /// <param name="file"></param>
    public static bool MatchWildcard(string file, List<string> list)
    {
        return list.Any(d => SH.MatchWildcard(file, d));
    }

    public static bool HasFirstItemLength(List<string> notContains)
    {
        string t = "";
        if (notContains.Count > 0)
        {
            t = notContains[0].Trim();
        }
        return t.Length > 0;
    }

    public static List<string> TrimList(List<string> c)
    {
        for (int i = 0; i < c.Count; i++)
        {
            c[i] = c[i].Trim();
        }
        return c;
    }
    public static string GetTextAfterIfContainsPattern(string input, string ifNotFound, List<string> uriPatterns)
    {
        foreach (var item in uriPatterns)
        {
            int nt = input.IndexOf(item);
            if (nt != -1)
            {
                if (input.Length > item.Length + nt)
                {
                    return input.Substring(nt + item.Length);
                }
            }
        }
        return ifNotFound;
    }
    /// <summary>
    /// Direct edit
    /// WithEndSlash - trims backslash and append new
    /// WithoutEndSlash - ony trims backslash
    /// </summary>
    /// <param name="folders"></param>
    public static List<string> WithEndSlash(List<string> folders)
    {
        List<string> list = folders as List<string>;
        if (list == null)
        {
            list = folders.ToList();
        }
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = FS.WithEndSlash(list[i]);
        }
        return folders;
    }
    public static List<string> WithoutEndSlash(List<string> folders)
    {
        for (int i = 0; i < folders.Count; i++)
        {
            folders[i] = FS.WithoutEndSlash(folders[i]);
        }
        return folders;
    }



    public static List<string> JoinArrayAndArrayString(IList<string> a, IList<string> p)
    {
        if (a != null)
        {
            List<string> d = new List<string>(a.Count + p.Count);
            d.AddRange(a);
            d.AddRange(p);
            return d;
        }
        return new List<string>(p);
    }

    public static List<string> JoinArrayAndArrayString(IList<string> a, params string[] p)
    {
        return JoinArrayAndArrayString(a, p.ToList());
    }
    public static void CheckExists(List<bool> photoFiles, List<string> allFilesRelative, List<string> value)
    {
        foreach (var item in allFilesRelative)
        {
            photoFiles.Add(value.Contains(item));
        }
    }
    public static bool HasOtherValueThanNull(List<string> idPhotos)
    {
        foreach (var item in idPhotos)
        {
            if (item != null)
            {
                return true;
            }
        }
        return false;
    }

    public static List<string> GetRowOfTable(List<List<string>> _dataBinding, int i2)
    {
        List<string> vr = new List<string>();
        for (int i = 0; i < _dataBinding.Count; i++)
        {
            vr.Add(_dataBinding[i][i2]);
        }
        return vr;
    }
    /// <summary>
    /// Na rozdíl od metody RemoveStringsEmpty2 NEtrimuje před porovnáním
    /// </summary>
    public static List<string> RemoveStringsByScopeKeepAtLeastOne(List<string> mySites, FromTo fromTo, int keepLines)
    {
        mySites.RemoveRange((int)fromTo.FromL, (int)fromTo.ToL - (int)fromTo.FromL + 1);
        for (long i = fromTo.FromL; i < fromTo.FromL - 1 + keepLines; i++)
        {
            mySites.Insert((int)i, "");
        }
        return mySites;
    }

    /// <summary>
    /// Return first A2 elements of A1 or A1 if A2 is bigger
    /// </summary>
    /// <param name="proj"></param>
    /// <param name="p"></param>
    public static List<string> ShortCircuit(List<string> proj, int p)
    {
        List<string> vratit = new List<string>();
        if (p > proj.Count)
        {
            p = proj.Count;
        }
        for (int i = 0; i < p; i++)
        {
            vratit.Add(proj[i]);
        }
        return vratit;
    }

    public static List<string> ContainsDiacritic(IList<string> nazvyReseni)
    {
        List<string> vr = new List<string>(nazvyReseni.Count());
        foreach (var item in nazvyReseni)
        {
            if (SH.ContainsDiacritic(item))
            {
                vr.Add(item);
            }
        }
        return vr;
    }





    /// <summary>
    /// Change elements count in collection to A2
    /// </summary>
    /// <param name="input"></param>
    /// <param name="requiredLength"></param>
    public static List<string> ToSize(List<string> input, int requiredLength)
    {
        List<string> returnArray = null;
        int realLength = input.Count;
        if (realLength > requiredLength)
        {
            returnArray = new List<string>(requiredLength);
            CASE.InitFillWith(returnArray, requiredLength);
            for (int i = 0; i < requiredLength; i++)
            {
                returnArray[i] = input[i];
            }
            return returnArray;
        }
        else if (realLength == requiredLength)
        {
            return input;
        }
        else if (realLength < requiredLength)
        {
            returnArray = new List<string>(requiredLength);
            CASE.InitFillWith(returnArray, requiredLength);
            int i = 0;
            for (; i < realLength; i++)
            {
                returnArray[i] = input[i];
            }
            for (; i < requiredLength; i++)
            {
                returnArray[i] = null;
            }
        }
        return returnArray;
    }
    public static List<string> Format(string uninstallNpmPackageGlobal, List<string> globallyInstalledTsDefinitions)
    {
        for (int i = 0; i < globallyInstalledTsDefinitions.Count(); i++)
        {
            globallyInstalledTsDefinitions[i] = SH.Format2(uninstallNpmPackageGlobal, globallyInstalledTsDefinitions[i]);
        }
        return globallyInstalledTsDefinitions;
    }


}
