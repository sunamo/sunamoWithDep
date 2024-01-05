namespace SunamoShared.Helpers.Resource;
public class GuidHelper
{
    public static string RemoveDashes(string e)
    {
        return e.Replace(AllStrings.dash, "");
    }

    public static string AddDashes(string e)
    {
        if (e.Contains(AllStrings.dash))
        {
            return e;
        }
        e = e.Insert(8, AllStrings.dash);
        e = e.Insert(13, AllStrings.dash);
        e = e.Insert(18, AllStrings.dash);
        e = e.Insert(23, AllStrings.dash);
        return e;
    }

    public static string GuidsOnlySingleLetter()
    {
        List<string> ls = new List<string>();
        for (int i = 0; i < 10; i++)
        {
            var ts = i.ToString();
            ts = ts.PadLeft(32, ts[0]);

            ls.Add(AddDashes(ts));
        }

        for (char i = 'a'; i < 'g'; i++)
        {
            var ts = i.ToString();
            ts = ts.PadLeft(32, ts[0]);

            ls.Add(AddDashes(ts));
        }

        return SHJoin.JoinNL(ls);
    }
}
