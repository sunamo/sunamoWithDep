namespace SunamoFubuCsProjFile._NotMine.Templating.Graph;

public class ProjectTemplate : DescribesItself
{
    private static Type type = typeof(ProjectTemplate);

    public IList<string> Alterations = new List<string>();
    public string Description;
    public string Name;

    public IList<Option> Options;
    public IList<OptionSelection> Selections;


    // If this is null, it's not a "new" project
    public string Template;
    public string Url;

    public ProjectTemplate()
    {
        Options = new List<Option>();
        Selections = new List<OptionSelection>();
    }

    public string DotNetVersion { get; set; }

    public void Describe(Description description)
    {
        description.Title = Name;
        description.ShortDescription = Description;
        if (Url.IsNotEmpty()) description.Properties["Url"] = Url;

        if (Selections != null && Selections.Any()) description.AddList("Selections", Selections);

        if (Options != null && Options.Any()) description.AddList("Options", Options);
    }

    public Option FindOption(string optionName)
    {
        return Options.FirstOrDefault(x => x.Name.EqualsIgnoreCase(optionName));
    }


    public ProjectRequest BuildProjectRequest(TemplateChoices choices)
    {
        var request = new ProjectRequest(choices.ProjectName, Template);
        request.Alterations.AddRange(Alterations);

        if (DotNetVersion.IsNotEmpty()) request.Version = DotNetVersion;

        if (choices.Options != null)
            choices.Options.Each(o =>
            {
                var opt = FindOption(o);
                if (opt == null)
                {
                    if (!tryResolveSelection(o, choices))
                        if (opt == null)
                            ThrowEx.Custom("Unknown option '{0}' for project type {1}".ToFormat(o, Name));
                }
                else
                {
                    request.Alterations.AddRange(opt.Alterations);
                }
            });

        if (Selections != null) Selections.Each(selection => selection.Configure(choices, request));

        choices.Inputs.Each((key, value) => request.Substitutions.Set(key, value));


        return request;
    }

    // Query/Command separation violation, but hey, it works
    private bool tryResolveSelection(string optionName, TemplateChoices choices)
    {
        var selection = (Selections ?? new OptionSelection[0])
            .FirstOrDefault(x => x.FindOption(optionName) != null);

        if (selection == null) return false;

        choices.Selections[selection.Name] = optionName;

        return true;
    }
}
