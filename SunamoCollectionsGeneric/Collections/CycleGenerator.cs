namespace SunamoCollectionsGeneric.Collections;

public class CycleGenerator<T>
{
    List<T> whole = new List<T>();

    public CycleGenerator(List<T> init)
    {
        whole = init;
    }

    int dx = 0;

    public T TakeAnother()
    {
        var t = whole[dx++];

        if (dx == whole.Count)
        {
            dx = 0;
        }

        return t;
    }
}
