/// <summary>
/// LearnTransactSQL
/// </summary>
public class TablesLTS
{
    public const string TableToCopy = "TableToCopy";

    #region Lyr
    public const string Test_PageNewLyrSong = "Test_PageNewLyrSong";
    public const string Test_PageLyrSong = "Test_PageLyrSong";
    public const string Test_Lyr_Song = "Test_Lyr_Song"; 
    #endregion

    #region !Lyr
    public const string Test_PageNew3 = "Test_PageNew3";
    public const string Test_Page = "Test_Page";
    public const string Test_App_App = "Test_App_App"; 
    #endregion

    public const string Test_PageNew3_SI = "Test_PageNew3_SI";
}

public class LTSLayer
{
    const string prefixTableName = Consts.Test_;
    //const string tableName = "Test_PageVT";
    public const string tableName3 = "Test_PageNew3";
    public const string tableName4 = "Test_PageNewLyrSong";
    public const string tableEntity4 = "Test_Lyr_Song";
    public const string tableEntity3 = "Test_App_App";

    public static Dictionary<string, MSColumnsDB> s = new Dictionary<string, MSColumnsDB>();

    static LTSLayer()
    {
        // Must be initialized in static ctor. Tables are needed everywhere. I have rage when still must starting debugging coz I forgot call CreateStaticTables. Make work as easy as is possible.
        // Against adding two times is protecting checking for count > 0
        CreateStaticTables();
    }

    public static void DeleteAndCreateTable(string tn)
    {
        var cs = MSDatabaseLayer.cs;
        using (var conn = new SqlConnection(cs))
        {
            conn.Open();
            MSStoredProceduresI.ci.DropTableIfExists(tn);
            var comm = s[tn].GetSqlCreateTable(tn, true, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }

    public static void CreateStaticTables()
    {
        if (s.Count > 0)
        {
            return;
        }

        #region Table structure
        #region Lyr
        // Musí být bez _ protože aplikace mi přes něj parsují
        s.Add(TablesLTS.Test_PageLyrSong, new MSColumnsDB(true,
        MSSloupecDB.CI(SqlDbType2.Int, "ID", true),
        MSSloupecDB.CI(SqlDbType2.Int, "OverallViews")
        ));

        //Test_PageNewLyrSong
        s.Add(tableName4, new MSColumnsDB(true,
               // can't be primary key coz there will be many days for every days
               MSSloupecDB.CI(SqlDbType2.Int, ColumnNames.IDPageLyrSong),
           MSSloupecDB.CI(SqlDbType2.SmallInt, "Day"),
           MSSloupecDB.CI(SqlDbType2.Int, XlfKeys.Views)
           ));

        //Test_Lyr_Song
        s.Add(tableEntity4, new MSColumnsDB(true,
          MSSloupecDB.CI(SqlDbType2.Int, "ID", true),
          MSSloupecDB.CI(SqlDbType2.Int, "ViewLastWeek"))
          );
        #endregion


        #region !Lyr
        s.Add(TablesLTS.Test_Page, new MSColumnsDB(true,
                  MSSloupecDB.CI(SqlDbType2.Int, "ID", true),
                  MSSloupecDB.CI(SqlDbType2.Bit, "IsOld"),
                  MSSloupecDB.CI(SqlDbType2.Int, "OverallViews"),
                  MSSloupecDB.CI(SqlDbType2.Bit, "AllowNewComments")
                  ));

        s.Add(tableName3, new MSColumnsDB(true,
                MSSloupecDB.CI(SqlDbType2.Int, "IDItem"),
            MSSloupecDB.CI(SqlDbType2.Int, "IDPage"),
            MSSloupecDB.CI(SqlDbType2.SmallInt, "Day"),
            MSSloupecDB.CI(SqlDbType2.Int, XlfKeys.Views)
            )); 
        #endregion

        s.Add(TablesLTS.Test_PageNew3_SI, new MSColumnsDB(true,
                MSSloupecDB.CI(SqlDbType2.SmallInt, "IDItem"),
            MSSloupecDB.CI(SqlDbType2.Int, "IDPage"),
            MSSloupecDB.CI(SqlDbType2.SmallInt, "Day"),
            MSSloupecDB.CI(SqlDbType2.Int, XlfKeys.Views)
            ));

        s.Add(tableEntity3, new MSColumnsDB(true,
          MSSloupecDB.CI(SqlDbType2.Int, "ID", true),
          MSSloupecDB.CI(SqlDbType2.Int, "ViewLastWeek"))
          );

        #endregion
    }
}
