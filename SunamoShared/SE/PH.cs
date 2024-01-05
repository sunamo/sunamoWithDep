namespace SunamoShared.SE;
public partial class PH
{
    public static bool IsAlreadyRunning(string name)
    {
        IList<string> pr = Process.GetProcessesByName(name).Select(d => d.ProcessName).ToList();
        //var processes = Process.GetProcesses(name).Where(s => s.ProcessName.Contains(name)).Select(d => d.ProcessName);
        return pr.Count() > 1;
    }
}
