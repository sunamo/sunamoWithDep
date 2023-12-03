using FluentAssertions;

namespace SunamoCode.Tests.Helpers
{
    public class CSharpHelperTests
    {
        [Fact]
        public void RemoveCommentsTest()
        {
            const string input = @"a
//b
c
d /*e*/
/*haf
baf*/
f";
            List<string> expected = SH.GetLines(@"a
c
d

f");
            var actual = CSharpHelper.RemoveComments(SH.GetLines(input), true, true);
            actual.Should().BeEquivalentTo(expected);
        }
        [Fact]
        public void RemoveComments2Test()
        {
            const string input = @"a
//b
c
d /*e*/
/*haf
baf*/
f";
            // d have space on end
            const string expected = @"a

c
d 

f";
            var actual = CSharpHelper.RemoveBlockComments(input);
            Assert.Equal(expected, actual);
        }
    }
}
