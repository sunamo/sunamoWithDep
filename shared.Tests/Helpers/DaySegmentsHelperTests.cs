namespace shared.Tests.Helpers
{
    [TestClass]
    public class DaySegmentsHelperTests
    {
        [TestMethod]
        public void GetSegmentTest()
        {
            Assert.AreEqual(0, Get(0, 4));
            Assert.AreEqual(1, Get(0, 5));
            Assert.AreEqual(1, Get(0, 6));
            Assert.AreEqual(12, Get(1, 2));
        }

        private int Get(int v1, int v2)
        {
            return DaySegmentsHelper.GetSegment(new DateTime(1, 1, 1, v1, v2, 0));
        }
    }
}
