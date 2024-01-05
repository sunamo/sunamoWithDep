namespace SunamoCollectionsGeneric._sunamo;

internal class SH
{
    internal static Func<string, string, bool> MatchWildcard;
    //internal static Func<string, string, List<string>> Split;
    //internal static Func<string, String[], List<string>> SplitMore;
    //internal static Func<string, List<string>> SplitByWhiteSpaces;
    internal static Func<string, List<string>> GetLines;
    internal static Func<string, string> GetFirstWord;
    internal static Func<string, string, string> Format2;
    internal static Func<string, Func<char, bool>, Char[], string> RemoveAfterFirstFunc;
    internal static Func<string, string> TextWithoutDiacritic;

    // Z důvodu že přetěžování metod nefunguje jsem jednu metodu přejmenoval na JoinChar

    internal static Func<char, IList, string> JoinChar;
    //internůFirstCharUpperal static Func<string, IList, string> Join;
    internal static Func<string, List<string>, ContainsCompareMethod, bool> ContainsAll;
    internal static Func<string, string, bool, bool> StartingWith;
    internal static Func<string, (bool, string)> IsNegationTuple;

    internal static Func<string, string, string, string> Replace;
    internal static Func<string, string, string> PostfixIfNotEmpty;
    internal static Func<List<string>, string> JoinNL;
    internal static Func<string, bool> ContainsDiacritic;
    internal static Func<string, string> FirstCharUpper;
    internal static Func<string, string> ReplaceWhiteSpacesWithoutSpaces;
    internal static Func<string, string> ReplaceAllDoubleSpaceToSingle;
    internal static Func<string, string, SearchStrategy, bool> Contains;
}
