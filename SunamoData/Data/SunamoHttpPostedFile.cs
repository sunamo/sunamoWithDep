namespace SunamoData.Data;

public class SunamoHttpPostedFile
{
    public SunamoHttpPostedFile()
    {
    }

    public SunamoHttpPostedFile(long ContentLength, string ContentType, string FileName, Stream InputStream)
    {
        this.ContentLength = ContentLength;
        this.ContentType = ContentType;

        MemoryStream ms = new MemoryStream();
        FS.CopyStream(InputStream, ms);

        Bytes = ms.ToArray().ToList();
        this.FileName = FileName;
    }

    public SunamoHttpPostedFile(long ContentLength, string ContentType, string FileName, List<byte> InputStream)
    {
        this.ContentLength = ContentLength;
        this.ContentType = ContentType;
        Bytes = InputStream;
        this.FileName = FileName;
    }

    public long ContentLength { get; set; }
    public string ContentType { get; set; }
    //public Stream InputStream { get; set; }
    public List<byte> Bytes { get; set; }

    public string FileName
    {
        get; set;
    }

    public async Task SaveAs(string filename)
    {
        //FS.SaveStream(filename, InputStream);
        await File.WriteAllBytesAsync(filename, Bytes.ToArray());
    }
}
