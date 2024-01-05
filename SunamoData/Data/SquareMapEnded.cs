namespace SunamoData.Data;

public class SquareMapEnded
{
    public List<bool> cub;
    public List<bool> sqb;
    public List<bool> b;

    public List<bool> ecub;
    public List<bool> esqb;
    public List<bool> eb;

    void Init(int ccub, int csqb, int cb)
    {
        cub = new List<bool>(ccub);
        sqb = new List<bool>(csqb);
        b = new List<bool>(cb);

        ecub = new List<bool>(ccub);
        esqb = new List<bool>(csqb);
        eb = new List<bool>(cb);
    }

    public SquareMapEnded(SquareMap m)
    {
        Init(m.cub.Count, m.sqb.Count, m.b.Count);

    }

    public SquareMapEnded()
    {
        Init(0, 0, 0);
    }
}
