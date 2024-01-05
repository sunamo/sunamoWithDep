namespace SunamoShared.Helpers;

public partial class LocaleHelper
{
    public static void Init()
    {
        foreach (var item in CultureInfo.GetCultures(CultureTypes.AllCultures))
        {

        }
    }

    /// <summary>
    /// Its not good idea because for en return AG
    /// Must use GetCountryForLang2
    /// </summary>
    /// <param name="lang"></param>
    /// <returns></returns>
    public static string GetCountryForLang(string lang)
    {
        lang = lang.ToLower();
        foreach (var item in CultureInfo.GetCultures(CultureTypes.AllCultures))
        {
            var p = SHSplit.Split(item.Name, AllStrings.dash);
            if (p.Count > 1)
            {
                if (p[0] == lang)
                {
                    if (p[1].Length == 2)
                    {
                        ComplexInfoString cis = new ComplexInfoString(p[1]);
                        if (cis.QuantityUpperChars == 2)
                        {
                            // Its not good idea because for en return AG
                            return p[1];
                        }
                    }

                }
            }
        }
        return null;
    }
}
