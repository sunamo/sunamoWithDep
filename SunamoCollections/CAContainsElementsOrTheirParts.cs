namespace SunamoCollections;




/// <summary>
/// Keep in separatly file, I have still chaos in it
/// Only 1:M, therefore not CompareListResult
/// 1) CA.ContainsAnyFromElement - Contains string elements of list. Return List<string>
/// 2) CA.IsEqualToAnyElement - same as ContainsElement, only have switched elements. return bool
/// 3) CA.IsEqualToAllElement - takes two generic list. return bool
/// 4) CA.ContainsElement - at least one element must be equaled. generic. bool
/// 5) CA.IsSomethingTheSame - only for string. as List.Contains. bool
/// 6) CA.IsAllTheSame() - takes element and list.generic. bool
/// 7) CA.IndexesWithValue() - element and list.generic. return list<int>
/// 8) CA.ReturnWhichContainsIndexes() - takes two list or element and list. return List<int>
/// 9) ReturnWhichAreEqualIndexes
/// 10) IndexOfValue
/// </summary>
public partial class CA
{
    public static string CompareListSanitizeStringOutput(List<string> l1, List<string> l2, Func<List<string>, Tuple<List<string>, List<string>>> typeScriptHelperGetNamesAndTypes = null, bool tsInterface = false)
    {
        if (tsInterface && typeScriptHelperGetNamesAndTypes != null)
        {
            var t2 = typeScriptHelperGetNamesAndTypes(l1);
            l1 = t2.Item1;

            t2 = typeScriptHelperGetNamesAndTypes(l2);
            l2 = t2.Item1;
        }

        CA.RemoveStringsEmpty2(l1);
        CA.RemoveStringsEmpty2(l2);
        CAChangeContent.ChangeContent0(null, l1, SHReplace.ReplaceWhiteSpacesWithoutSpaces);
        CAChangeContent.ChangeContent0(null, l2, SHReplace.ReplaceWhiteSpacesWithoutSpaces);
        CAChangeContent.ChangeContent0(null, l1, SHReplace.ReplaceAllDoubleSpaceToSingle);
        CAChangeContent.ChangeContent0(null, l2, SHReplace.ReplaceAllDoubleSpaceToSingle);
        var abl = CA.CompareList(l1, l2);
        TextOutputGenerator textOutputGenerator = new TextOutputGenerator();

        textOutputGenerator.List(l1, "Only in 1:");
        textOutputGenerator.AppendLine("");
        textOutputGenerator.List(l2, "Only in 2:");
        textOutputGenerator.AppendLine("");
        textOutputGenerator.List(abl, "Both:");

        var result = textOutputGenerator.ToString();
        return result;
    }


    public static List<T> SortSetFirst<T, U, P>(U result, Func<T, P> getProperty, P prioritize) where U : List<T>
    {
        List<T> t = new List<T>();

        foreach (var item in result)
        {
            var p = getProperty(item);
            if (EqualityComparer<P>.Default.Equals(p, prioritize))
            {
                t.Insert(0, item);
            }
            else
            {
                t.Add(item);
            }
        }

        return t;
    }

    #region CAContainsElementsOrTheitParts
    #region 3) IsEqualToAllElement
    /// <summary>
    /// Return whether all of A1 are in A2
    /// Not all from A2 must be A1ContainsAnyFromElement - Contains string elements of list. Return List<string>
    /// ) CA.ContainsAnyF=´úl¨romElement - Contains string elements of list. Return List<string>
    /// ) CA.IsEqualToAnyElement - same as ContainsElement, only have switched elements. return bool
    /// ) CA.IsEqualToAllElement - takes two generic list. return bool
    /// ) CA.ContainsElement - at least one element must be equaled. generic. bool
    /// ) CA.IsSomethingTheSame - only for string. as List.Contains. bool
    /// ) CA.IsAllTheSame() - takes element and list.generic. bool
    /// ) CA.IndexesWithValue() - element and list.generic. return list<int>
    /// ) CA.ReturnWhichContainsIndexes() - takes two list or element and list. return List<int>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="searchTerms"></param>
    /// <param name="key"></param>
    public static bool IsEqualToAllElement<T>(List<T> searchTerms, List<T> key)
    {
        foreach (var item in searchTerms)
        {
            if (!CA.IsEqualToAnyElement<T>(item, key))
            {
                return false;
            }
        }
        return true;
    }
    #endregion

