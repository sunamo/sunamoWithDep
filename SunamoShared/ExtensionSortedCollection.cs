namespace SunamoShared;

/// <summary>
/// In values contains without extension
/// if file has no exception, will be grouped under empty string
/// All strings converts to lowercase
/// </summary>
public class ExtensionSortedCollection
{
    public Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

    /// <summary>
    /// Entries in A1 must be only filenames without paths
    /// </summary>
    /// <param name="d"></param>
    public ExtensionSortedCollection(params string[] d)
    {
        d.ToList().ForEach(fileName => AddOnlyFileName(fileName));
    }

    public void AddOnlyFileName(string fileName)
    {
        string ext = Path.GetExtension(fileName).ToLower();
        string fn = Path.GetFileNameWithoutExtension(fileName).ToLower();
        DictionaryHelper.AddOrCreateIfDontExists(dictionary, ext, fn);
    }

    public void AddWholeFilePath(string filePath)
    {
        AddOnlyFileName(FS.GetFileName(filePath));
    }
}
