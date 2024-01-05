namespace SunamoShared.Essential;
public partial class VpsHelperSunamo
{
    #region For easy copy
    public static bool IsQ
    => Environment.MachineName == Consts.qMachineName;
    #endregion

    public const string ip = "46.36.38.72";
    public const string ipMyPoda = "85.135.38.18";

    public static bool IsVps => VpsHelperXlf.IsVps;
    public static string path => VpsHelperXlf.path;

    #region For easy copy
    /*
Zkopíroval jsem z C:\repos\_\Projects\sunamo.webWithoutDep\SunamoExceptions.web\_\Essential\VpsHelperSunamo.cs
    nevím zda je to správný postup - NENÍ, pak je tu duplikátní s C:\repos\_\Projects\sunamo\sunamo\Essential\VpsHelperSunExcSunamo.cs
     */
    //public static bool IsQ
    //=> Environment.MachineName == Consts.qMachineName;
    #endregion

    public static string LocationOfSqlBackup(string s)
    {
        var p = string.Empty;
        //p = @"C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\";
        p = @"C:\mssqllserver\";

        var r = p += @"Backup\" + s + ".bak";
        return r;
    }

    public static string SunamoSln()
    {
        if (IsVps)
        {
            return @"C:\_\sunamo\";
        }
        else
        {
            return BasePathsHelper.vs + @"sunamo\";
        }
    }

    public static string SunamoCzSln()
    {
        if (IsVps)
        {
            return @"C:\_\sunamo.cz\";
        }
        else
        {
            return BasePathsHelper.vs + @"sunamo.cz\";
        }
    }

    public static string SunamoProject()
    {
        return Path.Combine(SunamoSln(), "sunamo");
    }


}
