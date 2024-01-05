namespace SunamoShared.win;


/// <summary>
/// Vůbec nevím k čemu třída je
/// Takže jsem ji přejmenoval pouze na 2
/// </summary>
public class FSWin2 : IFSWin
{
    public static IFSWin p = null;
    public static FSWin2 ci = new FSWin2();

    private FSWin2()
    {

    }

    public void DeleteFileMaybeLocked(string s)
    {
        p.DeleteFileMaybeLocked(s);
    }

    public void DeleteFileOrFolderMaybeLocked(string p2)
    {
        p.DeleteFileOrFolderMaybeLocked(p2);
    }
}
