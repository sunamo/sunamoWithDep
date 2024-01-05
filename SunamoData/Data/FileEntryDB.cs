namespace SunamoData.Data;

/// <summary>
/// Used for example in HostingManager
/// </summary>
public class FileInfoDB : FileInfoLite
{
    public int ID = -1;
    public FileInfoDB(int ID, string Directory, string FileName, long Length) : base(Directory, FileName, Length)
    {
        this.ID = ID;
    }

    /// <summary>
    /// Když chci jakoby použít pouze FileInfo, ale mít typ FileInfoDB
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="Directory"></param>
    /// <param name="FileName"></param>
    /// <param name="Length"></param>
    /// <param name="Hash"></param>
    public FileInfoDB(string Directory, string FileName, long Length)
    : base(Directory, FileName, Length)
    {
    }

    public override string ToString()
    {
        return UH.Combine(false, new string[] { Path, Name });
    }
}
