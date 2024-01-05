namespace SunamoNumbers;



/// <summary>
/// Number Helper Class
/// </summary>
public static partial class NH
{
    /// <summary>
    /// Vytvoří interval od A1 do A2 včetně
    /// </summary>
    /// <param name="od"></param>
    /// <param name="to"></param>
    public static List<int> GenerateIntervalInt(int od, int to)
    {
        List<int> vr = new List<int>();
        for (int i = od; i < to; i++)
        {
            vr.Add(i);
        }
        vr.Add(to);
        return vr;
    }

    public static string CalculateMedianAverage(List<float> l2, out MedianAverage<double> medianAverage)
    {
        var l = CAToNumber.ToNumber<double, float>(double.Parse, l2);
        return CalculateMedianAverage(l, out medianAverage);
    }

    public static string CalculateMedianAverage(List<long> l2)
    {
        var l = CAToNumber.ToNumber<double, long>(double.Parse, l2);
        return CalculateMedianAverage(l);
    }

    public static float RoundAndReturnInInputType(float ugtKm, int v)
    {
        string vr = Math.Round(ugtKm, v).ToString();
        return float.Parse(vr);
    }

    public static void RemoveEndingZeroPadding(List<byte> bajty)
    {
        for (int i = bajty.Count - 1; i >= 0; i--)
        {
            if (bajty[i] == 0)
            {
                bajty.RemoveAt(i);
            }
            else
            {
                break;
            }
        }
    }

    /// <summary>
    /// Reversion is DTHelperGeneral.FullYear
    /// </summary>
    /// <param name="year"></param>
    /// <returns></returns>
    public static byte Last2NumberByte(int year)
    {
        var ts = year.ToString();
        ts = ts.Substring(ts.Length - 3);
        return byte.Parse(ts);
    }

    /// <summary>
    /// Cast A1,2 to double and divide
    /// </summary>
    /// <param name="textC"></param>
    /// <param name="diac"></param>
    public static double Divide(object textC, object diac)
    {
        return double.Parse(textC.ToString()) / double.Parse(diac.ToString());
    }

    public static string MakeUpTo2NumbersToZero(byte p)
    {
        string s = p.ToString();
        if (s.Length == 1)
        {
            return "0" + p;
        }
        return s;
    }


    public static int GetLowest(List<int> excludedValues, List<int> list)
    {
        list.Sort();
        var vr = list[0];
        while (excludedValues.Contains(vr))
        {
            list.RemoveAt(0);
            if (list.Count > 0)
            {
                vr = list[0];
            }
            else
            {
                //
            }
        }

        return vr;
    }

    public static List<byte> GenerateIntervalByte(byte od, byte to)
    {
        List<byte> vr = new List<byte>();
        for (byte i = od; i < to; i++)
        {
            vr.Add(i);
        }
        vr.Add(to);
        return vr;
    }

    public static List<T> Sort<T>(params T[] t)
    {
        List<T> c = new List<T>(t);
        c.Sort();
        return c;
    }

    public static string CalculateMedianAverage(Dictionary<string, List<float>> typeWithSalaries)
    {
        TextOutputGenerator tog = new TextOutputGenerator();
        var d = new Dictionary<string, (float, string)>();

        foreach (var item in typeWithSalaries)
        {
            MedianAverage<double> ma = null;
            var r = item.Value.Count > 1 ? NH.CalculateMedianAverage(item.Value, out ma) : item.Value[0].ToString();
            var f = item.Value.Count > 1 ? (float)ma.average : item.Value[0];
            d.Add(item.Key, (f, r));

        }

        var ord = d.OrderByDescending(d => d.Value.Item1);
        foreach (var item in ord)
        {
            tog.PairBullet(item.Key, item.Value.Item2);
        }

        return tog.ToString();
    }

    public static string CalculateMedianAverage(List<double> list)
    {
        MedianAverage<double> medianAverage = null;
        return CalculateMedianAverage(list, out medianAverage);
    }

    public static string CalculateMedianAverage(List<double> list, out MedianAverage<double> medianAverage)
    {
        list.RemoveAll(d => d == 0);

        ThrowEx.OnlyOneElement("list", list);

        medianAverage = new MedianAverage<double>();
        medianAverage.count = list.Count;
        medianAverage.median = NH.Median<double>(list);
        medianAverage.average = NH.Average<double>(list);
        medianAverage.min = list.Min();
        medianAverage.max = list.Max();

        return medianAverage.ToString();
    }


    public static double Average(double gridWidth, double columnsCount)
    {
        return Average<double>(gridWidth, columnsCount);
    }


    /// <summary>
    /// Median = most frequented value
    /// Note: specified list would be mutated in the process.
    /// Working excellent
    /// 4, 0 = 0
    /// 4, 4, 250, 500, 500 = 250
    /// 4, 4, 250, 500, 500 = 250
    /// 4, 4, 4, 4, 250, 500, 500 = 4
    /// </summary>
    public static T Median<T>(this IList<T> list) where T : IComparable<T>
    {
        return list.NthOrderStatistic((list.Count - 1) / 2);
    }

    public static (int, string) NumberIntUntilWontReachOtherChar(string s)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsNumber(s[i]))
            {
                sb.Append(s[i]);
            }
            else
            {
                break;
            }
        }

        var result = sb.ToString();

        s = SHReplace.ReplaceOnce(s, result, string.Empty);


        return (BTS.ParseInt(result, int.MaxValue), s);
    }

    /// <summary>
    /// Working excellent
    /// 4, 0 = 2 (as online)
    /// 4, 4, 250, 500, 500 = 250
    /// 4, 4, 250, 500, 500 = 250
    /// 4, 4, 4, 4, 250, 500, 500 = 4
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="numbers"></param>
    public static double Median2<T>(IList<T> numbers)
    {
        int numberCount = numbers.Count();
        int halfIndex = numbers.Count() / 2;
        var sortedNumbers = numbers.OrderBy(n => n);
        double median;
        if ((numberCount % 2) == 0)
        {
            var d = sortedNumbers.ElementAt(halfIndex);
            var d2 = sortedNumbers.ElementAt((halfIndex - 1));
            median = Sum(CA.ToListString(new string[] { d.ToString(), d2.ToString() })) / 2;
        }
        else
        {
            median = double.Parse(sortedNumbers.ElementAt(halfIndex).ToString());
        }
        return median;
    }

    public static double Median<T>(this IList<T> sequence, Func<T, double> getValue)
    {
        var list = sequence.Select(getValue).ToList();
        var mid = (list.Count - 1) / 2;
        return list.NthOrderStatistic(mid);
    }



    public static double Sum(List<string> list)
    {
        double result = 0;
        foreach (var item in list)
        {
            var d = double.Parse(item);
            result += d;
        }
        return result;
    }

}
