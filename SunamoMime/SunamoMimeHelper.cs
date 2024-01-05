namespace SunamoMime;

public class SunamoMimeHelper
{
    private static readonly Dictionary<string, List<byte>> my4 = new();

    public static void Init()
    {
        my4.Add("webp", new List<byte>(new byte[] { 82, 73, 70, 70 }));
    }

    public static string FileType(byte[] b)
    {
        var f4 = b.Take(4);
        foreach (var item in my4)
            if (f4.SequenceEqual(item.Value))
                return item.Key;

        FileFormatInspector inspector = new();
        MemoryStream stream = new(b);
        var format = inspector.DetermineFileFormat(stream);
        return format.Extension;
    }
}
