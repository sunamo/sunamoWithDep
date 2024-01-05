namespace SunamoInterfaces.Interfaces;

public interface IParseCollection<T>
{
    /// <summary>
    /// Pro opacny proces slouzi M ToString().
    /// </summary>
    void ParseCollection(IList<T> soubory);
}

public interface IParserT<T>
{
    void Parse(T co);
}
