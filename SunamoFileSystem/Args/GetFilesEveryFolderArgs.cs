namespace SunamoFileSystem.Args;

public class GetFilesEveryFolderArgs : GetFilesBaseArgs
{
    public bool usePbTime = false;
    public Action<double> InsertPbTime = null;
    public Action<string> UpdateTbPb = null;

    public bool usePb = false;
    public Action<double> InsertPb = null;

    public Action DoneOnePercent;
    public Action Done;
    // return false if no to indexed. otherwise true
    public Func<string, bool> FilterFoundedFiles;
    public Func<string, bool> FilterFoundedFolders;

    public int getNullIfThereIsMoreThanXFiles = -1;
}
