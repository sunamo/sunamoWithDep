namespace SunamoCollectionsGeneric;

public class CAG
{
    public static T[] ToArrayT<T>(params T[] aB)
    {
        return aB;
    }

    /// <summary>
    /// Return equal ranges of in A1
    ///
    ///
    /// </summary>
    /// <param name="contentOneSpace"></param>
    /// <param name="r"></param>
    public static List<FromTo> EqualRanges<T>(List<T> contentOneSpace, List<T> r)
    {
        List<FromTo> result = new List<FromTo>();
        int? dx = null;
        var r_first = r[0];
        int startAt = 0;
        int valueToCompare = 0;
        for (int i = 0; i < contentOneSpace.Count; i++)
        {
            var _contentOneSpace = contentOneSpace[i];
            if (!dx.HasValue)
            {
                if (EqualityComparer<T>.Default.Equals(_contentOneSpace, r_first))
                {
                    dx = i + 1; // +2;
                    startAt = i;
                }
            }
            else
            {
                valueToCompare = dx.Value - startAt;
                if (r.Count > valueToCompare)
                {
                    if (EqualityComparer<T>.Default.Equals(_contentOneSpace, r[valueToCompare]))
                    {
                        dx++;
                    }
                    else
                    {
                        dx = null;
                        i--;
                    }
                }
                else
                {
                    int dx2 = (int)dx;
                    result.Add(new FromTo(dx2 - r.Count + 1, dx2, FromToUse.None));
                    dx = null;
                }
            }
        }
        foreach (var item in result)
        {
            item.from--;
            item.to--;
        }
        return result;
    }

    public static void AddIfNotContains<T>(List<T> founded, T e)
    {
        if (!founded.Contains(e))
        {
            founded.Add(e);
        }
    }

    public static T GetElementActualOrBefore<T>(IList<T> tabItems, int indexClosedTabItem)
    {
        if (tabItems.Count > indexClosedTabItem)
        {
            return tabItems[indexClosedTabItem];
        }
        indexClosedTabItem--;
        if (tabItems.Count > indexClosedTabItem)
        {
            return tabItems[indexClosedTabItem];
        }
        return default(T);
    }
    /// <summary>
    /// V prvním indexu jsou řádky, v druhém sloupce
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="a"></param>
    /// <param name="dex"></param>
    public static List<T> GetColumnOfTwoDimensionalArray<T>(T[,] rows, int dex)
    {
        int rowsCount = rows.GetLength(0);
        int columnsCount = rows.GetLength(1);
        List<T> vr = new List<T>(rowsCount);
        if (dex < columnsCount)
        {
            for (int i = 0; i < rowsCount; i++)
            {
                vr.Add(rows[i, dex]);
            }
            return vr;
        }
        ThrowEx.Custom(sess.i18n(XlfKeys.InvalidRowIndexInMethodCAGetRowOfTwoDimensionalArray) + ";");
        return null;
    }



    /// <summary>
    /// V prvním indexu jsou řádky, v druhém sloupce
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="a"></param>
    /// <param name="dex"></param>
    public static List<T> GetRowOfTwoDimensionalArray<T>(T[,] rows, int dex)
    {
        int rowsCount = rows.GetLength(0);
        int columnsCount = rows.GetLength(1);
        List<T> vr = new List<T>(columnsCount);
        if (dex < rowsCount)
        {
            for (int i = 0; i < columnsCount; i++)
            {
                vr.Add(rows[dex, i]);
            }
            return vr;
        }
        ThrowEx.ArgumentOutOfRangeException(sess.i18n(XlfKeys.InvalidRowIndexInMethodCAGetRowOfTwoDimensionalArray) + ";");
        return null;
    }

    public static bool MoreOrZero<T>(List<T> n, out bool? zeroOrMore)
    {
        zeroOrMore = null;
        var c = n.Count;
        var b = c == 0;
        var bb = c > 1;
        if (b || bb)
        {
            if (b)
            {
                zeroOrMore = true;
            }
            else
            {
                zeroOrMore = false;
            }
            return true;
        }
        return false;
    }

    /// <summary>
    /// Get every duplicated item once
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="clipboardL"></param>
    /// <returns></returns>
    public static List<T> GetDuplicities<T>(List<T> clipboardL)
    {
        List<T> alreadyProcessed;
        return GetDuplicities<T>(clipboardL, out alreadyProcessed);
    }

    public static List<T> CreateListAndInsertElement<T>(T el)
    {
        List<T> t = new List<T>();
        t.Add(el);
        return t;
    }

    /// <summary>
    /// Get every item once
    /// A2 = more duplicities = more items
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="clipboardL"></param>
    /// <param name="alreadyProcessed"></param>
    /// <returns></returns>
    public static List<T> GetDuplicities<T>(List<T> clipboardL, out List<T> alreadyProcessed)
    {
        alreadyProcessed = new List<T>(clipboardL.Count);
        CollectionWithoutDuplicates<T> duplicated = new CollectionWithoutDuplicates<T>();
        foreach (var item in clipboardL)
        {
            if (alreadyProcessed.Contains(item))
            {
                duplicated.Add(item);
            }
            else
            {
                alreadyProcessed.Add(item);
            }
        }
        return duplicated.c;
    }

