using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace sunamo.Tests.Helpers.DT;

public class DTHelperFormalizedTests
{
    [Fact]
    public void IsFormalizedDateTest()
    {
        bool b = DTHelperFormalized.IsFormalizedDate("2022-09-26T11:57:57.8410000Z");
    }
}
