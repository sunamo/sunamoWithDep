namespace SunamoShared.win.Powershell;


public class PowershellHelper : IPowershellHelper
{
    public static IPowershellHelper p = null;
    public static PowershellHelper ci = new PowershellHelper();

    private PowershellHelper()
    {

    }

    /// <summary>
    /// Musí být string protože je ve třídě PowershellHelper. 
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public
#if ASYNC
    async Task
#else
    void  
#endif
 CmdC(string v)
    {

#if ASYNC
        await
#endif
     p.CmdC(v);
    }

    public
#if ASYNC
    async Task<string>
#else
    string  
#endif
 DetectLanguageForFileGithubLinguist(string windowsPath)
    {
        return
#if ASYNC
    await
#endif
 p.DetectLanguageForFileGithubLinguist(windowsPath);
    }

    public List<string> ProcessNames()
    {
        return p.ProcessNames();
    }
}
