namespace SunamoExceptions.InSunamoIsDerivedFrom;

public partial class TFSE
{
    public static string ReadAllTextSync(string path)
    {
        return ReadAllTextSync(path, false);
    }

    public static string ReadAllTextSync(string path, bool createEmptyIfWasNotExists = false)
    {
        if (createEmptyIfWasNotExists)
            if (!File.Exists(path))
            {
                WriteAllTextSync(path, string.Empty);
                return string.Empty;
            }

        return File.ReadAllText(path);
    }

    public static void WriteAllTextSync(string path, string content)
    {
        File.WriteAllText(path, content);
    }

    public static void AppendAllTextSync(string path, string content)
    {
        File.AppendAllText(path, content);
    }

    public static List<string> ReadAllLinesSync(string path)
    {
        return ReadAllLinesSync(path, false);
    }

    public static List<string> ReadAllLinesSync(string path, bool createEmptyIfWasNotExists = false)
    {
        if (createEmptyIfWasNotExists)
            if (!File.Exists(path))
            {
                WriteAllTextSync(path, string.Empty);
                return new List<string>();
            }

        return File.ReadAllLines(path).ToList();
    }

    public static void WriteAllLinesSync(string path, List<string> content)
    {
        File.WriteAllLines(path, content.ToArray());
    }

    public static void AppendAllLinesSync(string path, List<string> content)
    {
        File.AppendAllLines(path, content.ToArray());
    }

    public static List<byte> ReadAllBytesSync(string path)
    {
        return File.ReadAllBytes(path).ToList();
    }

    public static void WriteAllBytesSync(string path, List<byte> content)
    {
        File.WriteAllBytes(path, content.ToArray());
    }
}
