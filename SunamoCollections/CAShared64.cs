using SunamoCollectionsChangeContent.Args;

namespace SunamoCollections;
public partial class CA
{







    /// <summary>
    /// Direct edit
    /// </summary>
    /// <param name="slova"></param>
    public static List<string> ToLower(List<string> slova)
    {
        for (int i = 0; i < slova.Count; i++)
        {
            slova[i] = slova[i].ToLower();
        }
        return slova;
    }





    /// <summary>
    /// Direct edit
    /// </summary>
    /// <param name="files_in"></param>
    /// <param name="what"></param>
    /// <param name="forWhat"></param>
    public static void Replace(List<string> files_in, string what, string forWhat)
    {
        CAChangeContent.ChangeContent2(null, files_in, SHReplace.Replace, what, forWhat);
    }






    #region 4) ContainsElement
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
    /// <param name="list"></param>
    /// <param name="t"></param>
    public static bool ContainsElement<T>(IList<T> list, T t)
    {
        if (list.Count() == 0)
        {
            return false;
        }
        foreach (T item in list)
        {
            if (Comparer<T>.Equals(item, t))
            {
                return true;
            }
        }

        return false;
    }
    #endregion












    /// <summary>
    /// not direct edit
    /// </summary>
    /// <param name="v"></param>
    /// <param name="dirs"></param>
    public static List<string> PostfixIfNotEnding(string v, List<string> dirs)
    {
        return CAChangeContent.ChangeContent(new ChangeContentArgs2() { }, dirs, SH.PostfixIfNotEmpty, v);
    }

















    /// <summary>
    /// Direct editr
    /// </summary>
    /// <param name="files1"></param>
    /// <param name="item"></param>
    /// <param name="wildcard"></param>
    public static void RemoveWhichContains(List<string> files1, string item, bool wildcard)
    {
        if (wildcard)
        {
            //item = SH.WrapWith(item, AllChars.asterisk);
            for (int i = files1.Count - 1; i >= 0; i--)
            {
                if (Wildcard.IsMatch(files1[i], item))
                {
                    files1.RemoveAt(i);
                }
            }
        }
        else
        {
            for (int i = files1.Count - 1; i >= 0; i--)
            {
                if (files1[i].Contains(item))
                {
                    files1.RemoveAt(i);
                }
            }
        }
    }







    /// <summary>
    /// element can be null, then will be added as default(T)
    /// If item is null, add instead it default(T)
    /// cant join from IList elements because there must be T2 for element's type of collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    public static List<T> ToList<T>(IList enumerable)
    {
        // system array etc cant be casted
        //var ien = enumerable as IList<object>;
        var ien = enumerable as List<object>;
        var ienf = ien.FirstOrNull() as IList;
        List<T> result = null;
        //if (enumerable is IList<char>)
        //{
        //    result = new List<T>(1);
        //    result.Add(SHJoin.JoinIList(string.Empty, enumerable));
        //}

        bool b1 = ien != null;
        bool b2 = typeof(T) == Types.tString;
        bool b3 = ienf.Count > 1;
        bool b4 = false;
        bool b5 = false;

        if (ienf != null)
        {
            var f = ienf.FirstOrNull();
            if (f != null)
            {
                b4 = f.GetType() == Types.tChar;
            }
        }
        if (ien != null)
        {
            var l = ien.Last();
            if (l != null)
            {
                b5 = l.GetType() == Types.tChar;
            }
        }

        if (enumerable.Count == 1 && enumerable.FirstOrNull() is IList<object>)
        {
            result = ToListT2<T>((IList)enumerable.FirstOrNull());
        }
        else if (b1 && b2 && b3 && b4 && b5)
        {
            result.Add((T)(dynamic)string.Join(string.Empty, enumerable));
        }
        else if (enumerable.Count() == 1 && enumerable.FirstOrNull() is IList)
        {
            result = ToListT2<T>(((IList)enumerable.FirstOrNull()));
        }
        else
        {
            return ToListT2<T>(enumerable);
        }
        return result;
    }

