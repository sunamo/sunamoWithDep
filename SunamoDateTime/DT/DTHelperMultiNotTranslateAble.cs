using SunamoLang;

namespace SunamoDateTime.DT;


public partial class DTHelperMulti
{
    public static string FilesFounded(int c)
    {
        if (ThisApp.l == Langs.cs)
        {
            if (c < 2)
            {
                return "soubor nalezen";
            }
            if (c < 5)
            {
                return "soubory nalezeny";
            }
            return "souborů nalezeno";
        }
        return sess.i18n(XlfKeys.filesFounded);
    }
}
