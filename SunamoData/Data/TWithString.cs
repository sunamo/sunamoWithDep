namespace SunamoData.Data;

public class TWithString<T>
{
    public TWithString()
    {

    }

    public TWithString(T t, string path)
    {
        this.t = t;
        this.path = path;
    }

    public T t = default;
    public string path = null;

    public override string ToString()
    {
        return path;
    }
}
