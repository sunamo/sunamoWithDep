namespace SunamoThread;


public partial class CAThread
{
    #region ToList to avoid StackOverflowException

    public static List<object> ToList(IList e)
    {
        // todo přidat SunExt
        List<object> ls = new List<object>(/*e.Count()*/);

        foreach (object item in e)
        {
            ls.Add(item);
        }

        return ls;
    }

    #endregion
}
