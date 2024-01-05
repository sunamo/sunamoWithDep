namespace SunamoShared.Helpers.Number;
public class LowHighHelper
{
    int low = int.MaxValue;
    int max = int.MinValue;

    public void Set(int t)
    {
        if (t < low)
        {
            low = t;
        }

        if (t > max)
        {
            max = t;
        }
    }

#if DEBUG2
    public void PrintDebug()
    {
        DebugLogger.Instance.WriteLine("Low: ", low);
        DebugLogger.Instance.WriteLine("High: ", max);
    }
#endif
}
