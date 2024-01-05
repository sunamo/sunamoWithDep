namespace SunamoValues.Constants;

/// <summary>
/// Here can be just constants, not methods
/// </summary>
public class SunamoStrings
{
    // TODO: Clean which are not necessary here

    static SunamoStrings()
    {
        messageIfEmpty = MessageIfEmpty("data");
    }

    /// <summary>
    /// Wasn't found any data to show
    /// </summary>
    public static string messageIfEmpty = null;
    //public static string IsNotInRange = "is not in range";

    public static string MessageIfEmpty(string p)
    {
        return "";
    }
}
