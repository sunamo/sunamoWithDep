namespace SunamoShared.win.Powershell;


public class PowershellRunner : IPowershellRunner
{
    /// <summary>
    /// Je pouze ve Shared, nikoliv ve SunamoPS
    /// Vůbec nevím proč to tu je, kromě standardizace se std. Powershell* třídami co jde potom vidět ve PS.cs
    /// U Runneru by nemělo vadit ci, protože tu nehrozí kolize vláken, jako u Builder
    /// 
    /// </summary>
    public static IPowershellRunner p = null;
    public static PowershellRunner ci = new PowershellRunner();

    public Dictionary<string, List<string>> UsedCommandsInFolders
    {
        get => p.UsedCommandsInFolders;
        set => p.UsedCommandsInFolders = value;
    }

    //bool saveUsedCommandToDictionary = false;
    public bool SaveUsedCommandToDictionary
    {
        get { return p.SaveUsedCommandToDictionary; }
        set
        {
#if DEBUG
            if (value)
            {

            }
#endif


            p.SaveUsedCommandToDictionary = value;
        }
    }

    private PowershellRunner()
    {

    }

    public ProgressState clpb { get; set; }

    /// <summary>
    /// 
    /// !!! Pokud je první cmd "cd ", nebude se výstup pro něj vracet v outputu - cd se totiž přidává před každý příkaz, takže by mi indexy bobtnalo
    /// 
    /// 
    /// Won't return output for cd
    /// </summary>
    /// <param name="folder"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    public async Task<List<string>> InvokeInFolder(string folder, string command)
    {
        List<string> commands = new List<string>();
        commands.Add("cd " + folder);
        commands.Add(command);

        return (await Invoke(commands))[1];
    }

    /// <summary>
    /// !!! Pokud je první cmd "cd ", nebude se výstup pro něj vracet v outputu - cd se totiž přidává před každý příkaz, takže by mi indexy bobtnalo
    /// 
    /// Invoke - more commands, just run InvokeWorker
    /// InvokeLinesFromString - more commands, with progress bar. Simply call InvokeWorker
    /// InvokeProcess - spustí proces ze kterého vrátí output
    /// InvokeSingle - just run InvokeWorker
    /// </summary>
    /// <param name="commands"></param>
    /// <returns></returns>
    public
#if ASYNC
    async Task<List<List<string>>>
#else
      List<List<string>>
#endif
 Invoke(List<string> commands)
    {
        return
#if ASYNC
    await
#endif
 p.Invoke(commands);
    }

    /// <summary>
    /// !!! Pokud je první cmd "cd ", nebude se výstup pro něj vracet v outputu - cd se totiž přidává před každý příkaz, takže by mi indexy bobtnalo
    /// 
    /// Explanation is in IPowershellRunner
    /// </summary>
    public
#if ASYNC
        async Task<List<List<string>>>
#else
      List<List<string>>
#endif
 Invoke(List<string> commands, PsInvokeArgs e)
    {
        return
#if ASYNC
        await
#endif
 p.Invoke(commands, e);
    }

    /// <summary>
    /// !!! Pokud je první cmd "cd ", nebude se výstup pro něj vracet v outputu - cd se totiž přidává před každý příkaz, takže by mi indexy bobtnalo
    /// 
    /// Explanation is in IPowershellRunner
    /// </summary>
    /// <param name="commands"></param>
    /// <returns></returns>
    public
#if ASYNC
    async Task<List<string>>
#else
    List<string>
#endif
 InvokeSingle(string commands)
    {
        return
#if ASYNC
    await
#endif
 p.InvokeSingle(commands);
    }


    /// <summary>
    /// !!! Pokud je první cmd "cd ", nebude se výstup pro něj vracet v outputu - cd se totiž přidává před každý příkaz, takže by mi indexy bobtnalo
    /// 
    /// Explanation is in IPowershellRunner
    /// </summary>
    public
#if ASYNC
    async Task<string>
#else
    string
#endif
 InvokeLinesFromString(string v, bool writePb)
    {
        return
#if ASYNC
    await
#endif
 p.InvokeLinesFromString(v, writePb);
    }

    /// <summary>
    /// !!! Pokud je první cmd "cd ", nebude se výstup pro něj vracet v outputu - cd se totiž přidává před každý příkaz, takže by mi indexy bobtnalo
    /// 
    /// Explanation is in IPowershellRunner
    /// </summary>
    public
#if ASYNC
    async Task<List<string>>
#else
    List<string>
#endif
 InvokeProcess(string exeFileNameWithoutPath, string arguments, InvokeProcessArgs a = null)
    {
        return
#if ASYNC
    await
#endif
 p.InvokeProcess(exeFileNameWithoutPath, arguments, a);
    }


}
