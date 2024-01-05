namespace SunamoData.Data;

public class PhotoToUpload
{
    public string path { get; set; }
    public string pathSanitized { get; set; }
    //public int size { get; set; }
    public DateTime DateTaken { get; set; }
    //public string idPhoto { get; set; }
    public int originalSize { get; set; }

    // bytes is already sending in SunamoHttpPostedFile
    //public List<byte> bytes { get; set; }
}
