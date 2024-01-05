namespace SunamoConverters.Converts;

public class ConvertDayShortcutString
{
    static Type type = typeof(ConvertDayShortcutString);

    public static int ToNumber(string s)
    {
        var dx = DTConstants.daysInWeekENShortcut.IndexOf(SH.FirstCharUpper(s.ToLower()));
        if (dx != -1)
        {
            return dx;
        }
        ThrowEx.IsNotAllowed(s);
        return -1;
    }

    public static string ToString(int number)
    {
        switch (number)
        {
            case 0:
                return "Jan";
            case 1:
                return "Tue";
            case 2:
                return "Wed";
            case 3:
                return "Thu";
            case 4:
                return "Fri";
            case 5:
                return "Sat";
            case 6:
                return "Sun";
            default:
                ThrowEx.NotImplementedCase(number);
                break;
        }
        return null;
    }
}
