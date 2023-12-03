public partial class RoslynLearn
{
    [Fact]
    public async Task _1IterateOverAllProjectsInSolution()
    {
        string solutionPath = @"E:\vs\Projects\_ut2\sunamo.Tests\sunamo.Tests.sln";
        var msWorkspace = MSBuildWorkspace.Create();

        var solution = await msWorkspace.OpenSolutionAsync(solutionPath);
        // Return 0 projects, dont know why
        foreach (var project in solution.Projects)
        {
            foreach (var document in project.Documents)
            {
                //DebugLogger.Instance.WriteLine(project.Name + "\t\t\t" + document.Name);
            }
        }

    }
}