    /// <summary>
    /// element can be null, then will be added as default(T)
    /// Must be private - to use only public in CA
    /// bcoz Cast() not working
    /// Dont make any type checking - could be done before
    /// </summary>
    private static List<T> ToListT2<T>(IList enumerable) //where T : IList<char>
    {
        if (typeof(T) == Types.tString)
        {
            List<T> t = new List<T>();


            foreach (var item in enumerable)
            {
                if (item is IList)
                {
                    var ie = (IList)item;
                    StringBuilder sb = new StringBuilder();
                    foreach (var item2 in ie)
                    {
                        sb.Append(item2.ToString());
                    }
                    object t2 = sb.ToString();
                    t.Add((T)t2);
                }
                else if (item is char)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item2 in enumerable)
                    {
                        sb.Append(item2.ToString());
                    }
                    object t2 = sb.ToString();
                    t.Add((T)t2);
                    break;
                }
                else
                {
                    t.Add((T)(IEnumerable<char>)item.ToString());
                }
            }
            return t;

        }

        List<T> result = new List<T>(enumerable.Count());
        foreach (var item in enumerable)
        {
            if (item == null)
            {
                result.Add(default(T));
            }
            else
            {
                // cant join from IList elements because there must be T2 for element's type of collection. Use CA.TwoDimensionParamsIntoOne instead

                //var t1 = item.GetType();
                //var t2 = typeof(IList);
                //if (RH.IsOrIsDeriveFromBaseClass(t1 , t2, false) && t1 != Types.tString)
                //{
                //    //result.AddRange(item as IList);
                //    var item3 = (IList)item;

                //    foreach (var item2 in item3)
                //    {
                //        result.Add(item2);
                //    }
                //}
                //else
                //{
                //try
                //{
                result.Add((T)item);
                //}
                //catch (Exception ex)
                //{
                //    // Insert Here ThrowEx
                //}
                //}
            }
        }
        return result;
    }

    ///// <summary>
    ///// Convert IList to List<string> Nothing more, nothing less
    ///// Must be private - to use only public in CA
    ///// bcoz Cast() not working
    ///// Dont make any type checking - could be done before
    ///// </summary>
    //private static List<string> ToListString2(IList enumerable)
    //{
    //    return se.CA.ToListString2(enumerable);
    //}

    ///// <summary>
    ///// Just 3 cases of working:
    ///// IList<char> => string
    ///// IList<string> => List<string>
    ///// IList => List<string>
    ///// </summary>
    ///// <param name="enumerable"></param>
    //public static List<string> ToListString(IList enumerable2)
    //{
    //    return se.CA.ToListString(enumerable2);
    //}

    public static IList<object> OneElementCollectionToMulti(IList deli2)
    {
        if (deli2.Count() == 1)
        {
            var first = deli2.FirstOrNull();
            var ien = first as IList<object>;

            if (ien != null)
            {
                return ien;
            }
            return CA.ToListMoreObject(first);
        }
        return deli2 as IList<object>;
    }


    /// <summary>
    /// Direct edit collection
    /// Na rozdíl od metody RemoveStringsEmpty2 NEtrimuje před porovnáním
    /// </summary>
    /// <param name="mySites"></param>
    public static List<string> RemoveStringsEmpty(List<string> mySites)
    {
        for (int i = mySites.Count - 1; i >= 0; i--)
        {
            if (mySites[i] == string.Empty)
            {
                mySites.RemoveAt(i);
            }
        }
        return mySites;
    }

    public static List<string> RemoveStringsEmpty2(List<string> mySites)
    {
        for (int i = mySites.Count - 1; i >= 0; i--)
        {
            if (mySites[i].Trim() == string.Empty)
            {
                mySites.RemoveAt(i);
            }
        }
        return mySites;
    }

    /// <summary>
    /// For all types
    /// </summary>
    /// <param name="times"></param>
    public static List<int> IndexesWithNull(IList times)
    {
        List<int> nulled = new List<int>();
        int i = 0;
        foreach (var item in times)
        {
            if (item == null)
            {
                nulled.Add(i);
            }
            i++;
        }

        return nulled;
    }

}
