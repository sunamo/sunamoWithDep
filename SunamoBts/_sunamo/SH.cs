namespace SunamoBts._sunamo;

internal class SH
{
    internal static Func<string, string> FromSpace160To32;
    internal static Func<string, char[], bool> IsNumber;
    internal static Func<int, int, string> MakeUpToXChars;
    internal static Func<string, char> GetFirstChar;
    internal static Func<string, char, string> RemoveAfterFirstChar;
}
