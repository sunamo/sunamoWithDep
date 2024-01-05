namespace SunamoInterfaces.Interfaces;

public interface IParser<T>
{
    T Parse(string co);
}

public interface IParserCollection<T>
{
    List<T> ParseCollection(string co);
}
