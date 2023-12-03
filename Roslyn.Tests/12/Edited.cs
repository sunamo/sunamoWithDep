// Automatically add calling LogCondition*

public partial class RoslynLearn
{
    [Fact]
    public void _Edited()
    {
        char key = 'B'; //CL.ReadKey().KeyChar;
        if (key == 'A')
        {
            //LogConditionWasTrue();
            //DebugLogger.Instance.WriteLine("You pressed A");
        }
        else
        {
            //DebugLogger.Instance.WriteLine("You didn't press A");

            //LogConditionWasFalse();
        }

    }
}
