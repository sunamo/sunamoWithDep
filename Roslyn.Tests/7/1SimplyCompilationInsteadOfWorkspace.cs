// Create semantic model for c# code included here
public partial class RoslynLearn
{
    [Fact]
    public void _1SimplyCompilationInsteadOfWorkspace()
    {
        var tree = CSharpSyntaxTree.ParseText(@"
        	public class MyClass 
        	{
        		int MyMethod() { return 0; }
        	}");

        var Mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
        var compilation = CSharpCompilation.Create("MyCompilation",
            syntaxTrees: new[] { tree }, references: new[] { Mscorlib });
        //Note that we must specify the tree for which we want the model.
        //Each tree has its own semantic model
        var model = compilation.GetSemanticModel(tree);

    }
}
