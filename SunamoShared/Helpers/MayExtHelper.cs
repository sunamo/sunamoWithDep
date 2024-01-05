namespace SunamoShared.Helpers;

using ThisApp = ThisApp;

public class MayExtHelper
{
    /// <summary>
    /// True when is there error
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool MayExc<T>(ResultWithException<T> result)
    {
        if (result.exc != null)
        {
            ThisApp.Error( result.exc);
            return true;
        }
        return false;
    }

    /// <summary>
    /// True when is there error
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    public static bool XmlDocument(ResultWithException<XmlDocument> r)
    {
        return MayExc<XmlDocument>(r);
    }
}
