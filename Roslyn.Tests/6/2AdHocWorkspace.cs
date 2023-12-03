public partial class RoslynLearn
{
    [Fact]
    public void _2AdHocWorkspace()
    {
        // api for add and remove files is different within AdhocWorkspace  and other
        var workspace = new AdhocWorkspace();

        string projName = "NewProject";
        // Create new project - 
        ProjectId projectId = null;
        // CreateNewId() should be in https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.projectid.createnewid?view=roslyn-dotnet
        projectId = Microsoft.CodeAnalysis.ProjectId.CreateNewId();

        var versionStamp = VersionStamp.Create();
        var projectInfo = ProjectInfo.Create(projectId, versionStamp, projName, projName, LanguageNames.CSharp);

        // add into project
        var newProject = workspace.AddProject(projectInfo);

        var sourceText = SourceText.From("class A {}");
        var newDocument = workspace.AddDocument(newProject.Id, "NewFile.cs", sourceText);

        foreach (var project in workspace.CurrentSolution.Projects)
        {
            foreach (var document in project.Documents)
            {
                //DebugLogger.Instance.WriteLine(project.Name + "\t\t\t" + document.Name);
            }
        }

    }
}
