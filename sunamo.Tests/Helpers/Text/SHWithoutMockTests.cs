using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sunamo.Tests.Helpers.Text;
public class SHWithoutMockTests
{
            //[Fact]
        public
#if ASYNC
    async void
#else
    void
#endif
 ReplaceManyFromStringTest()
        {
            string testString = @"Assert.Equal -> Assert.AreEqual
Assert.AreEqual<*> -> CollectionAssert.AreEqual
[Fact] -> [TestMethod]
using Xunit; -> using Microsoft.VisualStudio.TestTools.UnitTesting;";
            testString = "Assert.AreEqual<*> -> CollectionAssert.AreEqual";

            string file = @"E:\vs\Projects\sunamo.Tests\sunamo.Tests.Data\ReplaceManyFromString\In_ReplaceManyFromString.cs";
            var s =
#if ASYNC
    await
#endif
 TF.ReadAllText(file);

            s = SH.ReplaceManyFromString(s, testString, Consts.transformTo);


#if ASYNC
            await
#endif
            TF.WriteAllText(file, s);
        }
}
