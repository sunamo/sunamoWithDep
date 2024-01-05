namespace SunamoRandom;


public static partial class RandomHelper
{


    public static string RandomString(int delka)
    {
        delka--;
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i != delka; i++)
        {
            sb.Append(RandomChar());
        }
        return sb.ToString();
    }



    public static char RandomChar()
    {
        return RandomElementOfCollection(vsZnaky)[0];
    }

    public static string RandomElementOfCollection(IList ppk)
    {
        int nt = RandomInt(ppk.Count);
        return ppk[nt].ToString();
    }

    /// <summary>
    /// Vr�t� ��slo mezi 0 a A1-1
    /// </summary>
    /// <param name="to"></param>
    public static int RandomInt(int to)
    {
        return s_rnd.Next(0, to);
    }


}
