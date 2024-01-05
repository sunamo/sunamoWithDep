namespace SunamoInterfaces.Interfaces;

public interface IParseCollectionO
{
    /// <summary>
    /// Pro opacny proces slouzi M ToString().
    /// </summary>
    void ParseCollection(IList<object> soubory);
}

public interface IParserO
{
    void Parse(object co);
}
