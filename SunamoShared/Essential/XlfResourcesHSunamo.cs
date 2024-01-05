namespace SunamoShared.Essential;
public class XlfResourcesHSunamo
{
    /// <summary>
    /// Use LocalizationLanguagesLoader
    /// </summary>
    /// <param name="ll"></param>
    public static void SaveResouresToRLSunamo(LocalizationLanguages ll = null)
    {
        SaveResouresToRLSunamo(null, ll);
    }

    /// <summary>
    /// Use LocalizationLanguagesLoader
    /// 
    /// 1. Entry method 
    /// Only for non-UWP apps
    /// </summary>
    public static string SaveResouresToRLSunamo(string key, LocalizationLanguages ll = null)
    {
        if (ll == null)
        {
            ll = LocalizationLanguagesLoader.Load();
        }

        return XlfResourcesH.SaveResouresToRL<string, string>(key, VpsHelperSunamo.SunamoProject(), ll);
    }

    static XlfResourcesHSunamo()
    {
        TranslateDictionary.ReloadIfKeyWontBeFound = SaveResouresToRLSunamo;
    }
}
