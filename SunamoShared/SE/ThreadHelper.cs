namespace SunamoShared.SE;
public class ThreadHelper
{
    #region

    /// <summary>
    ///     Usage CA.Count - Extensions* use IList which dont have Count
    /// </summary>
    /// <param name="tName"></param>
    /// <returns></returns>
    public static bool NeedDispatcher(string tName)
    {
#if DEBUG
        //DebugLogger.DebugWriteLine(tName);
#endif

        return tName == "UIElementCollection";
    }

    /// <summary>
    /// bylo tu Thread.Sleep, ale v asyncu to havarovalo bez důvodu. ThreadHelper.Sleep to samé, ačkoliv používá Task.Delay
    /// Proto to zatím nebudu nahrazovat globálně protože to vypadá že tím to nebylo
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public static
#if ASYNC
    async Task
#else
    void  
#endif
 Sleep(int v)
    {
#if ASYNC
        await Task.Delay(v);
#else
Thread.Sleep(v);
#endif





    }

    #endregion
}
