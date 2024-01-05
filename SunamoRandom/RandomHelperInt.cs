namespace SunamoRandom;


public static partial class RandomHelper
{
    /// <summary>
    /// Vrac� ��slo od A1 do A2-1
    /// </summary>
    /// <param name="od"></param>
    /// <param name="to"></param>
    public static int RandomInt2(int od, int to)
    {
        return s_rnd.Next(od, to);
    }

    public static int RandomInt()
    {
        return s_rnd.Next(0, int.MaxValue);
    }

    /// <summary>
    /// Vr�t� ��slo mezi A1 a A2 v�etn�
    /// </summary>
    /// <param name="od"></param>
    /// <param name="to"></param>\
    public static int RandomInt(int od, int to)
    {
        if (to == int.MaxValue)
        {
            to--;
        }
        if (od > to)
        {
            ThrowEx.Custom($"From {od} is higher than to {to}");
        }

        return s_rnd.Next(od, to + 1);
    }


}
