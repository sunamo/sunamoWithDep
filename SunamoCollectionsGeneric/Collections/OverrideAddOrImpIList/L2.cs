namespace SunamoCollectionsGeneric.Collections.OverrideAddOrImpIList;

/// <summary>
/// For debug purposes
/// RefreshingList is derived from
/// </summary>
/// <typeparam name="T"></typeparam>
public class L2<T> : RefreshingList<T>
{
    public L2() : base(null, 0)
    {

    }

    public L2(IList<T> list) : base(null, list)
    {

    }

    public L2(int capacity) : base(null, capacity)
    {

    }
}
