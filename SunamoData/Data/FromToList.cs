namespace SunamoData.Data;

public class FromToList
{
    public List<FromTo> c = new();

    public bool IsInRange(int i)
    {
        foreach (var item in c)
            if (i < item.to && i > item.from)
                return true;
        return false;
    }
}
