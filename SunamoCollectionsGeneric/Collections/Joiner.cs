namespace SunamoCollectionsGeneric.Collections;

public class Joiner<T>
{
    List<T> list = null;

    string joinWith = null;
    public Joiner(int capacity = int.MinValue) : this(AllStringsSE.cs)
    {

    }


    public Joiner(string joinWith, int capacity = 5)
    {
        this.joinWith = joinWith;
        list = new List<T>(capacity);
    }
    public override string ToString()
    {
        return string.Join(joinWith, list);

    }

    public void Add(T appName)
    {
        list.Add(appName);
    }
}
