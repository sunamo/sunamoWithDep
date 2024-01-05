namespace SunamoCollections;

static class IEnumerableExtensions
{
    public static object FirstOrNull(this IEnumerable e)
    {
        foreach (var item in e)
        {
            return item;
        }

        return null;
    }

    public static int Count(this IEnumerable e)
    {
        int i = 0;

        foreach (var item in e)
        {
            i++;
        }

        return i;
    }
}

public partial class CA
{
    #region ToListString

    /// <summary>
    /// Tuto metodu nechat s params
    /// Mám ji na miliónu místech kde přesně plní svůj účel
    /// Už ani nevím co byl původní záměr ale zřejmě to byla nějaká debilní myšlenka "všechno udělat jinak než dosud i když k tomu není důvod"
    /// Vlastně ano, už si pamatuji, byl to záměr zbavit se [] a užívat jen List. 
    /// 
    /// Teď má [ObjectParamsAllowed] a už na ní nikdo nikdy nešáhne. 
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    [ObjectParamsAllowed]
    public static List<string> ToListString(params string[] s)
    {
        return new List<string>(s);
    }

    /// <summary>
    /// ToListString2 - simply for all items call ToString()
    /// ToListString - working with type of every element    
    /// 
    ///     <string>
    ///         Nothing more, nothing less
    ///         Must be private - to use only public in CA
    ///         bcoz Cast() not working
    ///         Dont make any type checking - could be done before
    /// </summary>
    public static List<string> ToListStringIEnumerable2(IEnumerable enumerable)
    {
        List<string> result = new List<string>(enumerable.Count());
        foreach (object item in enumerable)
        {
            if (item == null)
            {
                result.Add(Consts.nulled);
            }
            else
            {
                result.Add(item.ToString());
            }
        }

        return result;
    }




    /// <summary>
    /// ToListString2 - simply for all items call ToString()
    /// ToListString - working with type of every element
    /// 
    ///     Just 3 cases of working:
    ///     IList
    ///     <char>
    ///         => string
    ///         IList
    ///         <string>
    ///             => List
    ///             <string>
    ///                 IList => List<string>
    /// </summary>
    /// <param name="enumerable"></param>
    [ObjectParamsObsoleteAttribute]
    public static List<string> ToListStringIList(IList enumerable2)
    {
        return null;
        //List<string> result = new List<string>();
        //if (enumerable2.GetType() != typeof(string))
        //{
        //    foreach (object item in enumerable2)
        //    {
        //        Type t = item.GetType();
        //        // !(item is string)  - not working
        //        if (RHSE.IsOrIsDeriveFromBaseClass(t, Types.tIEnumerable))
        //        {
        //            // zde to musí být IEnumerable protože spousta věcí z .netu může takhle přijít (např. string)
        //            var enumerable = (System.Collections.IEnumerable)item;
        //            Type type = enumerable.GetType();

        //            bool isEnumerableChar = RHSE.IsOrIsDeriveFromBaseClass(type, typeof(IList<char>));
        //            bool isEnumerableString = RHSE.IsOrIsDeriveFromBaseClass(type, typeof(IList<string>));

        //            if (type == typeof(string))
        //            {


        //                result.Add(string.Join(string.Empty, enumerable));
        //            }
        //            else if (isEnumerableChar)
        //            {
        //                // IList<char> => string
        //                //enumerable2 is not string, then I can add all to list
        //                result.AddRange(ToListStringIEnumerable2(enumerable));
        //            }
        //            else if (enumerable.Count() == 1 && enumerable.FirstOrNull() is IList<string>)
        //            {
        //                // IList<string> => List<string>
        //                result.AddRange(((IList<string>)enumerable.FirstOrNull()).ToList());
        //            }
        //            else if (enumerable.Count() == 1 && enumerable.FirstOrNull() is IList &&
        //                     !isEnumerableChar && !isEnumerableString)
        //            {
        //                result.AddRange(ToListStringIEnumerable2((IList)enumerable.FirstOrNull()));
        //            }
        //            else
        //            {
        //                // IList => List<string>
        //                result.AddRange(ToListStringIEnumerable2(enumerable));
        //            }
        //        }
        //        else
        //        {
        //            result.Add(item.ToString());
        //        }
        //    }
        //}
        //else
        //{
        //    result.Add(enumerable2.ToString());
        //}

        //return result;
    }
    #endregion



    public static List<string> ToListMoreString(params string[] enumerable2)
    {
        return enumerable2.ToList();
    }


}
