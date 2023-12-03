public partial class RoslynLearn
{
    static async void _ScriptReferences()
    {
        ScriptOptions scriptOptions = ScriptOptions.Default;

        //Add reference to mscorlib
        var mscorlib = typeof(System.Object).Assembly;
        var systemCore = typeof(System.Linq.Enumerable).Assembly;
        scriptOptions = scriptOptions.AddReferences(mscorlib, systemCore);
        //Add namespaces
        //scriptOptions = scriptOptions.AddNamespaces("System");
        //scriptOptions = scriptOptions.AddNamespaces("System.Linq");
        //scriptOptions = scriptOptions.AddNamespaces("System.Collections.Generic");

        var state = await CSharpScript.RunAsync(@"var x = new List(){1,2,3,4,5};", scriptOptions);
        state = await state.ContinueWithAsync("var y = x.Take(3).ToList();");

        var y = state.GetVariable("y");
        var yList = (IList)y.Value;
        foreach (var val in yList)
        {
            //DebugLogger.Instance.WriteLine(val + AllStrings.space); // Prints 1 2 3
        }

    }
}
