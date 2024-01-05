namespace SunamoData.Data;

public class FoundedCodeElement : IComparable<FoundedCodeElement>
{
    public FoundedCodeElement(int line, int from, int length)
    {
        Lenght = length;
        Line = line;
        From = from;
    }

    public int Line;
    /// <summary>
    /// Is -1 if location isnt known (search in content and so)
    /// </summary>
    public int From;
    public int Lenght;

    public int CompareTo(FoundedCodeElement other)
    {
        return 0;
        // todo zakomentováno než budu mít vyřešenou hiarchii v nugetech
        //return SunamoComparer.Integer.Instance.Asc(Line, other.Line);
    }
}
