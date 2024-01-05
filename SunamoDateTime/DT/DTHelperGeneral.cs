namespace SunamoDateTime.DT;




public partial class DTHelperGeneral
{
    public static List<DateTime> GetDatesBetween(DateTime startDate, DateTime endDate)
    {

        List<DateTime> allDates = new List<DateTime>();
        for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            allDates.Add(date);
        return allDates;

    }

    public static DateTime StartOfWeekMonday(DateTime dt, DayOfWeek? aowWhenCalculateAsStartNextWeek)
    {
        DayOfWeek startOfWeek = DayOfWeek.Monday;
        if (dt.DayOfWeek == startOfWeek)
        {
            return dt;
        }

        var diff = (dt.DayOfWeek - startOfWeek);
        var part = (7 + diff);
        int diff2 = part % 7;
        var addedDays = dt.AddDays(-1 * diff2);

        if (aowWhenCalculateAsStartNextWeek.HasValue)
        {
            if (dt.DayOfWeek > (aowWhenCalculateAsStartNextWeek - 1))
            {
                addedDays = addedDays.AddDays(7);
            }
        }

        return addedDays.Date;
    }

    #region Parse special
    /// <summary>
    /// Find four digit letter in any string
    /// </summary>
    public static string ParseYear(string s)
    {
        var p = SHSplit.SplitChar(s, new Char[] { AllChars.dash, AllChars.slash });
        foreach (var item in p)
        {
            if (item.Length == 4)
            {
                if (SH.IsNumber(item))
                {
                    return item;
                }
            }
        }
        return string.Empty;
    }


    #endregion

    #region Set*


    public static DateTime SetMinute(DateTime d, int v)
    {
        return new DateTime(d.Year, d.Month, d.Day, d.Hour, v, d.Second);
    }

    public static DateTime SetHour(DateTime d, int v)
    {
        return new DateTime(d.Year, d.Month, d.Day, v, d.Minute, d.Second);
    }
    #endregion

    #region Other
    /// <summary>
    /// Check also for MinValue and MaxValue
    /// </summary>
    /// <param name="dt"></param>
    public static bool HasNullableDateTimeValue(DateTime? dt)
    {
        if (dt.HasValue)
        {
            if (dt.Value != DateTime.MinValue && dt.Value != DateTime.MaxValue)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Is counting only time, return as non-normalized int
    /// </summary>
    /// <param name="t"></param>
    public static long DateTimeToSecondsOnlyTime(DateTime t)
    {
        long vr = t.Hour * DTConstants.secondsInHour;
        vr += t.Minute * DTConstants.secondsInMinute;
        vr += t.Second;
        vr *= TimeSpan.TicksPerSecond;
        //vr += SqlServerHelper.DateTimeMinVal
        return vr;
    }

    public static DateTime AddDays(ref DateTime dt, double day)
    {
        dt = dt.AddDays(day);
        return dt;
    }

    /// <summary>
    /// Subtract A2 from A1
    /// </summary>
    /// <param name="dt1"></param>
    /// <param name="dt2"></param>
    public static TimeSpan Substract(DateTime dt1, DateTime dt2)
    {
        TimeSpan ts = dt1 - dt2;
        return ts;
    }
    #endregion

    #region Set*
    public static DateTime SetDateToMinValue(DateTime dt)
    {
        DateTime minVal = DateTime.MinValue;
        return new DateTime(minVal.Year, minVal.Month, minVal.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
    }

    public static DateTime SetToday(DateTime ugtFirstStep)
    {
        DateTime t = DateTime.Today;
        return new DateTime(t.Year, t.Month, t.Day, ugtFirstStep.Hour, ugtFirstStep.Minute, ugtFirstStep.Second);
    }
    #endregion

    #region Create*
    public static DateTime? Create(string y, string m, string d)
    {
        return Create(int.Parse(y), int.Parse(m), int.Parse(d));
    }

    public static DateTime? Create(int y, int m, int d)
    {
        try
        {
            return new DateTime(y, m, d);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            // because can return null, wont throw excepiton there
            ThrowEx.DummyNotThrow(ex);
            return null;
        }
    }

    public static DateTime Create(string day, string month, string hour, string minute)
    {
        return new DateTime(1, int.Parse(month), int.Parse(day), int.Parse(hour), int.Parse(minute), 0);
    }

    public static DateTime CreateTime(string hour, string minutes)
    {
        DateTime today = DateTime.MinValue;
        today = today.AddHours(double.Parse(hour));
        today = today.AddMinutes(double.Parse(minutes));
        return today;
    }
    #endregion
}
