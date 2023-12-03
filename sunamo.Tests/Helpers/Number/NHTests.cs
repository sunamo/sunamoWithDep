namespace sunamo.Tests.Helpers.Numbers
{
    public class NHTests
    {
        public readonly static List<int> input = CA.ToList<int>(4, 0);// 4, 4, 4, 3, 0, 0, 0, 0);
        public readonly static List<int> input3 = CA.ToList<int>(4, 4, 250, 500, 500);
        public readonly static List<int> input4 = CA.ToList<int>(4, 4, 250, 500, 500);
        public readonly static List<int> input5 = CA.ToList<int>(4, 4, 4, 4, 250, 500, 500);
        public readonly static List<double> input2 = CA.ToList<double>(-5, -4, 7.5, 8.7, 3.4, 9.4, 0.8, 1.5, 2.6, 0.9, 0.6, 9.4, 8.4, 6.6, 9.4);

        public class Int
        {
            //3
            [Fact]
            public void MedianTest()
            {
                var median = NH.Median<int>(input);
                var median3 = NH.Median<int>(input3);
                var median4 = NH.Median<int>(input4);
                var median5 = NH.Median<int>(input5);
                //DebugLogger.Instance.WriteLine(median);
            }

            // 3
            [Fact]
            public void Median2Test()
            {
                var median = NH.Median2<int>(input);
                //var median2 = NH.Median2<int>(input2);
                var median3 = NH.Median2<int>(input3);
                var median4 = NH.Median2<int>(input4);
                var median5 = NH.Median2<int>(input5);
                //DebugLogger.Instance.WriteLine(median);
            }
        }
        public class Double
        {
            //3.4
            [Fact]
            public void MedianTest()
            {
                var median = NH.Median<double>(input2);
                //DebugLogger.Instance.WriteLine(median);
            }

            // 3.4
            [Fact]
            public void Median2Test()
            {
                var median = NH.Median2<double>(input2);
                //DebugLogger.Instance.WriteLine(median);
            }
        }

    }
}
