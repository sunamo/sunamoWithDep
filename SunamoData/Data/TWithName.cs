namespace SunamoData.Data;

public class TWithName<T>
{
    /// <summary>
    ///     Just first 5. letters
    /// </summary>
    public string name = string.Empty;

    public T t;

    public TWithName()
    {
    }

    public TWithName(string name, T t)
    {
        this.name = name;
        this.t = t;
    }


    public override string ToString()
    {
        return name;
    }

    public static TWithName<T> Get(string nameCb)
    {
        return new TWithName<T> { name = nameCb };
    }
}

public class TWithName
{
    public static TWithName<object> Get(string nameCb)
    {
        return new TWithName<object> { name = nameCb };
    }
}
