public partial class RoslynLearn
{
    [Fact]
    public async Task _ContinueWith()
    {
        var state = await CSharpScript.RunAsync(@"int x = 5; int y = 3; int z = x + y;");
        var state1 = await state.ContinueWithAsync("x++; y = 1;");
        var state2 = await state.ContinueWithAsync("x = x + y;");


        //ScriptVariable x = state.GetVariable("x");
        //ScriptVariable y = state.GetVariable("y");

        //DebugLogger.Instance.WriteLine($"{x.Name} : {x.Value} : {x.Type} "); // x : 7
        //DebugLogger.Instance.WriteLine($"{y.Name} : {y.Value} : {y.Type} "); // y : 1

    }
}
