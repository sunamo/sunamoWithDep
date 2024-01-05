namespace SunamoShared.SE.Helpers.FileSystem.RelPath;

#region

public partial class PathInternal
{
    /// <summary>Returns a comparison that can be used to compare file and directory names for equality.</summary>
    public static StringComparison StringComparison =>
        IsCaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;

    /// <summary>Gets whether the system is case-sensitive.</summary>
    public static bool IsCaseSensitive => true;
    //return !(OperatingSystem.IsWindows() || OperatingSystem.IsMacOS() || OperatingSystem.IsIOS() || OperatingSystem.IsTvOS() || OperatingSystem.IsWatchOS());
}

#endregion
