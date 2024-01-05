namespace SunamoRegex;
public class WildcardHelper
{
    public static bool IsWildcard(string text)
    {
        return text.ToCharArray().Any(d => d == AllCharsSE.q) || text.ToCharArray().Any(d => d == AllCharsSE.asterisk);
    }
}
