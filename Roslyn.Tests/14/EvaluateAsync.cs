// EvaluateAsync - always return one result
// RunAsync - more complex
// ContinueAsync - for adding more code to runned RunAsync
// ScriptReferences - add assembly to new possibilities

public partial class RoslynLearn
{
    static async void _EvaluateAsync()
    {
        var result = await CSharpScript.EvaluateAsync("5 + 5");
        //DebugLogger.Instance.WriteLine(result); // 10

        result = await CSharpScript.EvaluateAsync(@"""sample""");
        //DebugLogger.Instance.WriteLine(result); // sample

        result = await CSharpScript.EvaluateAsync(@"""sample"" + "" string""");
        //DebugLogger.Instance.WriteLine(result); // sample string

        result = await CSharpScript.EvaluateAsync("int x = 5; int y = 5; x"); //Note the last x is not contained in a proper statement
        //DebugLogger.Instance.WriteLine(result); // 5

    }
}
