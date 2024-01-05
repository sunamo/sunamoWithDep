namespace SunamoCollectionsGeneric._sunamo;

internal class FS
{
    internal static Func<string, string> GetDirectoryName;
    internal static Func<string, string, Task> WriteAllTextWithExc;
    internal static Func<string, bool> TryDeleteFile;
    internal static Func<string, bool> ExistsFile;
    internal static Action<string> CreateFileIfDoesntExists;
    internal static Func<string, string> WithEndSlash;
    internal static Func<string, string> WithoutEndSlash;

}
