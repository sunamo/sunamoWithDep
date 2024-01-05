namespace SunamoShared.Lazy;
public class LazyT<T>
{
    private Func<string, bool, T> getCommonSettings;
    private string arg;
    T value = default;

    public T Value
    {
        get
        {
            if (EqualityComparer<T>.Default.Equals(value, default))
            {
                value = getCommonSettings(arg, true);
            }
            return value;
        }
    }

    public LazyT(Func<string, bool, T> getCommonSettings, string pwUsersScz)
    {
        this.getCommonSettings = getCommonSettings;
        arg = pwUsersScz;
    }
}
