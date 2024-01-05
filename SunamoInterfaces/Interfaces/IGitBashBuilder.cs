namespace SunamoInterfaces.Interfaces;

public interface IGitBashBuilder
{
    List<string> Commands { get; }

    void Add(string v);
    /// <summary>
    /// In A1 can be git@github.com:sunamo/SunamoYouTube.git
    /// </summary>
    /// <param name="s"></param>
    void AddNewRemote(string s);
    void Checkout(string text);
    void Append(string text);
    void AppendLine();
    void AppendLine(string text);
    void Cd(string key);
    void Clean(string v);
    void Clear();
    void Clone(string repoUri, string args = Consts.se);
    void Commit(bool addAllUntrackedFiles, string commitMessage);
    void Config(string v);
    void Fetch(string s);
    void Init();
    void Merge(string v);
    void Pull();
    void Push(bool force);
    void Push(string arg);
    void Remote(string arg);
    void Status();
    string ToString();
}
