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

public partial class RoslynLearn
{

    /// <summary>
    /// Vypíše hierchicky strukturu 
    /// 
    /// </summary>
    public class CustomWalker : CSharpSyntaxWalker
    {
        static int Tabs = 0;
        /// <summary>
        /// Not VisitClassDeclaration, so method visit all nodes
        /// </summary>
        /// <param name="node"></param>
        public override void Visit(SyntaxNode node)
        {
            Tabs++;
            var indents = new String('\t', Tabs);
            //DebugLogger.Instance.WriteLine(indents + node.Kind());
            // Until has node child, base.Visit will call again this method. Otherwise return control and Tabs--
            base.Visit(node);
            Tabs--;
        }
    }

    [Fact]
    public void _1SimplyInheritCSharpSyntaxWalker()
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

        var walker = new CustomWalker();
        walker.Visit(tree.GetRoot());
    }


}
