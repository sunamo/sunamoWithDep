namespace SunamoDateTime._sunamo;

using SunamoCollectionsChangeContent.Args;

internal class CA
{
    internal static Func<List<string>, int, int, List<int>> ToInt2;
    internal static Func<String[], List<string>> ToListString;
    //internal static Func<IList, int, int, List<int>> ToInt;
    internal static Func<List<string>, int, List<int>> ToInt1;
    internal static Func<List<string>, List<int>> ToInt0;
    internal static Func<int, IList, bool> HasIndex;
    internal static Func<ChangeContentArgs2, List<string>, Func<string, string, string, string>, string, string> ChangeContent2;

    internal static T[] ToArrayT<T>(params T[] aB)
    {
        return aB;
    }
}
