namespace SunamoParsing;

public class ParserTwoValues
{
    public static string ToString(string delimiter, string a, string b)
    {
        return a + delimiter + b;
    }

    public static List<double> ParseDouble(string delimiter, string s)
    {
        return CAToNumber.ToNumber<double, string>(double.Parse, ParseString(delimiter, s));
    }

    public static List<string> ParseString(string delimiter, string s)
    {
        return s.Split(delimiter, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}
