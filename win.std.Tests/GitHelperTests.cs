namespace win.std.Tests
{
    [TestClass]
    public class GitHelperTests
    {
        [TestMethod]
        public void NameOfRepoFromOriginUriTest()
        {
            string actual = GitHelper.NameOfRepoFromOriginUri(@"https://github.com/sunamo/sunamoWithoutDep.git");
            Assert.AreEqual("sunamoWithoutDep", actual);
        }
    }
}