    /// <summary>
    /// jagged = zubaty
    /// Change from array where every element have two spec of location to ordinary array with inner array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    public static T[][] ToJagged<T>(T[,] value)
    {
        if (Object.ReferenceEquals(null, value))
            return null;
        // Jagged array creation
        T[][] result = new T[value.GetLength(0)][];
        for (int i = 0; i < value.GetLength(0); ++i)
            result[i] = new T[value.GetLength(1)];
        // Jagged array filling
        for (int i = 0; i < value.GetLength(0); ++i)
            for (int j = 0; j < value.GetLength(1); ++j)
                result[i][j] = value[i, j];
        return result;
    }

    public static T[,] OneDimensionArrayToTwoDirection<T>(T[] flatArray, int width)
    {
        int height = (int)Math.Ceiling(flatArray.Length / (double)width);
        T[,] result = new T[height, width];
        int rowIndex, colIndex;
        for (int index = 0; index < flatArray.Length; index++)
        {
            rowIndex = index / width;
            colIndex = index % width;
            result[rowIndex, colIndex] = flatArray[index];
        }
        return result;
    }

    public static int CountOfValue<T>(T v, params T[] show)
    {
        int vr = 0;
        foreach (var item in show)
        {
            if (EqualityComparer<T>.Default.Equals(item, v))
            {
                vr++;
            }
        }
        return vr;
    }

    /// <summary>
    /// Return what exists in both
    /// Modify both A1 and A2 - keep only which is only in one
    /// </summary>
    /// <param name="c1"></param>
    /// <param name="c2"></param>
    public static List<T> CompareList<T>(List<T> c1, List<T> c2) where T : IEquatable<T>
    {
        List<T> existsInBoth = new List<T>();

        int dex = -1;

        for (int i = c2.Count - 1; i >= 0; i--)
        {
            T item = c2[i];
            dex = c1.IndexOf(item);

            if (dex != -1)
            {
                existsInBoth.Add(item);
                c2.RemoveAt(i);
                c1.RemoveAt(dex);
            }
        }

        for (int i = c1.Count - 1; i >= 0; i--)
        {
            T item = c1[i];
            dex = c2.IndexOf(item);

            if (dex != -1)
            {
                existsInBoth.Add(item);
                c1.RemoveAt(i);
                c2.RemoveAt(dex);
            }
        }

        return existsInBoth;
    }

    /// <summary>
    /// Tohle by se sand mohlo jmenovat i ToListObject
    /// protože neberu a nevracím konkrétní typ (např. string) ale T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t"></param>
    /// <returns></returns>
    public static List<T> ToList<T>(params T[] t)
    {
        return t.ToList();
    }

    public static int MinElementsItemsInnerList<T>(List<List<T>> exists)
    {
        int min = int.MaxValue;

        foreach (var item in exists)
        {
            if (item.Count < min)
            {
                min = item.Count;
            }
        }

        return min;
    }

    public static int MaxElementsItemsInnerList<T>(List<List<T>> exists)
    {
        int max = 0;

        foreach (var item in exists)
        {
            if (item.Count > max)
            {
                max = item.Count;
            }
        }

        return max;
    }

    #region RemoveDuplicitiesList
    // <summary>
    /// direct edit
    /// Remove duplicities from A1
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="idKesek"></param>
    public static List<T> RemoveDuplicitiesList<T>(IList<T> idKesek)
    {
        List<T> foundedDuplicities;
        return RemoveDuplicitiesList<T>(idKesek, out foundedDuplicities);
    }

    /// <summary>
    /// direct edit
    /// Remove duplicities from A1
    /// In return value is from every one instance
    /// In A2 is every duplicities (maybe the same more times)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="idKesek"></param>
    /// <param name="foundedDuplicities"></param>
    public static List<T> RemoveDuplicitiesList<T>(IList<T> idKesek, out List<T> foundedDuplicities)
    {
        foundedDuplicities = new List<T>();
        List<T> h = new List<T>();
        for (int i = idKesek.Count - 1; i >= 0; i--)
        {
            var item = idKesek[i];
            if (!h.Contains(item))
            {
                h.Add(item);
            }
            else
            {
                idKesek.RemoveAt(i);
                foundedDuplicities.Add(item);
            }
        }

        return h;
    }
    #endregion

    public static List<List<T>> TrimInnersToCount<T>(List<List<T>> exists, int lowest)
    {
        for (int i = 0; i < exists.Count; i++)
        {
            exists[i] = exists[i].Take(lowest).ToList();
        }

        return exists;
    }

    public static int LowestCount<T>(List<List<T>> exists)
    {
        var min = int.MaxValue;

        foreach (var item in exists)
        {
            if (min > item.Count)
            {
                min = item.Count;
            }
        }

        return min;
    }

    #region 6) IsAllTheSame
    /// <summary>
    /// ContainsAnyFromElement - Contains string elements of list. Return List<string>
    ///IsEqualToAnyElement - same as ContainsElement, only have switched elements. return bool
    ///IsEqualToAllElement - takes two generic list. return bool
    ///ContainsElement - at least one element must be equaled. generic. bool
    ///IsSomethingTheSame - only for string. as List.Contains. bool
    ///IsAllTheSame() - takes element and list.generic. bool
    ///IndexesWithValue() - element and list.generic. return list<int>
    ///ReturnWhichContainsIndexes() - takes two list or element and list. return List<int>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ext"></param>
    /// <param name="p1"></param>
    /// <returns></returns>
    public static bool IsAllTheSame<T>(T ext, IList<T> p1)
    {
        for (int i = 0; i < p1.Count; i++)
        {
            if (!EqualityComparer<T>.Default.Equals(p1[i], ext))
            {
                return false;
            }
        }
        return true;
    }
    #endregion
}
