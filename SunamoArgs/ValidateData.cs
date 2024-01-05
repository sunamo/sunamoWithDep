namespace SunamoArgs;

/// <summary>
///     Must be in shared because desktop reference PathEditor and therefore this class cant be in desktop
/// </summary>
public class ValidateData
{
    public static readonly ValidateData Default = new ValidateData();
    public bool allowEmpty = false;

    /// <summary>
    ///     Strings which are not allowed
    /// </summary>
    public List<string> excludedStrings = new List<string>();

    public string messageToReallyShow;

    public string messageWhenValidateMethodFails = null;
    public bool trim = true;
    public Func<string, bool> validateMethod;

    // https://stackoverflow.com/a/43707185
    //[MethodImpl(MethodImplOptions.NoInlining)]
    public int ValidateNotInline()
    {
        int i = 0;
        return i;
    }
}
