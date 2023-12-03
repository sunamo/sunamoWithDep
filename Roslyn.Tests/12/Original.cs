public partial class RoslynLearn
{
    [Fact]
    public void _Original2()
    {
        // CL.ReadKey() tu nemůže být - stopne mi vykonávání všech testů
        char key = 'A'; //CL.ReadKey().KeyChar;
        if (key == 'A')
        {
            //DebugLogger.Instance.WriteLine("You pressed A");
        }
        else
        {
            //DebugLogger.Instance.WriteLine("You didn't press A");
        }

    }
}
