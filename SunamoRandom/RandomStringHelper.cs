namespace SunamoRandom;

/// <summary>
/// For easy copy where is needed generate random sting and is not availbale other methods (like System.Web.Security.Membership.GeneratePassword etc.)
/// </summary>
public class RandomStringHelper
{
    static Random random = new Random();
    static string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    static char[] stringChars = null;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string RandomString(int v, int numberOfNonAlphanumericCharacters)
    {
        int nonAlphaNumeric = v - numberOfNonAlphanumericCharacters;
        stringChars = new char[v];

        int i = 0;

        for (; i < numberOfNonAlphanumericCharacters; i++)
        {
            stringChars[i] = AllCharsSE.specialCharsAll[random.Next(AllCharsSE.specialCharsAll.Count)];
        }

        for (; i < v; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        return new String(stringChars);
    }
}
