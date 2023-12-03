public partial class RoslynLearn
{
    [Fact]
    public void _TestCompilationOptions()
    {
        var tree = CSharpSyntaxTree.ParseText(@"
        using System;using Xunit;
        public class MyClass
        {
            public static void Main()
            {
                //DebugLogger.Instance.WriteLine(""Hello World!"");
                //DebugLogger.Instance.ReadLine();
            }   
        }");

        //We first have to choose what kind of output we're creating: DLL, .exe etc.
        var options = new CSharpCompilationOptions(OutputKind.ConsoleApplication);
        options = options.WithAllowUnsafe(true);                                //Allow unsafe code;
        options = options.WithOptimizationLevel(OptimizationLevel.Release);     //Set optimization level
        options = options.WithPlatform(Platform.X64);                           //Set platform

        var mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
        var compilation = CSharpCompilation.Create("MyCompilation",
            syntaxTrees: new[] { tree },
            references: new[] { mscorlib },
            options: options);                                            //Pass options to compilation

    }
}
