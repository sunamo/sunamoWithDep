namespace SunamoData._sunamo;

internal class DictionaryHelper
{
    internal static Dictionary<T1, T2> GetDictionaryFromIList<T1, T2>(List<KeyValuePair<T1, T2>> enumerable, bool addRandomWhenKeyExists = false)
    {
        Dictionary<T1, T2> d = new Dictionary<T1, T2>();
        foreach (var item in enumerable)
        {
            var key = item.Key;

            var c = d.ContainsKey(item.Key);
            if (c)
            {
                if (addRandomWhenKeyExists)
                {
                    var k = key.ToString() + " " + RandomHelper.RandomString(5);
                    key = (T1)(dynamic)k;
                }
            }
            d.Add(key, item.Value);
        }
        return d;
    }

    #region AddOrCreate
    /// <summary>
    ///     A3 is inner type of collection entries
    ///     dictS => is comparing with string
    ///     As inner must be List, not IList etc.
    ///     From outside is not possible as inner use other class based on IList
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    /// <typeparam name="Value"></typeparam>
    /// <typeparam name="ColType"></typeparam>
    /// <param name="sl"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    internal static void AddOrCreate<Key, Value, ColType>(IDictionary<Key, List<Value>> dict, Key key, Value value,
        bool withoutDuplicitiesInValue = false, Dictionary<Key, List<string>> dictS = null)
    {
        var compWithString = false;
        if (dictS != null) compWithString = true;

        if (key is IList && typeof(ColType) != typeof(object))
        {
            var keyE = key as IList<ColType>;
            var contains = false;
            foreach (var item in dict)
            {
                var keyD = item.Key as IList<ColType>;
                if (keyD.SequenceEqual(keyE)) contains = true;
            }

            if (contains)
            {
                foreach (var item in dict)
                {
                    var keyD = item.Key as IList<ColType>;
                    if (keyD.SequenceEqual(keyE))
                    {
                        if (withoutDuplicitiesInValue)
                            if (item.Value.Contains(value))
                                return;
                        item.Value.Add(value);
                    }
                }
            }
            else
            {
                List<Value> ad = new();
                ad.Add(value);
                dict.Add(key, ad);

                if (compWithString)
                {
                    List<string> ad2 = new();
                    ad2.Add(value.ToString());
                    dictS.Add(key, ad2);
                }
            }
        }
        else
        {
            var add = true;
            lock (dict)
            {
                if (dict.ContainsKey(key))
                {
                    if (withoutDuplicitiesInValue)
                    {
                        if (dict[key].Contains(value))
                            add = false;
                        else if (compWithString)
                            if (dictS[key].Contains(value.ToString()))
                                add = false;
                    }

                    if (add)
                    {
                        var val = dict[key];

                        if (val != null) val.Add(value);

                        if (compWithString)
                        {
                            var val2 = dictS[key];

                            if (val != null) val2.Add(value.ToString());
                        }
                    }
                }
                else
                {
                    if (!dict.ContainsKey(key))
                    {
                        List<Value> ad = new();
                        ad.Add(value);
                        dict.Add(key, ad);
                    }
                    else
                    {
                        dict[key].Add(value);
                    }

                    if (compWithString)
                    {
                        if (!dictS.ContainsKey(key))
                        {
                            List<string> ad2 = new();
                            ad2.Add(value.ToString());
                            dictS.Add(key, ad2);
                        }
                        else
                        {
                            dictS[key].Add(value.ToString());
                        }
                    }
                }
            }
        }
    }

    internal static void AddOrCreate<Key, Value>(IDictionary<Key, List<Value>> sl, Key key, Value value,
        bool withoutDuplicitiesInValue = false, Dictionary<Key, List<string>> dictS = null)
    {
        AddOrCreate<Key, Value, object>(sl, key, value, withoutDuplicitiesInValue, dictS);
    }
    #endregion
}
