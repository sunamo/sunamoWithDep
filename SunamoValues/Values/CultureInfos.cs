namespace SunamoValues.Values;

public class CultureInfos
{
    public static CultureInfo cz = null;

    public static IFormatProvider neutral { get; set; }

    public static void Init()
    {
        if (cz == null)
        {

            cz = CultureInfo.GetCultureInfo("cs");
            if (cz == null)
            {
                Debugger.Break();
                // use cs-CZ
            }
        }
    }
}
