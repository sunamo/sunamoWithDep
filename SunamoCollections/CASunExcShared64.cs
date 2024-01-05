namespace SunamoCollections;
public partial class CA
{
    #region For easy copy from CAShared64.cs
    /// <summary>
    /// Direct edit
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="vr"></param>
    public static void RemoveDefaultT<T>(List<T> vr)
    {
        for (int i = vr.Count - 1; i >= 0; i--)
        {
            if (EqualityComparer<T>.Default.Equals(vr[i], default(T)))
            {
                vr.RemoveAt(i);
            }
        }
    }

    //public static int Count(IList e)
    //{
    //    return se.CA.Count(e);

    //}







    /// <summary>
    /// Direct edit
    /// Must return because is used with params string[]
    /// </summary>
    /// <param name="backslash"></param>
    /// <param name="s"></param>
    public static List<string> TrimStartChar(char backslash, List<string> s)
    {
        for (int i = 0; i < s.Count; i++)
        {
            s[i] = s[i].TrimStart(backslash);
        }
        return s;
    }


    #endregion
}
