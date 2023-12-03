public partial class RoslynLearn
{
    // the same code as in 1, only for refresh
    public class _2NewForLoopSampleCode
    {
        public void Foo()
        {
            int[] outerArray = new int[10] { 0, 1, 2, 3, 4, 0, 1, 2, 3, 4 };
            for (int index = 0; index < 10; index++)
            {
                int[] innerArray = new int[10] { 0, 1, 2, 3, 4, 0, 1, 2, 3, 4 };
                index = index + 2;
                outerArray[index - 1] = 5;
            }
        }
    }


}
