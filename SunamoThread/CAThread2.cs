namespace SunamoThread;


public partial class CAThread //: CAThreadSE
{
    public static List<string> ToListString(IList e)
    {
        // todo přidat SunExt
        List<string> ls = new List<string>(/*e.Count()*/);
        foreach (var item in e)
        {
            ls.Add(item.ToString());
        }
        return ls;
    }
}
