public partial class RoslynLearn
{
    // Analyze control flow - where code is changing directing

    [Fact]
    public void _BasicControlFlow()
    {
        var tree = CSharpSyntaxTree.ParseText(@"
            class C
            {
                void M()
                {
        
                    for (int i = 0; i < 10; i++)
                    {
                        if (i == 3)
                            continue;
                        if (i == 8)
                            break;
                    }
                }
            }
        ");

        var Mscorlib = PortableExecutableReference.CreateFromFile(typeof(object).Assembly.Location);
        var compilation = CSharpCompilation.Create("MyCompilation",
            syntaxTrees: new[] { tree }, references: new[] { Mscorlib });
        var model = compilation.GetSemanticModel(tree);

        var firstFor = tree.GetRoot().DescendantNodes().OfType<ForStatementSyntax>().Single();
        ControlFlowAnalysis result = model.AnalyzeControlFlow(firstFor.Statement);

        //DebugLogger.Instance.WriteLine(result.Succeeded);            //True
        //DebugLogger.Instance.WriteLine(result.ExitPoints.Count());    //2 - continue, and break

    }
}
