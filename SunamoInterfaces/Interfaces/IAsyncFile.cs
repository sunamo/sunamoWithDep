namespace SunamoInterfaces.Interfaces;

public interface IAsyncFile
{
    Task<string> ReadAllTextAsync(string s);
}
