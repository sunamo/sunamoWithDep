namespace SunamoShared.Helpers;
public class FormatHelper
{
    static Type type = typeof(FormatHelper);

    public static string parsedName = null;
    public static string parsedSurname = null;

    public static string FormatEmail(string nameSurname, string postfix)
    {
        var p = SHSplit.Split(nameSurname, AllStrings.space);
        if (p.Count != 2)
        {
            ThrowEx.WrongNumberOfElements(2, "p", p);
        }
        parsedName = p[0];
        parsedSurname = p[1];
        return FormatEmail(p[0], p[1], postfix);
    }

    public static string FormatEmail(string name, string surname, string postfix)
    {
        return SH.TextWithoutDiacritic(name.ToLower()) + AllStrings.dot + SH.TextWithoutDiacritic(surname.ToLower()) + AllStrings.commat + postfix.TrimStart(AllChars.commat);
    }
}
