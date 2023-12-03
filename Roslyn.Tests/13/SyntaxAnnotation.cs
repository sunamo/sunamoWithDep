// SyntaxAnnotations is solution for immutable SyntaxTree. When is made change on SyntaxTree, is lost connection with previous node. Therefore is for us SyntaxAnnotations.

public partial class RoslynLearn
{
    [Fact]
    public void _SyntaxAnnotation()
    {
        AdhocWorkspace workspace = new AdhocWorkspace();
        Microsoft.CodeAnalysis.Project project = workspace.AddProject("SampleProject", LanguageNames.CSharp);

        //Attach a syntax annotation to the class declaration
        var syntaxAnnotation = new SyntaxAnnotation();
        var classDeclaration = SyntaxFactory.ClassDeclaration("MyClass")
            .WithAdditionalAnnotations(syntaxAnnotation);

        var compilationUnit = SyntaxFactory.CompilationUnit().AddMembers(classDeclaration);

        Document document = project.AddDocument("SampleDocument.cs", compilationUnit);
        SemanticModel semanticModel = document.GetSemanticModelAsync().Result;

        //Use the annotation on our original node to find the new class declaration
        var changedClass = document.GetSyntaxRootAsync().Result.DescendantNodes().OfType<ClassDeclarationSyntax>()
            .Where(n => n.HasAnnotation(syntaxAnnotation)).Single();
        var symbol = semanticModel.GetDeclaredSymbol(changedClass);

    }
}
