namespace SunamoCollectionsGeneric.Collections;

/// <summary>
/// Can be derived because new keyword
/// For completely derived from IList, use RefreshingList
/// </summary>
/// <typeparam name="T"></typeparam>
public class L<T> : List<T>
{
    public int Length => Count;
    public T defIfNotFoundIndex = default;
    public bool changed = false;
    public L()
    {
    }

    public L(IList<T> collection) : base(collection)
    {
    }

    public L(int capacity) : base(capacity)
    {
    }

    public L<T> ToList()
    {
        return this;
    }

    /// <summary>
    /// Before use is needed set up defIfNotFoundIndex
    /// </summary>
    /// <param name="i"></param>
    public new T this[int i]
    {
        set
        {
#if DEBUG
            if (value.ToString().Contains(Consts.dirUp5))
            {

            }
#endif
            changed = true;
            base[i] = value;
        }
        get
        {
            if (Length > i)
            {
                return base[i];
            }
            return defIfNotFoundIndex;
        }
    }
}
