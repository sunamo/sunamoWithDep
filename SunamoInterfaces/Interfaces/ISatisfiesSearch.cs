namespace SunamoInterfaces.Interfaces;

/// <summary>
///
/// </summary>
public interface ISatisfiesSearching
{
    /// <summary>
    /// A1 je to co se hled�. Dal�� nast. se m��e v tomto �et�zci nebo v odd. t��d�ch.
    /// </summary>
    /// <param name="s"></param>
    bool SatisfiesSearch(string s);
}
