namespace SunamoShared.Helpers;

public class CastHelper
{
    public static List<string> ToListString(object l)
    {
        var t = l.GetType();
        if (t == TypesList.tString)
        {
            return (List<string>)l;
        }
        else if (t == Types.tString)
        {
            return SHGetLines.GetLines(l.ToString());
        }
        else
        {
            ThrowEx.DoesntHaveRequiredType(nameof(l));
        }

        return null;
    }

    public static string ToString(object l)
    {
        var t = l.GetType();
        if (t == Types.tString)
        {
            return l.ToString();
        }
        else if (t == TypesList.tString)
        {
            return SHJoin.JoinNL((List<string>)l);
        }
        else
        {
            ThrowEx.DoesntHaveRequiredType(nameof(l));
        }

        return null;
    }
}
