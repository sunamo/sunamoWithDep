namespace extensions.Tests
{
    [TestClass]
    public class IEnumerableExtensionsTests
    {
        [TestMethod]
        public void SortAscTest()
        {
            List<int> l1 = new List<int>(TestData._123);
            List<int> l2 = new List<int>( TestData._321);

            l1.SortAsc();
            l2.SortAsc();

            CollectionAssert.AreEqual(TestData._123, l1);
            CollectionAssert.AreEqual(TestData._123, l2);
        }
    }
}
