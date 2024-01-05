namespace SunamoShared.Generators.Uri;


public partial class UriWebServices
{
    /// <summary>
    /// alphabetically
    /// </summary>
    static readonly List<string> githubRepos = SHGetLines.GetLines(@"GridControlsInWpf_Blog
MyCodeExample
sugo
sunamo
sunamo5
SunamoCssGenerator
SunamoEditorConfig
SunamoLaTeX
SunamoMathpix
SunamoRobotsTxt
SunamoRuleset
sunamoWithoutDep
sunamoWithoutDep5
sunamoWithoutDep.Tests
sunamo.github.io
sunamo.notmine
sunamo.notmine5
sunamo.notmine.Tests
sunamo.performance
sunamo.Tests
sunamo.unsafe
sunamo.unsafe.Tests
sunpm
TranslateEngine");

    public const string githubCom = "https://github.com/";

    public static bool IsGithubRepo(string fn)
    {
        return githubRepos.Contains(fn);
    }

    public static string GitClone(string slnName)
    {
        return githubCom + "sunamo/" + slnName + ".git";
    }

    public static string AzureRepoWebUIFullOrGithub(string fn, AzureBuildUriArgs a = null)
    {
        if (IsGithubRepo(fn))
        {
            return UriWebServices.GitClone(fn);
        }
        return UriWebServices.AzureRepoWebUIFull(fn, a);
    }

    public partial class Facebook
    {
        public static string FacebookProfile(string nick)
        {
            return "https://www.facebook.com/" + nick;
        }
    }
}
