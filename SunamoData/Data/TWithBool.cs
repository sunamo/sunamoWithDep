namespace SunamoData.Data;

public class TWithBool<T> //: ITWithDt<T>
{
    public T t { get; set; } = default;
    public bool b { get; set; }
}
