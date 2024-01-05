namespace SunamoShared.Lazy;
public class LazyString : LazyT<string>
{
    public LazyString(Func<string, bool, string> getCommonSettings, string key) : base(getCommonSettings, key)
    {

    }
}
