// Test whether point in code is reachable

public partial class RoslynLearn
{
    [Fact]
    public void _UnreachableCode()
    {
        var tree = CSharpSyntaxTree.ParseText(@"
            class C
            {
                void M(int x)
                {
                    return;
                    if(x == 0)                                  //-+     Start is unreachable
                        System.//DebugLogger.Instance.WriteLine(""Hello"");    // |
                    L1:                                            //-+    End is unreachable
                }
            }
        ");

        var Mscorlib = PortableExecutableReference.CreateFromFile(typeof(object).Assembly.Location);
        var compilation = CSharpCompilation.Create("MyCompilation",
            syntaxTrees: new[] { tree }, references: new[] { Mscorlib });
        var model = compilation.GetSemanticModel(tree);

        //Choose first and last statements
        var firstIf = tree.GetRoot().DescendantNodes().OfType<IfStatementSyntax>().Single();
        // Sequence contains no elements'
        //var label1 = tree.GetRoot().DescendantNodes().OfType<LabeledStatementSyntax>().Single();

        //ControlFlowAnalysis result = model.AnalyzeControlFlow(firstIf, label1);

        //DebugLogger.Instance.WriteLine(result.StartPointIsReachable);    //False
        //DebugLogger.Instance.WriteLine(result.EndPointIsReachable);      //False

    }
}
