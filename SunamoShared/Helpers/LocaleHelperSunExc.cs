namespace SunamoShared.Helpers;


public partial class LocaleHelper
{
    #region For easy copy
    public static string GetCountryForLang2(string lang)
    {
        // Easy copy = BCL enum parse
        Langs l = (Langs)Enum.Parse(typeof(Langs), lang);
        switch (l)
        {
            case Langs.cs:
                return "CZ";
            case Langs.en:
            default:
                return "GB";
        }
    }
    public static Langs? GetLangForCountry2(string country)
    {
        foreach (var item in CountryLang.d)
        {
            if (item.Value == country)
            {
                return item.Key;
            }
        }
        return null;
    }

    public static string GetLangForCountry(string country)
    {
        country = country.ToLower();
        foreach (var item in CultureInfo.GetCultures(CultureTypes.AllCultures))
        {
            var p = SHSplit.Split(item.Name, AllStrings.dash);
            if (p.Count > 1)
            {
                if (p[1] == country)
                {
                    if (p[0].Length == 2)
                    {
                        //ComplexInfoString cis = new ComplexInfoString(p[0]);
                        //if (cis.QuantityLowerChars == 2)
                        //{
                        // Its not good idea because for en return AG
                        return p[0];
                        //}
                    }

                }
            }
        }
        return null;
    }
    #endregion
}
