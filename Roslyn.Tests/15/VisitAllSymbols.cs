/*
 * How do I get a list of all of the types available to a compilation 
 * => SymbolVisitor
 * 
 * CSharpSyntaxWalker - to visit all code elements
 * CSharpSyntaxRewriter - used for remove empty semicolon
 * 
 * CSharpSyntaxWalker -> CSharpSyntaxVisitor
 * 
 * Unfortunately unlike the SyntaxWalker and CSharpSyntaxRewriter, when using the SymbolVisitor we must construct the scaffolding code to visit all the nodes.
 * 
 * 
 */

// To simply list all the types available to a compilation we can use the following.

public partial class RoslynLearn
{
    public class NamedTypeVisitor : SymbolVisitor
    {
        public override void VisitNamespace(INamespaceSymbol symbol)
        {
            //DebugLogger.Instance.WriteLine(symbol);

            foreach (var childSymbol in symbol.GetMembers())
            {
                //We must implement the visitor pattern ourselves and 
                //accept the child symbols in order to visit their children
                childSymbol.Accept(this);
            }
        }

        public override void VisitNamedType(INamedTypeSymbol symbol)
        {
            //DebugLogger.Instance.WriteLine(symbol);

            foreach (var childSymbol in symbol.GetTypeMembers())
            {
                //Once againt we must accept the children to visit 
                //all of their children
                childSymbol.Accept(this);
            }
        }
    }

    [Fact]
    public void _VisitAllSymbols()
    {


        //Now we need to use our visitor
        var tree = CSharpSyntaxTree.ParseText(@"
        class MyClass
        {
            class Nested
            {
            }
            void M()
            {
            }
        }");

        var mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
        var compilation = CSharpCompilation.Create("MyCompilation",
            syntaxTrees: new[] { tree }, references: new[] { mscorlib });

        var visitor = new NamedTypeVisitor();
        visitor.Visit(compilation.GlobalNamespace);

    }
}
