namespace SunamoShared.win;


public class DW2 : IDW
{
    public static IDW p = null;
    public static DW2 ci = new DW2();

    public string SelectOfFolder(string rootFolder)
    {
        return p.SelectOfFolder(rootFolder);
    }

    public string SelectOfFolder(Environment.SpecialFolder rootFolder)
    {
        return p.SelectOfFolder(rootFolder);
    }
}
