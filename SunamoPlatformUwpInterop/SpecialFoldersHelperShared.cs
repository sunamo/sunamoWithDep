namespace SunamoPlatformUwpInterop;


public partial class SpecialFoldersHelper
{
    // public static bool aspnet
    // {
    //     get
    //     {
    //         return Exc.aspnet;
    //     }
    //     set
    //     {
    //         Exc.aspnet /*= SunamoExceptions.Exc.aspnet*/ = value;
    //     }
    // }

    public static string AppDataRoaming()
    {
        string vr = null;

        //if (Exc.aspnet || VpsHelperXlf.IsVps)
        //{
        // Create junction to Administrator
        vr = @"C:\Users\Administrator\AppData\Roaming";
        //}
        //else
        //{
        //    var n = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        //    // Vracelo mi to empty string  s Environment.GetFolderPath
        //    //vr = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        //    vr = @"C:\Users\"+ FS.GetFileName(n) + @"\AppData\Roaming";
        //}

        return vr;
    }
}
