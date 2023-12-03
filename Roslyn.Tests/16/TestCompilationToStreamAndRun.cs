// Compilation direct to memory and run

public partial class RoslynLearn
{
    [Fact]
    public void _TestCompilationToStreamAndRun()
    {
        //var tree = CSharpSyntaxTree.ParseText(@"
        //using System;using Xunit;
        //public class MyClass
        //{
        //    public static void Main()
        //    {
        //        //DebugLogger.Instance.WriteLine(""Hello World!"");
        //        //DebugLogger.Instance.ReadLine();
        //    }   
        //}");

        //var mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
        //var compilation = CSharpCompilation.Create("MyCompilation",
        //    syntaxTrees: new[] { tree }, references: new[] { mscorlib });

        ////Emit to stream
        //var ms = new MemoryStream();
        //var emitResult = compilation.Emit(ms);

        ////Load into currently running assembly. Normally we'd probably
        ////want to do this in an AppDomain
        //var ourAssembly = Assembly.Load(ms.ToArray());
        //var type = ourAssembly.GetType("MyClass");

        ////Invokes our main method and writes "Hello World" :)
        //type.InvokeMember("Main", BindingFlags.Default | BindingFlags.InvokeMethod, null, null, null);

    }
}
