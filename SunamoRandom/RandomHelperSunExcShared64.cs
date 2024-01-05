namespace SunamoRandom;


public partial class RandomHelper
{
    #region For easy copy from RandomHelperShared64.cs
    public static List<char> vsZnaky = null;

    /// <summary>
    /// upper, lower and digits
    /// </summary>
    public static List<char> vsZnakyWithoutSpecial = null;
    static RandomHelper()
    {
        vsZnaky = new List<char>(AllCharsSE.lowerChars.Count + AllCharsSE.numericChars.Count + AllCharsSE.specialChars.Count + AllCharsSE.upperChars.Count);
        vsZnaky.AddRange(AllCharsSE.lowerChars);
        vsZnaky.AddRange(AllCharsSE.numericChars);
        vsZnaky.AddRange(AllCharsSE.specialChars);
        vsZnaky.AddRange(AllCharsSE.upperChars);

        vsZnakyWithoutSpecial = new List<char>(AllCharsSE.lowerChars.Count + AllCharsSE.numericChars.Count + AllCharsSE.upperChars.Count);
        vsZnakyWithoutSpecial.AddRange(AllCharsSE.lowerChars);
        vsZnakyWithoutSpecial.AddRange(AllCharsSE.numericChars);
        vsZnakyWithoutSpecial.AddRange(AllCharsSE.upperChars);
    }

    #endregion
}
