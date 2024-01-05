namespace SunamoCollectionWithoutDuplicates;

public abstract class CollectionWithoutDuplicatesBaseIList<T> : IDumpAsString, IList<T>
{
    public List<T> c = null;
    public List<string> sr = null;
    bool? _allowNull = false;
    /// <summary>
    /// true = compareWithString
    /// false = !compareWithString
    /// null = allow null (can't compareWithString)
    /// </summary>
    public bool? allowNull
    {
        get => _allowNull;
        set
        {
            _allowNull = value;
            if (value.HasValue && value.Value)
            {
                sr = new List<string>(count);
            }
        }
    }

    public int Count => c.Count;

    public bool IsReadOnly => false;

    public T this[int index] { get => c[index]; set => c[index] = value; }

    public static bool br = false;
    int count = 10000;

    public CollectionWithoutDuplicatesBaseIList()
    {
        if (br)
        {
            System.Diagnostics.Debugger.Break();
        }
        c = new List<T>();
    }

    public CollectionWithoutDuplicatesBaseIList(int count)
    {
        this.count = count;
        c = new List<T>(count);
    }

    public CollectionWithoutDuplicatesBaseIList(IList<T> l)
    {
        c = new List<T>(l.ToList());
    }

    bool resultOfAdd = false;

    public void Add(T t2)
    {
        resultOfAdd = false;

        var con = ContainsN(t2);
        if (con.HasValue)
        {
            if (!con.Value)
            {
                c.Add(t2);
                resultOfAdd = true;
            }
        }
        else
        {
            if (!allowNull.HasValue)
            {
                c.Add(t2);
                resultOfAdd = true;
            }
        }

        if (resultOfAdd)
        {
            if (IsComparingByString())
            {
                sr.Add(ts);
            }
        }


    }

    protected abstract bool IsComparingByString();

    protected string ts = null;

    /// <summary>
    /// Dříve vracela Contains() bool? ale musí splňoval IList
    /// </summary>
    public bool? resultOfBoolN = null;

    public abstract bool? ContainsN(T t2);

    public bool Contains(T item)
    {
        return ContainsN(item).GetValueOrDefault();
    }

    public abstract int AddWithIndex(T t2);

    public abstract int IndexOf(T path);

    List<T> wasNotAdded = new List<T>();

    /// <summary>
    /// If I want without checkink, use c.AddRange
    /// </summary>
    /// <param name="enumerable"></param>
    /// <param name="withoutChecking"></param>
    public List<T> AddRange(IList<T> list)
    {
        wasNotAdded.Clear();
        foreach (var item in list)
        {
            Add(item);
            if (!resultOfAdd)
            {
                wasNotAdded.Add(item);
            }
        }
        return wasNotAdded;
    }

    public string DumpAsString(string operation, DumpAsStringHeaderArgs a)
    {
        throw new Exception("Nemůže tu být protože DumpListAsStringOneLine jsem přesouval do sunamo a tam už zůstane");
        //return c.DumpAsString(operation, a);
    }

    public void Insert(int index, T item)
    {
        c.Insert(index, item);
    }

    public void RemoveAt(int index)
    {
        c.RemoveAt(index);
    }

    public void Clear()
    {
        c.Clear();
    }
    public void CopyTo(T[] array, int arrayIndex)
    {
        c.CopyTo(array, arrayIndex);
    }

    public bool Remove(T item)
    {
        return c.Remove(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return c.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return c.GetEnumerator();
    }
}
