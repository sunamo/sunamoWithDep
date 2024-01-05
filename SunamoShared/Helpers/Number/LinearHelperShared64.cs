namespace SunamoShared.Helpers.Number;

public partial class LinearHelper
{
    /// <summary>
    /// Do A2 zadej číslo do kterého se bude počítat včetně.
    /// </summary>
    /// <param name = "from"></param>
    /// <param name = "to"></param>
    public static List<string> GetStringListFromTo(int from, int to)
    {
        return GetListFromTo(from, to).ConvertAll(d => d.ToString());
    }

    public static List<int> GetListFromTo(int from, int to)
    {
        List<int> vr = new List<int>();
        to++;
        for (; from < to; from++)
        {
            vr.Add(from);
        }

        return vr;
    }

    public static List<T> GetListFromTo<T>(int from, int to)
    {
        var s = GetStringListFromTo(from, to);
        Func<string, T> parse = (Func<string, T>)BTS.MethodForParse<T>();
        var r = CAToNumber.ToNumber<T, string>(parse, s);
        return r;
    }
}
