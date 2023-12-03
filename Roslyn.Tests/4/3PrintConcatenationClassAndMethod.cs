/*
 Output:
 MyClass.MyMethod
MyOtherClass.MyMethod
 */

public partial class RoslynLearn
{

    // Instead of 2, there is only visit ClassDeclarationSyntax and MethodDeclarationSyntax
    public class ClassMethodWalker : CSharpSyntaxWalker
    {
        string className = String.Empty;
        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            className = node.Identifier.ToString();
            base.VisitClassDeclaration(node);
        }

        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            string methodName = node.Identifier.ToString();
            //DebugLogger.Instance.WriteLine(className + AllChars.dot + methodName);
            base.VisitMethodDeclaration(node);
        }
    }

    [Fact]
    public void _3PrintConcatenationClassAndMethod()
    {
        var tree = CSharpSyntaxTree.ParseText(@"
            public class MyClass
            {
                public void MyMethod()
                {
                }
            }
            public class MyOtherClass
            {
                public void MyMethod(int n)
                {
                }
            }
           ");

        var walker = new ClassMethodWalker();
        walker.Visit(tree.GetRoot());
    }


}
