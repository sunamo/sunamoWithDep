namespace SunamoShared.Essential;

public static class CleanUp
{
    public static void Streams(Stream stream, FileStream fileStream)
    {
        if (stream != null)
        {
            stream.Dispose();
        }
        if (fileStream != null)
        {
            fileStream.Dispose();
        }
    }
}
