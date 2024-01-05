namespace SunamoShared.Helpers;



public partial class PH
{
    public static bool ExistsOnPath(string fileName)
    {
        return GetFullPath(fileName) != null;
    }

    public static string GetFullPath(string fileName)
    {
        if (File.Exists(fileName))
            return Path.GetFullPath(fileName);

        var values = Environment.GetEnvironmentVariable("PATH");
        foreach (var path in values.Split(Path.PathSeparator))
        {
            var fullPath = Path.Combine(path, fileName);
            if (File.Exists(fullPath))
                return fullPath;
        }
        return null;
    }


    public static List<string> ProcessesWithNameContains(string name)
    {
        List<string> processes = PH.GetProcessesNames(true);
        var s = CA.ReturnWhichContains(processes, name.ToLower());
        return s;
    }

    public static int TerminateProcessesWithNameContains(string name)
    {
        var s = ProcessesWithNameContains(name);

        int ended = 0;
        foreach (var item in s)
        {
            ended += PH.Terminate(item);
        }
        return ended;
    }

    /// <summary>
    /// without extensions and all lower
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static int TerminateProcessesWithName(string name)
    {
        name = name.ToLower();
        name = FS.GetFileNameWithoutExtensions(name);
        List<string> processes = PH.GetProcessesNames(true);

        int ended = 0;

        if (processes.Contains(name))
        {
            ended += PH.Terminate(name);
        }


        return ended;
    }

    #region
    /// <summary>
    /// Alternative is FileUtil.WhoIsLocking
    /// </summary>
    /// <param name="fileName"></param>
    public static void ShutdownProcessWhichOccupyFileHandleExe(string fileName)
    {
        var pr2 = FindProcessesWhichOccupyFileHandleExe(fileName);
        foreach (var pr in pr2)
        {
            KillProcess(pr);
        }
    }
    #endregion

    /// <summary>
    /// Alternative is FileUtil.WhoIsLocking
    /// A2 must be even is not used
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static List<Process> FindProcessesWhichOccupyFileHandleExe(string fileName, bool throwEx = true)
    {
        List<Process> pr2 = new List<Process>();

        Process tool = new Process();
        tool.StartInfo.FileName = "handle64.exe";
        tool.StartInfo.Arguments = fileName + " /accepteula";
        tool.StartInfo.UseShellExecute = false;
        tool.StartInfo.RedirectStandardOutput = true;
        tool.StartInfo.WorkingDirectory = @"";

        try
        {
            tool.Start();
        }
        catch (Win32Exception ex)
        {
            if (ex.Message == sess.i18n(XlfKeys.TheSystemCannotFindTheFileSpecified))
            {
                // probably file is hold by other process
                // like C:\inetpub\logs\logfiles\W3SVC1\u_ex200307.log
            }
        }

        tool.WaitForExit();
        string outputTool = null;

        try
        {
            outputTool = tool.StandardOutput.ReadToEnd();
        }
        catch (Exception ex)
        {

            if (ex.Message.Contains(sess.i18n(XlfKeys.NoProcessIsAssociatedWithThisObject) + "."))
            {
                ThisApp.Warning( sess.i18n(XlfKeys.PleaseAddHandle64ExeToPATH));
                return pr2;
            }
        }

        string matchPattern = @"(?<=\s+piD:\s+)\b(\d+)\b(?=\s+)";
        var matches = Regex.Matches(outputTool, matchPattern);
        foreach (Match match in matches)
        {
            var pr = Process.GetProcessById(int.Parse(match.Value));
            pr2.Add(pr);
        }

        return pr2;
    }




    public static void StartAllUri(List<string> all)
    {
        foreach (var item in all)
        {
            Uri(UH.AppendHttpIfNotExists(item));
        }
    }

    public static List<string> GetProcessesNames(bool lower)
    {
        var p = Process.GetProcesses().Select(d => d.ProcessName).ToList();
        if (lower)
        {
            CA.ToLower(p);
        }

        return p;
    }

    /// <summary>
    /// For search one term in all uris use UriWebServices.SearchInAll
    /// </summary>
    /// <param name = "carModels"></param>
    /// <param name = "v"></param>
    public static void StartAllUri(List<string> carModels, string v)
    {
        for (int i = 0; i < carModels.Count; i++)
        {
            if (i % 10 == 0 && i != 0)
            {
                //Debugger.Break();
            }
            Uri(UH.AppendHttpIfNotExists(UriWebServices.FromChromeReplacement(v, carModels[i])));
        }
    }

    public static void StartAllUri(List<string> carModels, Func<string, string> spritMonitor)
    {
        carModels = CAChangeContent.ChangeContent0(null, carModels, spritMonitor);
        carModels = CAChangeContent.ChangeContent0(null, carModels, NormalizeUri);
        StartAllUri(carModels);
    }





    /// <summary>
    /// Start all uri in clipboard, splitted by whitespace
    /// </summary>
    public static void StartAllUri()
    {
        var text = ClipboardHelper.GetText();
        var uris = SHSplit.SplitByWhiteSpaces(text);
        StartAllUri(uris);
    }
}
