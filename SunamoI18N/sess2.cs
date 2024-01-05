using SunamoLang;
using SunamoXlf;

namespace SunamoI18N;

public static class sess
{
    static Type type = typeof(sess);

    public static string i18n(string key)
    {
        // if (Exc.aspnet)
        // {
        //     //ThrowEx.IsNotAllowed("sess.i18n in asp.net due to use global ThisApp.l");
        // }

        switch (ThisApp.l)
        {
            case Langs.cs:
                return RLData.cs[key];
            case Langs.en:
                return RLData.en[key];
            default:
                ThrowEx.NotImplementedCase(ThisApp.l);
                break;
        }
        return null;
    }
}
