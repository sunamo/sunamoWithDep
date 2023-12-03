// visit all the methods available to a given compilation

public class MethodSymbolVisitor : SymbolVisitor
{
    //NOTE: We have to visit the namespace's children even though
    //we don't care about them. :(
    public override void VisitNamespace(INamespaceSymbol symbol)
    {
        foreach (var child in symbol.GetMembers())
        {
            child.Accept(this);
        }
    }

    //NOTE: We have to visit the named type's children even though
    //we don't care about them. :(
    public override void VisitNamedType(INamedTypeSymbol symbol)
    {
        foreach (var child in symbol.GetMembers())
        {
            child.Accept(this);
        }
    }

    /// <summary>
    /// This method is new
    /// </summary>
    /// <param name="symbol"></param>
    public override void VisitMethod(IMethodSymbol symbol)
    {
        //DebugLogger.Instance.WriteLine(symbol);
    }
}
