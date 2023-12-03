public partial class RoslynLearn
{
    static async void _RunAsync1()
    {
        var state = await CSharpScript.RunAsync(@"int x = 5; int y = 3; int z = x + y;""");

        ScriptVariable x = state.GetVariable("x");
        ScriptVariable y = state.GetVariable("y");

        //DebugLogger.Instance.WriteLine($"{x.Name} : {x.Value} : {x.Type} "); // x : 5
        //DebugLogger.Instance.WriteLine($"{y.Name} : {y.Value} : {y.Type} "); // y : 3

    }
}