    #region 5) IsSomethingTheSame
    /// <summary>
    /// 1) CA.ContainsAnyFromElement - Contains string elements of list. Return List<string>
    /// 2) CA.IsEqualToAnyElement - same as ContainsElement, only have switched elements. return bool
    /// 3) CA.IsEqualToAllElement - takes two generic list. return bool
    /// 4) CA.ContainsElement - at least one element must be equaled. generic. bool
    /// 5) CA.IsSomethingTheSame - only for string. as List.Contains. bool
    /// 6) CA.IsAllTheSame() - takes element and list.generic. bool
    /// 7) CA.IndexesWithValue() - element and list.generic. return list<int>
    /// 8) CA.ReturnWhichContainsIndexes() - takes two list or element and list. return List<int>
    /// </summary>
    /// <param name="ext"></param>
    /// <param name="p1"></param>
    public static bool IsSomethingTheSame(string ext, IList<string> p1)
    {
        string contained = null;
        return IsSomethingTheSame(ext, p1, ref contained);
    }

    public static void RemoveNotEndingWith(List<string> solutions, List<string> c)
    {

    }

    /// <summary>
    /// 1) CA.ContainsAnyFromElement - Contains string elements of list. Return List<string>
    /// 2) CA.IsEqualToAnyElement - same as ContainsElement, only have switched elements. return bool
    /// 3) CA.IsEqualToAllElement - takes two generic list. return bool
    /// 4) CA.ContainsElement - at least one element must be equaled. generic. bool
    /// 5) CA.IsSomethingTheSame - only for string. as List.Contains. bool
    /// 6) CA.IsAllTheSame() - takes element and list.generic. bool
    /// 7) CA.IndexesWithValue() - element and list.generic. return list<int>
    /// 8) CA.ReturnWhichContainsIndexes() - takes two list or element and list. return List<int>
    /// </summary>
    /// <param name="ext"></param>
    /// <param name="p1"></param>
    /// <param name="contained"></param>
    public static bool IsSomethingTheSame(string ext, IList<string> p1, ref string contained)
    {
        foreach (var item in p1)
        {
            if (item == ext)
            {
                contained = item;
                return true;
            }
        }
        return false;
    }
    #endregion



    #region 6) IsAllTheSame
    public static bool IsAllTheSame<T>(List<T> ext)
    {
        T first = (T)ext.First();
        // druhá možnost je použít EqualityComparer<T>.Default.Equals(first, d)
        return ext.All(d => Comparer<T>.Default.Compare(first, d) != 0);
    }

    /// <summary>
    /// 1) CA.ContainsAnyFromElement - Contains string elements of list. Return List<string>
    /// 2) CA.IsEqualToAnyElement - same as ContainsElement, only have switched elements. return bool
    /// 3) CA.IsEqualToAllElement - takes two generic list. return bool
    /// 4) CA.ContainsElement - at least one element must be equaled. generic. bool
    /// 5) CA.IsSomethingTheSame - only for string. as List.Contains. bool
    /// 6) CA.IsAllTheSame() - takes element and list.generic. bool
    /// 7) CA.IndexesWithValue() - element and list.generic. return list<int>
    /// 8) CA.ReturnWhichContainsIndexes() - takes two list or element and list. return List<int>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ext"></param>
    /// <param name="p1"></param>
    /// <returns></returns>
    public static bool IsAllTheSame<T>(T ext, params T[] p1)
    {
        for (int i = 0; i < p1.Length; i++)
        {
            if (!EqualityComparer<T>.Default.Equals(p1[i], ext))
            {
                return false;
            }
        }
        return true;
    }
    #endregion

    #region 9) ReturnWhichAreEqualIndexes
    private static IList<int> ReturnWhichAreEqualIndexes<T>(IList<T> parts, T value)
    {
        List<int> result = new List<int>();
        int i = 0;
        foreach (var item in parts)
        {
            if (EqualityComparer<T>.Default.Equals(item, value))
            {
                result.Add(i);
            }
            i++;
        }
        return result;
    }

    private static IList<int> ReturnWhichAreEqualIndexes<T>(IList<T> parts, IList<T> mustBeEqual)
    {
        CollectionWithoutDuplicates<int> result = new CollectionWithoutDuplicates<int>();
        foreach (var item in mustBeEqual)
        {
            result.AddRange(ReturnWhichAreEqualIndexes<T>(parts, item));
        }
        return result.c;
    }

    /// <summary>
    /// Remove from A1 which is already in A2
    /// </summary>
    /// <param name="l"></param>
    /// <param name="ig"></param>
    public static void Remove(List<string> l, List<string> ig)
    {
        int dx = -1;

        foreach (var item in ig)
        {
            dx = l.IndexOf(item);

            if (dx != -1)
            {
                l.RemoveAt(dx);
            }
        }


    }
    #endregion

