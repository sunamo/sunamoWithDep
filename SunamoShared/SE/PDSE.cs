namespace SunamoShared.SE;
/// < summary>
///     Preprocessor directives
/// </summary>
public class PDSE
{
    private static readonly bool showMbDebug = true;
    public static Action<string> delShowMb = null;

    private static Action<string> writeToStartupLogRelease;

    public static Action<string> WriteToStartupLogRelease
    {
        get => writeToStartupLogRelease ?? (s => { });
        set => writeToStartupLogRelease = value;
    }

    public static void ShowMb(string v)
    {
        if (showMbDebug)
        {
            delShowMb?.Invoke(v);
        }
    }
}
