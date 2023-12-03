/*
 *             public class Sample
            {
               public void Foo()
               {
                  //DebugLogger.Instance.WriteLine();
                }
            }
 */

public partial class RoslynLearn
{
    /// <summary>
    /// Roslyn throw all of redundant semicolon as part of EmptyStatementSyntax
    /// </summary>
    public class EmtpyStatementRemoval : CSharpSyntaxRewriter
    {
        public override SyntaxNode VisitEmptyStatement(EmptyStatementSyntax node)
        {
            //Simply remove all Empty Statements
            return null;
        }
    }

    [Fact]
    public void _1RemoveAllUnecessarySemicolons()
    {
        //A syntax tree with an unnecessary semicolon on its own line
        var tree = CSharpSyntaxTree.ParseText(@"
            public class Sample
            {
               public void Foo()
               {
                  //DebugLogger.Instance.WriteLine();
                  ;
                }
            }");

        var rewriter = new EmtpyStatementRemoval();
        // change source code to other look - without empty statements
        var result = rewriter.Visit(tree.GetRoot());
        //DebugLogger.Instance.WriteLine(result.ToFullString());
    }


}
