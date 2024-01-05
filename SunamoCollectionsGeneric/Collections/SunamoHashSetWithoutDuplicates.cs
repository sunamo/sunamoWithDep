namespace SunamoCollectionsGeneric.Collections;

public class SunamoHashSetWithoutDuplicates<T>
{
    public HashSet<T> c = null;

    public SunamoHashSetWithoutDuplicates()
    {
        c = new HashSet<T>();
    }

    public SunamoHashSetWithoutDuplicates(int duplCount)
    {
        // Cant create with duplCount coz is not in .NET standard
        c = new HashSet<T>();
    }

    public List<T> AddRange(IList<T> e, ProgressState clpb)
    {
        List<T> d = new List<T>();
        foreach (var item in e)
        {
            if (clpb.isRegistered)
            {
                clpb.OnAnotherSong();
            }

            if (!c.Contains(item))
            {
                c.Add(item);
            }
            else
            {
                d.Add(item);
            }
        }
        return d;
    }
}
