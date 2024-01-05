namespace SunamoData.Data;

public class FolderEntry
{
    public string RelativePath = null;

    /// <summary>
    /// A1 je skutečně relativní plná cesta, abych snadno mohl získat pouze získáním naduzlu a rootu celou cestu
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="DirectoryName"></param>
    public FolderEntry(string RelativePath)
    {
        this.RelativePath = RelativePath;
    }
}
