public partial class RoslynLearn
{
    [Fact]
    public void _EntryAndExitPoints()
    {
        var tree = CSharpSyntaxTree.ParseText(@"
        class C
        {
            void M(int x)
            {
                L1: ; // 1
                if (x == 0) goto L1;    //firstIf
                if (x == 1) goto L2;
                if (x == 3) goto L3;
                L3: ;                   //label3
                L2: ; // 2
                if(x == 4) goto L3;
            }
        }
        ");

        var Mscorlib = PortableExecutableReference.CreateFromFile(typeof(object).Assembly.Location);
        var compilation = CSharpCompilation.Create("MyCompilation",
        syntaxTrees: new[] { tree }, references: new[] { Mscorlib });
        var model = compilation.GetSemanticModel(tree);

        //Choose first and last statements
        var firstIf = tree.GetRoot().DescendantNodes().OfType<IfStatementSyntax>().First();
        var label3 = tree.GetRoot().DescendantNodes().OfType<LabeledStatementSyntax>().Skip(1).Take(1).Single();

        ControlFlowAnalysis result = model.AnalyzeControlFlow(firstIf, label3);
        //DebugLogger.Instance.WriteLine(result.EntryPoints);      //1 - L3: ; //Label 3 is a candidate entry point within these statements
        //DebugLogger.Instance.WriteLine(result.ExitPoints);       //2 - goto L1;,goto L2; //goto L1 and goto L2 and candidate exit points

    }
}
