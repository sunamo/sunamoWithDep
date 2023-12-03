/*
 * public class Sample
            {
               public void Foo()
               {
                  //DebugLogger.Instance.WriteLine();

                  #region SomeRegion
                  //Some other code
                  #endregion
                  
                }
            }
 */

public partial class _3Better1
{

    // Instead of 1 odnt delete #region and comment near 
    public class EmtpyStatementRemoval : CSharpSyntaxRewriter
    {
        public override SyntaxNode VisitEmptyStatement(EmptyStatementSyntax node)
        {
            //Construct an EmptyStatementSyntax with a missing semicolon
            return node.WithSemicolonToken(
                SyntaxFactory.MissingToken(SyntaxKind.SemicolonToken)
                    .WithLeadingTrivia(node.SemicolonToken.LeadingTrivia)
                    .WithTrailingTrivia(node.SemicolonToken.TrailingTrivia));
        }
    }

    [Fact]
    public void _3Better1Method()
    {
        var tree = CSharpSyntaxTree.ParseText(@"
            public class Sample
            {
               public void Foo()
               {
                  //DebugLogger.Instance.WriteLine();
;
                  #region SomeRegion
                  //Some other code
                  #endregion
                  ;
                }
            }");

        var rewriter = new EmtpyStatementRemoval();
        var result = rewriter.Visit(tree.GetRoot());
        //DebugLogger.Instance.WriteLine(result.ToFullString());
    }


}
