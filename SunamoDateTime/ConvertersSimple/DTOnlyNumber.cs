namespace SunamoDateTime.ConvertersSimple;




public class DTOnlyNumber
{
    static Type type = typeof(DTOnlyNumber);

    public static string To(DateTime s)
    {
        var s2 = DTHelperGeneral.ShortYear(s.Year) + NH.MakeUpTo2NumbersToZero(s.Month) + NH.MakeUpTo2NumbersToZero(s.Day);
        return s2;
    }

    public static DateTime From(string s)
    {
        ThrowEx.NotImplementedMethod();
        return DateTime.MinValue;
    }


}
