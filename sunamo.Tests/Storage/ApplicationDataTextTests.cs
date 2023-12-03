namespace sunamo.Tests.Storage
{
    public class ApplicationDataTextTests
    {
        //[Fact]
        public
#if ASYNC
    async void
#else
    void
#endif
 ParseTest()
        {
            string testFile = @"D:\_Test\ConsoleApp1\ConsoleApp1\ApplicationDataText.txt";

            var headers = CA.ToListString("Copy", "Dont copy to");
            CA.AddSuffix(headers, AllStrings.colon);

            var value1 = CA.ToListString("Shared");

            var dict =
#if ASYNC
    await
#endif
 ApplicationDataText.Parse(testFile, headers);
            Assert.Equal<string>(value1, dict[headers[0]]);
        }
    }
}