    #region 10) IndexOfValue
    public static int IndexOfValue(List<int> allWidths, int width)
    {
        for (int i = 0; i < allWidths.Count; i++)
        {
            if (allWidths[i] == width)
            {
                return i;
            }
        }
        return -1;
    }

    public static int IndexOfValue<T>(List<T> allWidths, T width)
    {
        for (int i = 0; i < allWidths.Count; i++)
        {
            if (EqualityComparer<T>.Default.Equals(allWidths[i], width))
            {
                return i;
            }
        }
        return -1;
    }

    public static bool IsThereAnotherIndex(char[] ch, int i)
    {
        if (ch.Length >= i)
        {
            return true;
        }
        return false;
    }

    public static string FirstWhichEndWith(List<string> solutions, string v)
    {
        return solutions.FirstOrDefault(d => d.EndsWith(v));
    }


    public static string CompareListSanitizeStringOutput(List<string> l, List<string> l2)
    {
        // Nemůžu najít její obsah - později zkusit najít ve všech souborech nebo v gitu.
        throw new NotImplementedException();
    }

    public static void FirstCharLower(object l)
    {
        // todo Nemůžu najít její obsah - později zkusit najít ve všech souborech nebo v gitu.
        throw new NotImplementedException();
    }

    public static List<string> AddOrCreateInstance(List<string> excludeFromLocationsCOntains, string v)
    {
        if (!excludeFromLocationsCOntains.Contains(v))
        {
            excludeFromLocationsCOntains.Add(v);
        }

        return excludeFromLocationsCOntains;
    }





    public static List<List<T>> DivideByPercent<T>(IEnumerable<T> source, int chunksize)
    {
        List<List<T>> result = new List<List<T>>();

        while (source.Any())
        {
            result.Add(source.Take(chunksize).ToList());
            source = source.Skip(chunksize);
        }

        return result;
    }

    public static bool PartialContains(List<string> dirs, string pathWithoutName)
    {
        foreach (var item in dirs)
        {
            if (item.Contains(pathWithoutName))
            {
                return true;
            }
        }

        return false;
    }

    public static List<string> JoinByGroup(List<string> p, int v)
    {
        List<string> result = new List<string>();

        StringBuilder sb = new StringBuilder();

        if (p.Count % v != 0)
        {
            ThrowEx.Custom($"Count in {nameof(p)} is not dividable by {v}");
        }

        for (int i = 0; i < p.Count; i++)
        {
            sb.Append(p[i]);

            if ((i + 1) % v == 0)
            {
                result.Add(sb.ToString());

                sb.Clear();
            }
        }

        return result;
    }

    public static List<string> GetIndexes(List<string> l, List<int> dxs)
    {
        List<string> result = new List<string>(dxs.Count);

        foreach (var item in dxs)
        {
            result.Add(l[item]);
        }

        return result;
    }

    public static string LastItem(string version, string deli)
    {
        var p = SHSE.Split(version, deli);
        return p[p.Count - 1];
    }

    /// <summary>
    /// A1 musí být string[], kdyby byl string[] nemůžu vložit List<string>, tj. object ale ne string
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="innerMain"></param>
    /// <returns></returns>
    [ObjectParamsObsolete]
    public static Object[] ConvertListStringWrappedInArray(Object[] innerMain)
    {
        if (CA.IsListStringWrappedInArray(innerMain))
        {
            List<object> result = null;
            var first = (IEnumerable)(object)innerMain[0];

            if (first is List<object>)
            {
                result = (List<object>)first;
            }
            else
            {
                result = new List<object>();

                foreach (var item in first)
                {
                    result.Add(item);
                }
            }


            return result.ToArray();
        }

        return innerMain;
    }





    public static string JoinTextLists(List<string> headers, List<List<string>> outputs)
    {
        ThrowEx.DifferentCountInLists("headers", headers.Count, "outputs", outputs.Count);

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < outputs.Count; i++)
        {
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("#" + i + " " + headers[i]);
            sb.AppendLine();
            sb.AppendLine(SHSE.JoinNL(outputs[i]));
        }

        return sb.ToString();
    }

    public static Dictionary<string, int> OccurenceOfEveryLine(List<string> l)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (var item in l)
        {
            DictionaryHelper.AddOrPlus(result, item, 1);
        }

        return result;
    }

    public static int FirstValueHigherThan(List<int> indexesBefore, int afterTemp)
    {
        return indexesBefore.FirstOrDefault(d => d > afterTemp);
    }
    #endregion
    #endregion



}
