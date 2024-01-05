namespace SunamoNumbers;


public static partial class NH
{
    private static Type type = typeof(NH);

    public static string MakeUpTo2NumbersToZero(int p)
    {
        string s = p.ToString();
        if (s.Length == 1)
        {
            return "0" + p;
        }
        return s;
    }

    public static T Average<T>(List<T> list)
    {
        return Average<T>(Sum<T>(list), list.Count);
    }

    public static T Average<T>(dynamic gridWidth, dynamic columnsCount)
    {
        if (EqualityComparer<T>.Default.Equals(columnsCount, (T)NH.ReturnZero<T>()))
        {
            return (T)NH.ReturnZero<T>();
        }

        if (EqualityComparer<T>.Default.Equals(gridWidth, (T)NH.ReturnZero<T>()))
        {
            return (T)NH.ReturnZero<T>();
        }

        dynamic result = gridWidth / columnsCount;
        return result;
    }

    public static int Max(List<int> createEmpty)
    {
        int max = int.MinValue;

        foreach (var item in createEmpty)
        {
            if (max < item)
            {
                max = item;
            }
        }

        return max;
    }

    public static int Min(List<int> createEmpty)
    {
        int max = int.MaxValue;

        foreach (var item in createEmpty)
        {
            if (max > item)
            {
                max = item;
            }
        }

        return max;
    }

    /// <summary>
    /// Must be object to use in EqualityComparer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    private static object ReturnZero<T>()
    {
        var t = typeof(T);
        if (t == Types.tDouble)
        {
            return NumConsts.zeroDouble;
        }
        else if (t == Types.tInt)
        {
            return NumConsts.zeroInt;
        }
        else if (t == Types.tFloat)
        {
            return NumConsts.zeroFloat;
        }
        ThrowEx.NotImplementedCase(t.FullName);
        return null;
    }

    public static T Sum<T>(List<T> list)
    {
        dynamic sum = 0;
        foreach (var item in list)
        {
            sum += item;
        }
        return sum;
    }

    public static string JoinAnotherTokensIfIsNumber(List<string> p, int i)
    {
        StringBuilder sb = new StringBuilder();

        for (; i < p.Count; i++)
        {
            if (BTS.IsInt(p[i]))
            {
                sb.Append(p[i]);
            }
            else
            {
                break;
            }
        }

        return sb.ToString();
    }
}
