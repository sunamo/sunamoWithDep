namespace SunamoShared.SE;
/// <summary>
///     Usage: methods from .web
///     Nemusí být ve NS protože je pouze tady
///     Musí se furt jmenovat stejně, když budu kopírovat soubory ze SunExc do sunamo tak se to obejde bez jakékoliv
///     editace
/// </summary>
public class SunamoPageHelperSunamo
{
    public static Func<string, string, string, string> localizedString;

    /// <summary>
    ///     Return always en
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string i18n(string key)
    {
        return i18n("en", key, Consts.Nope);
    }

    public static string i18n(string l, string key, string ms)
    {
        if (localizedString == null)
        {
            // For small apps where is loading xlf overkill
            return key;
        }

        return localizedString(l, key, ms);
    }
}
