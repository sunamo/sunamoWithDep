[TestClass]
public class GeneratorMsSqlTests
{
    ComboABC Combo()
    {
        ComboABC c = new ComboABC();
        c.where = new ABC("where_K", "where_V");
        c.isNotWhere = new ABC("isNotWhere_K", "isNotWhere_V");
        c.lowerThanWhere = new ABC("lowerThanWhere_K", "lowerThanWhere_V");
        c.greaterThanWhere = new ABC("greaterThanWhere_K", "greaterThanWhere_V");
        return c;
    }

    [TestMethod]
    public void CombinedWhereCommandTest()
    {
        var c = Combo();
        var s = GeneratorMsSql.CombinedWhereCommand("select * from ab", c.where, c.isNotWhere, c.greaterThanWhere, c.lowerThanWhere, "orderBy");
    }

    [TestMethod]
    public void CombinedWhereTest()
    {
        var c = Combo();
        var s = GeneratorMsSql.CombinedWhere(c.where, c.isNotWhere, c.greaterThanWhere, c.lowerThanWhere);

    }
}
