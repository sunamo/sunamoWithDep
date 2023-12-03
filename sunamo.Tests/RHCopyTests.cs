using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoFixture;

using sunamo.RL;

using TestValues.Data;

namespace sunamo.Tests;
public class RHCopyTests
{
    [Fact]
    public void CopyTest()
    {
        var fixture = new Fixture();
        var expected = fixture.CreateMany<TypeWithProperties>();

        var actual = RHCopy.Copy(expected);

        Assert.Equivalent(expected, actual);
    }
}
