namespace SunamoShared.RL;
public class ResourceLoaderRL
{
    public string GetString(string k)
    {
        return sess.i18n(k);
    }
}
