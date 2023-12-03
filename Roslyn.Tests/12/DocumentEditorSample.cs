public partial class RoslynLearn
{
    // We’ll use the DocumentEditor to simultaneously insert an invocation before the first CL.WriteLine() and to insert another after the second.
    // Debugging DocumentEditor can be very painful

    static async void _DocumentEditorSample()
    {
        var mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
        var workspace = new AdhocWorkspace();
        var projectId = ProjectId.CreateNewId();
        var versionStamp = VersionStamp.Create();
        var projectInfo = ProjectInfo.Create(projectId, versionStamp, "NewProject", "projName", LanguageNames.CSharp);
        var newProject = workspace.AddProject(projectInfo);
        var sourceText = SourceText.From(@"
        class C
        {
            void M()
            {
                char key = //DebugLogger.Instance.ReadKey();
                if (key == 'A')
                {
                    //DebugLogger.Instance.WriteLine(""You pressed A"");
                }
                else
                {
                    //DebugLogger.Instance.WriteLine(""You didn't press A"");
                }
            }
        }");
        var document = workspace.AddDocument(newProject.Id, "NewFile.cs", sourceText);
        var syntaxRoot = await document.GetSyntaxRootAsync();
        var ifStatement = syntaxRoot.DescendantNodes().OfType<IfStatementSyntax>().Single();

        var conditionWasTrueInvocation =
        SyntaxFactory.ExpressionStatement(
            SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("LogConditionWasTrue"))
            .WithArgumentList(
                            SyntaxFactory.ArgumentList()
                            .WithOpenParenToken(
                                SyntaxFactory.Token(
                                    SyntaxKind.OpenParenToken))
                            .WithCloseParenToken(
                                SyntaxFactory.Token(
                                    SyntaxKind.CloseParenToken))))
                    .WithSemicolonToken(
                        SyntaxFactory.Token(
                            SyntaxKind.SemicolonToken));

        var conditionWasFalseInvocation =
        SyntaxFactory.ExpressionStatement(
            SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("LogConditionWasFalse"))
            .WithArgumentList(
                            SyntaxFactory.ArgumentList()
                            .WithOpenParenToken(
                                SyntaxFactory.Token(
                                    SyntaxKind.OpenParenToken))
                            .WithCloseParenToken(
                                SyntaxFactory.Token(
                                    SyntaxKind.CloseParenToken))))
                    .WithSemicolonToken(
                        SyntaxFactory.Token(
                            SyntaxKind.SemicolonToken));

        //Finally/* ... */ create the document editor
        var documentEditor = await DocumentEditor.CreateAsync(document);
        //Insert LogConditionWasTrue() before the //DebugLogger.Instance.WriteLine()
        documentEditor.InsertBefore(ifStatement.Statement.ChildNodes().Single(), conditionWasTrueInvocation);
        //Insert LogConditionWasFalse() after the //DebugLogger.Instance.WriteLine()
        documentEditor.InsertAfter(ifStatement.Else.Statement.ChildNodes().Single(), conditionWasFalseInvocation);

        var newDocument = documentEditor.GetChangedDocument();

    }
}
