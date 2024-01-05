namespace SunamoData._sunamo;

internal class SH
{
    internal static Func<string, Func<char, bool>, char[], string> RemoveAfterFirstFunc;
    internal static Func<string, int, int, string> GetTextBetweenTwoChars;
    internal static Func<string, object, string> RemoveAfterLast;
    internal static Func<string, bool> IsNumber;
    internal static Func<string, int, int, SubstringArgs, string> Substring;
    #region Cycle detected. SunamoData -> SunamoStringSplit 24.1.2.2 -> SunamoStringData 24.1.1.1 -> SunamoData (>= 23.12.24.1).
    internal static Func<string, char[], List<string>> SplitChar;
    internal static Func<string, string[], List<int>> SplitToIntList;
    #endregion
}
