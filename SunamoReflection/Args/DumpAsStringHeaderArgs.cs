namespace SunamoArgs;

/// <summary>
///     Mus� b�t zde proto�e je sd�lena ve extensions i sunamo
/// </summary>
public class DumpAsStringHeaderArgs
{
    public static DumpAsStringHeaderArgs Default = new();

    /// <summary>
    ///     Only names of properties to get
    ///     If starting with ! => surely delete
    /// </summary>
    public List<string> onlyNames = new();
}
