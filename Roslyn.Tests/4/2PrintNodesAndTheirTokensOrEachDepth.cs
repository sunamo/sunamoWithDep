/*
	CompilationUnit
		ClassDeclaration
			MethodDeclaration
				PredefinedType
				ParameterList
				Block
			MethodDeclaration
				PredefinedType
				ParameterList
					Parameter
						PredefinedType
				Block
 */

/// Return methods which contains at least one parameter
public partial class RoslynLearn
{
    // More deep - visit also all tokens, not only all nodes
    public class DeeperWalker : CSharpSyntaxWalker
    {
        static int Tabs = 0;
        //NOTE: Make sure you invoke the base constructor with 
        //the correct SyntaxWalkerDepth. Otherwise VisitToken()
        //will never get run.
        public DeeperWalker() : base(SyntaxWalkerDepth.Token)
        {
        }
        public override void Visit(SyntaxNode node)
        {
            Tabs++;
            var indents = new String('\t', Tabs);
            //DebugLogger.Instance.WriteLine(indents + node.Kind());
            base.Visit(node);
            Tabs--;
        }

        public override void VisitToken(SyntaxToken token)
        {
            var indents = new String('\t', Tabs);
            //DebugLogger.Instance.WriteLine(indents + token);
            base.VisitToken(token);
        }
    }

    [Fact]
    public void _2PrintNodesAndTheirTokensOrEachDepth()
    {
        var tree = CSharpSyntaxTree.ParseText(@"
                public class MyClass
                {
                    public void MyMethod()
                    {
                    }
                    public void MyMethod(int n)
                    {
                    }
               ");

        var walker = new DeeperWalker();
        walker.Visit(tree.GetRoot());
    }
}
