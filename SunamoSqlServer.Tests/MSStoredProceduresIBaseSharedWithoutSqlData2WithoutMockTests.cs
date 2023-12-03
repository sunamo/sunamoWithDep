[TestClass]
public class MSStoredProceduresIBaseSharedWithoutSqlData2WithoutMockTests
{
    //[TestMethod]
    public void DeleteOneRowTest()
    {
        TestHelper.Init();
        // TODO: DbHelper
        //TestSqlHelper.Init(new UnitTestInit { databases = Databases.LearnTransactSql, cryptData = true });

        Dictionary<string, MSColumnsDB> s = new Dictionary<string, MSColumnsDB>();
        const string tableName = "Test_PageVT";

        s.Add(tableName, new MSColumnsDB(true,
            MSSloupecDB.CI(SqlDbType2.Int, "IDPage"),
            MSSloupecDB.CI(SqlDbType2.TinyInt, "IDTable"),
            MSSloupecDB.CI(SqlDbType2.Int, "IDItem"),
            MSSloupecDB.CI(SqlDbType2.SmallInt, "Day"),
            MSSloupecDB.CI(SqlDbType2.Int, XlfKeys.Views)
            ));

        int IDPage = 0;
        byte IDTable = 0;
        int IDItem = 0;
        short Day = NormalizeDate.To(DateTime.Today);
        int Views = int.MaxValue;

        foreach (var item in s)
        {
            MSStoredProceduresI.ci.DropAndCreateTable(item.Key, item.Value);
        }

        for (int i = 0; i < 3; i++)
        {
            MSStoredProceduresI.ci.Insert4(tableName, IDPage, IDTable, IDItem, Day, Views);
        }

        var c = MSStoredProceduresI.ci.SelectCount(tableName);
        Assert.AreEqual(3, c);

        MSStoredProceduresI.ci.DeleteOneRow(tableName, AB.Get("IDTable", IDTable), AB.Get("IDItem", IDItem), AB.Get("Day", Day));
        c = MSStoredProceduresI.ci.SelectCount(tableName);
        Assert.AreEqual(2, c);
    }
}
