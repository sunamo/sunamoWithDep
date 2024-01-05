namespace SunamoShared.win.Powershell;


public class PowershellBuilder : IPowershellBuilder
{
    IPowershellBuilder _p = null;
    /// <summary>
    /// musí zůstat instanční protože přes něj se volá 
    /// </summary>
    public IPowershellBuilder p
    {
        get => _p;
        set
        {
            _p = value;
            Git = value.Git; // nevím zda to tu potřebuji ale nechám
        }
    }

    public static Type typeToActivate = null;
    public static PowershellBuilder ci = new PowershellBuilder();

    /// <summary>
    /// tohle by mělo být static protože to tak potřebuji v Create
    /// </summary>
    public IGitBashBuilder Git { get; set; }
    /// <summary>
    /// NSN, protože pouze volá metody z PowershellBuilder
    /// </summary>
    public TextBuilder sb { get; set; }
    public INpmBashBuilder Npm { get; set; }

    private PowershellBuilder()
    {
        //Git = new GitBashBuilder();
    }

    public static IPowershellBuilder Create()
    {
        var result = (IPowershellBuilder)Activator.CreateInstance(typeToActivate);
        result.Git = new GitBashBuilder(result.sb);
        result.Npm = new NpmBashBuilder(result.sb);
        return result;
    }

    public void AddArg(string argName, string argValue)
    {
        p.AddArg(argName, argValue);
    }

    public void AddRaw(string v)
    {
        p.AddRaw(v);
    }

    public void AddRawLine(string v = Consts.se)
    {
        p.AddRawLine(v);
    }

    /// <summary>
    /// byl string ale proč by to měl být string?
    /// </summary>
    /// <param name="path"></param>
    public void Cd(string path)
    {
        p.Cd(path);
    }

    public void Clear()
    {
        p.Clear();
    }

    public void CmdC(string v)
    {
        p.CmdC(v);
    }

    public void RemoveItem(string v)
    {
        p.RemoveItem(v);
    }

    public List<string> ToList()
    {
        return p.ToList();
    }

    public override string ToString()
    {
        return p.ToString();
    }

    public void WithPath(CommandWithPath c, string path)
    {
        AddRawLine(c.ToString() + " '" + path + "'");

    }

    public void YtDlp(string url)
    {
        p.YtDlp(url);
    }
}
