namespace SunamoDebugCollection;

/// <summary>
/// Can be use also in production
/// </summary>
/// <typeparam name="T"></typeparam>
public class DebugCollection<T> : List<T>
{
    public List<T> dontAllow = new List<T>();

    public DebugCollection()
    {

    }

    public DebugCollection(IList<T> t) : base(t)
    {

    }

    public DebugCollection(int count) : base(count)
    {

    }

    public new T this[int i]
    {
        get { return base[i]; }
        set
        {
            if (char.IsLower(value.ToString()[0]))
            {

            }
            base[i] = value;
        }
    }

    public new void Add(T t)
    {
        if (dontAllow.Contains(t))
        {
#if DEBUG
            //////DebugLogger.Break();
#endif
        }
        else
        {
            base.Add(t);
        }
    }
}
