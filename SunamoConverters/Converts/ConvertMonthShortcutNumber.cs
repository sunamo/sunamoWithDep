namespace SunamoConverters.Converts;

public class ConvertMonthShortcutNumber
{
    public static string ToShortcut(int number)
    {
        var fullName = ConvertMonthNumberString.ToString(number);
        return ConvertMonthShortcutFullName.ToShortcut(fullName);
    }

    public static int FromShortcut(string shortcut)
    {
        var fullName = ConvertMonthShortcutFullName.FromShortcut(shortcut);
        return ConvertMonthNumberString.ToNumber(fullName);
    }
}
