namespace SunamoInterfaces.Interfaces;

public interface IParseCollection
{
    /// <summary>
    /// Pro opacny proces slouzi M ToString().
    /// A1 must be list due to parse by indexes
    /// </summary>
    void ParseCollection(List<string> s);
}

public interface IParseCollectionIndexes
{
    /// <summary>
    /// Pro opacny proces slouzi M ToString().
    /// A1 must be list due to parse by indexes
    /// </summary>
    void ParseCollection(List<string> s, params int[] dx);
}

public interface IParser
{
    void Parse(string co);
}
