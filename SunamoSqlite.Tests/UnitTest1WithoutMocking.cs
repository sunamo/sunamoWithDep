namespace SunamoSqlite.Tests
{
    public class UnitTest1WithoutMocking
    {
        const string tableName = "table2";
        const string ID = "ID";
        const string value = "value";
        const string dbPath = @"D:\_Test\sunamo\SunamoSqlite\test.db";

        //[Fact]
        public void CreateDbSqliteTest()
        {
            DatabaseLayer.Init(dbPath);

            ColumnsDB c = new ColumnsDB(SloupecDB.CI(TypeAffinity.Int64, ID), SloupecDB.CI(TypeAffinity.Int64, value));
            SQLiteCommand comm = c.GetSqlCreateTable(tableName);
            if (comm.CommandText != null)
            {
                comm.ExecuteNonQuery();
            }

            long first = 1;
            long second = 2;

            StoredProceduresSqliteI.ci.Insert4(tableName, 0, 1);
            StoredProceduresSqliteI.ci.Insert4(tableName, 2, 3);

            

            var dt = StoredProceduresSqliteI.ci.GetDataTableAllRows(tableName);
            Assert.Equal(first, dt.Rows[0][1]);
            Assert.Equal(second, dt.Rows[1][0]);
        }

        //[Fact]
        public void GetDataFromFileTest()
        {
            DatabaseLayer.Init(dbPath);

            var expected = 1;
            var actual = StoredProceduresSqliteI.ci.GetValueColumnInt(tableName, value, ID, 0);

            Assert.Equal(expected, actual[0]);
        }

        //[Fact]
        public void GetFilesWhichAreSqliteTest()
        {
            string folder = @"D:\ed\instagram\";
            var files = FS.GetFiles(folder, true);
            var dbPath = @"D:\_Test\sunamo\SunamoSqlite\test.db";
            var txtFile = @"D:\_Test\sunamo\SunamoSqlite\IsSqlite\a.txt";
            files.Insert(0, dbPath);
            files.Insert(0, txtFile);

            StringBuilder sb = new StringBuilder();

            foreach (var item in files)
            {
                var isSqlite = DatabaseLayer.IsSqlite(item);
                if (isSqlite)
                {
                    DebugLogger.DebugWriteLine(TypeOfMessage.Information, isSqlite + " " + item + " ");
                }
                
            }
        }

        public void CreateJoinedTablesTest()
        {

        }

        //[Fact]
        public void ReadBlobTest()
        {
            var path = @"D:\ed\instagram\Users\n\AppData\Local\Packages\Facebook.InstagramBeta_8xx8rvfyw5nnt\LocalState\AppData\Local\osmeta\DirectSQLiteDatabase\3528248717.db";
            path = @"D:\_Test\sunamo\SunamoSqlite\test.db";
            DatabaseLayer.Init(path);

            List<string> tables = StoredProceduresSqliteI.ci.AllTables();

            var dt = StoredProceduresSqliteI.ci.GetDataTable("messages", "archive");
            foreach (DataRow item in dt.Rows)
            {
                var o = item.ItemArray[5];
                var bytes = DatabaseLayer.FromBlob(o.ToString());
                var bytes2 = (byte[])o;
                var s = DatabaseLayer.ToBlob(bytes2);
            }

            int i = 0;
        }
    }
}
