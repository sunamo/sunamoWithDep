namespace SunamoDateTime.Converters;

public class UnixDateConverter
{
    public static long To(DateTime target)
    {
        var date = new DateTime(1970, 1, 1, 0, 0, 0, target.Kind);
        var unixTimestamp = System.Convert.ToInt64((target - date).TotalSeconds);

        return unixTimestamp;
    }

    public static DateTime From(long timestamp)
    {
        var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);

        return dateTime.AddSeconds(timestamp);
    }
}
