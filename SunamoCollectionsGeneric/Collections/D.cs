namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// Must be IEnumerable, not IList
///
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="U"></typeparam>
public class D<T, U> : ISunamoDictionary<T, U>, IEnumerable, IDictionary<T, U>
{
#if DEBUG
    const string checkForContains = "ccc_netcore31";

    void OnRemove()
    {
        Debugger.Break();
    }
#endif

    public Action callWhenIsZeroElements;
    static Type type = typeof(D<T, U>);
    Dictionary<T, U> d = new Dictionary<T, U>();
    public U this[T key]
    {
        get
        {
            if (callWhenIsZeroElements != null)
            {
                if (Count == 0)
                {
                    callWhenIsZeroElements.Invoke();
                }
            }
            return d[key];

        }
        set
        {
            ContainsV(value);

            d[key] = value;
        }
    }

    public D()
    {

    }

    public ICollection<T> Keys => d.Keys;

    public ICollection<U> Values => d.Values;

    public int Count
    {
        get
        {
            return d.Count;
        }
    }

    public bool IsReadOnly => false;

    public void Add(T key, U value)
    {
        ContainsV(value);

        d.Add(key, value);
    }

    private void ContainsV(U v)
    {
#if DEBUG
        if (v.ToString().Contains(checkForContains))
        {

        }
#endif
    }

    public void Add(KeyValuePair<T, U> item)
    {
        ContainsV(item.Value);
        d.Add(item.Key, item.Value);
    }

    public void Clear()
    {
#if DEBUG
        OnRemove();
#endif

        d.Clear();
    }

    public bool Contains(KeyValuePair<T, U> item)
    {
        return d.Contains(item);
    }

    public bool ContainsKey(T key)
    {
        return d.ContainsKey(key);
    }

    public void CopyTo(KeyValuePair<T, U>[] array, int arrayIndex)
    {
        DictionaryHelper.CopyTo<T, U>(d, array, arrayIndex);
    }

    public IEnumerator<KeyValuePair<T, U>> GetEnumerator()
    {
        return d.GetEnumerator();
    }

    public bool Remove(T key)
    {
#if DEBUG
        OnRemove();
#endif
        return d.Remove(key);
    }

    public bool Remove(KeyValuePair<T, U> item)
    {
#if DEBUG
        OnRemove();
#endif
        return d.Remove(item.Key);
    }

    public bool TryGetValue(T key, out U value)
    {
        return d.TryGetValue(key, out value);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return d.GetEnumerator();
    }
}
