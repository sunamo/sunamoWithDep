namespace SunamoData.Data;

public class FileInfoSerie : FileInfoLite
{
    public bool IsDeleted = false;
    public string NameWithoutSeries = null;
    //public string NameWithoutSeriesLower = null;
    public string PathWithoutSerie = null;
    public bool HasSerie = false;
    /// <summary>
    /// Pouze název souboru s příponou bez cesty, za to modifikovaný
    /// </summary>
    public string FileNameComplet = null;
    public bool NeverRemove = false;

    public static FileInfoSerie GetFIS(string file)
    {
        FileInfo item2 = new FileInfo(file);
        return GetFIS(item2);
    }

    public static FileInfoSerie GetFIS(FileInfo item2)
    {
        FileInfoSerie fil = new FileInfoSerie();
        fil.Name = item2.Name;
        fil.Path = item2.FullName;
        fil.Size = item2.Length;
        bool hasSerie = false;
        fil.NameWithoutSeries = FS.GetNameWithoutSeries(fil.Name, false, out hasSerie, SerieStyle.Brackets);
        fil.PathWithoutSerie = FS.GetNameWithoutSeries(fil.Name, true, out hasSerie, SerieStyle.Brackets);
        fil.HasSerie = hasSerie;
        fil.FileNameComplet = FS.GetFileName(item2.FullName);
        return fil;
    }
}
