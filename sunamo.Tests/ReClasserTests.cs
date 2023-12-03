namespace sunamo.Tests;
public class TestClass
{
    public string Name { get; set; }
    public int ID { get; set; }
    public DateTime? DateTime { get; set; }
    public string Address { get; set; }
}

public class ReClasserTests
{
    [Fact]
    public void FixMeUpTest()
    {
        TestClass t = new TestClass();
        t.Address = "address";
        t.ID = 132;
        t.Name = string.Empty;
        t.DateTime = null;

        var d1 = RH.DumpAsObjectDumperNet(t);
        var ret = t.FixMeUp();
        var d2 = RH.DumpAsObjectDumperNet(ret);
    }
}
