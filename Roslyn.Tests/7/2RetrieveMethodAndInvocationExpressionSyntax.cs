public partial class RoslynLearn
{
    [Fact]
    public void _2RetrieveMethodAndInvocationExpressionSyntax()
    {
        var tree = CSharpSyntaxTree.ParseText(@"
        	public class MyClass {
        			 int Method1() { return 0; }
        			 void Method2()
        			 {
        				int x = Method1();
        			 }
        		}
        	}");

        var Mscorlib = PortableExecutableReference.CreateFromFile(typeof(object).Assembly.Location);
        var compilation = CSharpCompilation.Create("MyCompilation",
            syntaxTrees: new[] { tree }, references: new[] { Mscorlib });
        var model = compilation.GetSemanticModel(tree);

        //Looking at the first method symbol
        var methodSyntax = tree.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>().First();
        var methodSymbol = model.GetDeclaredSymbol(methodSyntax);

        //DebugLogger.Instance.WriteLine(methodSymbol.ToString());         //MyClass.Method1()
        //DebugLogger.Instance.WriteLine(methodSymbol.ContainingSymbol);   //MyClass
        //DebugLogger.Instance.WriteLine(methodSymbol.IsAbstract);         //false

        //Looking at the first invocation
        var invocationSyntax = tree.GetRoot().DescendantNodes().OfType<InvocationExpressionSyntax>().First();
        var invokedSymbol = model.GetSymbolInfo(invocationSyntax).Symbol; //Same as MyClass.Method1

        //DebugLogger.Instance.WriteLine(invokedSymbol.ToString());         //MyClass.Method1()
        //DebugLogger.Instance.WriteLine(invokedSymbol.ContainingSymbol);   //MyClass
        //DebugLogger.Instance.WriteLine(invokedSymbol.IsAbstract);         //false

        //DebugLogger.Instance.WriteLine(invokedSymbol.Equals(methodSymbol)); //true

    }
}
