namespace SunamoDateTime.DT;

public class TimeSpanHelper
{
    public static TimeSpan Parse(string span)
    {
        TimeSpan ts = new TimeSpan(int.Parse(span.Split(':')[0]),    // hours
        int.Parse(span.Split(':')[1]),    // minutes
        0);
        return ts;
    }
}
