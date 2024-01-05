namespace SunamoData.Data;

public class AsyncLoadingBase<T, ProgressBar>
{
    public Action<T> statusAfterLoad;
    public ProgressBar pb;
    public long processedCount = 0;
}
