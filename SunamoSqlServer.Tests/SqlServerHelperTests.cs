namespace SunamoSqlServer.Tests
{
    [TestClass]
    public class SqlServerHelperTests
    {
        [TestMethod]
        public void SqlCommandToTSQLTextTest()
        {
            SqlCommand c = new SqlCommand(GeneratorMsSql.CombinedWhere(AB.Get("a", "b"), AB.Get("1", 2)));

            var d = SqlServerHelper.SqlCommandToTSQLText(c);
            int i = 0;
        }
    }
}
