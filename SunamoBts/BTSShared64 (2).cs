namespace SunamoBts;

public partial class BTS
{
    #region GetNumberedList*
    /// <param name="p"></param>
    /// <param name="max"></param>
    /// <param name="postfix"></param>
    public static string[] GetNumberedListFromTo(int p, int max)
    {
        max++;
        List<string> vr = new List<string>();
        for (int i = 0; i < max; i++)
        {
            vr.Add(i.ToString());
        }
        return vr.ToArray();
    }

    public static List<string> GetNumberedListFromTo(int p, int max, string postfix = ". ")
    {
        max++;
        max += p;
        List<string> vr = new List<string>();
        for (int i = p; i < max; i++)
        {
            vr.Add(i + postfix);
        }
        return vr;
    }

    private static List<string> GetNumberedListFromToList(int p, int indexOdNext)
    {
        List<string> vr = new List<string>();
        string[] o = GetNumberedListFromTo(p, indexOdNext);
        foreach (object item in o)
        {
            vr.Add(item.ToString());
        }
        return vr;
    }
    #endregion


    static Type type = typeof(BTS);

    public static string ToString<T>(T t)
    {
        return t.ToString();
    }

    /// <summary>
    /// return Func<string, T1> or null
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <returns></returns>
    public static object MethodForParse<T1>()
    {
        var t = typeof(T1);
        #region Same seria as in DefaultValueForTypeT
        #region MyRegion
        if (t == Types.tString)
        {
            return new Func<string, string>(ToString<string>);
        }
        if (t == Types.tBool)
        {
            return new Func<string, bool>(bool.Parse);
        }
        #endregion

        #region Signed numbers
        if (t == Types.tFloat)
        {
            return new Func<string, float>(float.Parse);
        }
        if (t == Types.tDouble)
        {
            return new Func<string, double>(double.Parse);
        }
        if (t == Types.tInt)
        {
            return new Func<string, int>(int.Parse);
        }
        if (t == Types.tLong)
        {
            return new Func<string, long>(long.Parse);
        }
        if (t == Types.tShort)
        {
            return new Func<string, short>(short.Parse);
        }
        if (t == Types.tDecimal)
        {
            return new Func<string, decimal>(decimal.Parse);
        }
        if (t == Types.tSbyte)
        {
            return new Func<string, sbyte>(sbyte.Parse);
        }
        #endregion

        #region Unsigned numbers
        if (t == Types.tByte)
        {
            return new Func<string, byte>(byte.Parse);
        }
        if (t == Types.tUshort)
        {
            return new Func<string, ushort>(ushort.Parse);
        }
        if (t == Types.tUint)
        {
            return new Func<string, uint>(uint.Parse);
        }
        if (t == Types.tUlong)
        {
            return new Func<string, ulong>(ulong.Parse);
        }
        #endregion

        if (t == Types.tDateTime)
        {
            return new Func<string, DateTime>(DateTime.Parse);
        }
        if (t == Types.tGuid)
        {
            return new Func<string, Guid>(Guid.Parse);
        }
        if (t == Types.tChar)
        {
            return new Func<string, char>(SH.GetFirstChar);
        }

        #endregion

        return null;
    }
    public static bool IsDateTime(string dt)
    {
        if (dt == null)
        {
            return false;
        }
        return DateTime.TryParse(dt, out lastDateTime);
    }

    /// <summary>
    /// POkud bude A1 nevyparsovatelné, vrátí int.MinValue
    /// Replace spaces
    /// </summary>
    /// <param name="entry"></param>
    public static int ParseInt(string entry)
    {

        int lastInt2 = 0;
        if (int.TryParse(entry.Replace(AllStringsSE.space, string.Empty), out lastInt2))
        {
            return lastInt2;
        }
        return int.MinValue;
    }

    public static bool IsBool(string trim)
    {
        if (trim == null)
        {
            return false;
        }
        return bool.TryParse(trim, out lastBool);
    }

    public static byte lastByte = 255;
    public static bool lastBool = false;

    public static DateTime lastDateTime = DateTime.MinValue;

    public static byte ParseByte(string entry)
    {
        byte lastInt2 = 0;
        if (byte.TryParse(entry, out lastInt2))
        {
            return lastInt2;
        }
        return byte.MinValue;
    }

    public static short ParseShort(string entry)
    {
        return ParseShort(entry, short.MinValue);
    }

    public static short ParseShort(string entry, short defVal)
    {
        short lastInt2 = 0;
        if (short.TryParse(entry, out lastInt2))
        {
            return lastInt2;
        }
        return defVal;
    }

    public static int? ParseInt(string entry, int? _default)
    {
        int lastInt2 = 0;
        if (int.TryParse(entry, out lastInt2))
        {
            return lastInt2;
        }
        return _default;
    }

    public static string BoolToStringEn(bool p, bool lower = false)
    {
        string vr = null;
        if (p)
            vr = "Yes";
        else
        {
            vr = "No";
        }

        return vr.ToLower();
    }

    public static object GetMinValueForType(Type idt)
    {
        if (idt == typeof(byte))
        {
            return 1;
        }
        else if (idt == typeof(short))
        {
            return short.MinValue;
        }
        else if (idt == typeof(int))
        {
            return int.MinValue;
        }
        else if (idt == typeof(long))
        {
            return long.MinValue;
        }
        else if (idt == typeof(sbyte))
        {
            return sbyte.MinValue;
        }
        else if (idt == typeof(ushort))
        {
            return ushort.MinValue;
        }
        else if (idt == typeof(uint))
        {
            return uint.MinValue;
        }
        else if (idt == typeof(ulong))
        {
            return ulong.MinValue;
        }
        ThrowEx.Custom("Nepovolen\u00FD nehodnotov\u00FD typ v metod\u011B GetMinValueForType");
        return null;
    }

    /// <summary>
    /// If has value true, return true. Otherwise return false
    /// </summary>
    /// <param name="t"></param>
    public static bool GetValueOfNullable(bool? t)
    {

        if (t.HasValue)
        {
            return t.Value;
        }
        return false;
    }








    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Invert(bool b, bool really)
    {
        if (really)
        {
            return !b;
        }
        return b;
    }


}
