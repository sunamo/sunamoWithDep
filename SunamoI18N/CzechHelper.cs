namespace SunamoI18N;



public partial class CzechHelper
{
    static Type type = typeof(CzechHelper);






    public static string Dear(bool sex)
    {
        if (sex)
        {
            return "Mil\u00E1";
        }
        return "Mil\u00FD";
    }

    //
    public static string Esteemed(bool sex)
    {
        if (sex)
        {
            return "Vážená";
        }
        return "Vážený";
    }

    public static string Honorable(bool sex, string dear, string name)
    {
        string f = null;
        #region MyRegion
        //if (ThisApp.l == Langs.en)
        //{
        //    f = sess.i18n(XlfKeys.Dear);
        //}
        //else if(ThisApp.l == Langs.cs)
        //{
        //    f =
        //}
        //else
        //{
        //    ThrowEx.NotImplementedCase(ThisApp.l);
        //}

        //f += AllStrings.space;
        #endregion

        if (sex)
        {
            // its auto with dear
            f = dear + AllStrings.space + sess.i18n(XlfKeys.madam) + " " + name;
        }
        else
        {
            f = dear + AllStrings.space + sess.i18n(XlfKeys.sir) + " " + name;
        }

        return SH.FirstCharUpper(f);
    }

    public static bool GetSexFromSurname(string name)
    {
        // ová = á
        if (SH.EndsWithArray(name, new String[] { "ova", "á" }))
        {
            return true;
        }
        return false;
    }
}
