namespace shared.Tests
{ 
    /// <summary>
    /// None of method can return more elements if in where is more values for same column. Only way is standalone select for every ID.
    /// </summary>
    [TestClass]
public class MSStoredProceduresIWithoutMockTests
{


    const string table = "SalesPeople";
    const string key = "SalesPersonId";
    const string value = "SalesPersonName";
        List<string> resultString = CA.ToListString("Value1", "Value4");
        List<int> resultInt = CA.ToList<int>(1,4);

        void PrepareTest()
    {
            DatabasesConnectionsP.SetConnToMSDatabaseLayer(Databases.LearnTransactSql, null);

            var dbs = MSStoredProceduresI.ci.SelectGetAllTablesInDB();
            int i = 0;

            DatabasesConnectionsP.SetConnToMSDatabaseLayer(Databases.LearnTransactSql, null);


    }

    AB[] ABArray()
    {
        return new ABC(AB.Get(key, 1), AB.Get(key, 4)).ToArray();
    }

    ABC ABC()
    {
        return new ABC(ABArray());
    }

    //[TestMethod]
    public void SelectAllRowsOfColumnsTest()
    {
        PrepareTest();

            

        DataTable r1 = MSStoredProceduresI.ci.SelectAllRowsOfColumns(table, value, ABArray());

        List<string> r2 = MSStoredProceduresI.ci.DataTableToListString(r1, 0);

            // None of method can return more elements if in where is more values for same column. Only way is standalone select for every ID.
            //CollectionAssert.AreEqual(r2, resultString);
    }

    /// <summary>
    /// Use only SqlCommand, SqlConnection
    /// </summary>
    ////[TestMethod]
    public void SelectDataTableTest()
    {
        //MSStoredProceduresI.ci.SelectDataTable()
    }

    //[TestMethod]
    public void SelectDataTableAllRows()
    {
            PrepareTest();

            // Select with only one value
            DataTable r1 = MSStoredProceduresI.ci.SelectDataTableAllRows(table, key, 1);

            List<int> r2 = MSStoredProceduresI.ci.DataTableToListInt(r1, 0);

            
            CollectionAssert.AreEqual(TestData.list1, r2);
    }

    //[TestMethod]
    public void SelectDataTableSelective()
    {
            PrepareTest();

            DataTable r1 = MSStoredProceduresI.ci.SelectDataTableSelective(table, value, ABArray());

        List<string> r2 = MSStoredProceduresI.ci.DataTableToListString(r1, 0);

            // None of method can return more elements if in where is more values for same column. Only way is standalone select for every ID.
            //CollectionAssert.AreEqual(resultString, r2);
    }

    //[TestMethod]
    public void SelectValuesOfColumnAllRowsInt()
    {
            PrepareTest();

            List<string> r1 = MSStoredProceduresI.ci.SelectValuesOfColumnAllRowsString(table, value, ABC(), new ABC());

        List<int> r2 = MSStoredProceduresI.ci.SelectValuesOfColumnAllRowsInt(table, key, ABC(), new ABC());

            // None of method can return more elements if in where is more values for same column. Only way is standalone select for every ID.
            //CollectionAssert.AreEqual(resultString, r2);
    }

    //[TestMethod]
    public void SelectValuesOfColumnInt()
    {
            PrepareTest();

            List<int> result = MSStoredProceduresI.ci.SelectValuesOfColumnInt(true, table, key, ABArray());

            // None of method can return more elements if in where is more values for same column. Only way is standalone select for every ID.
            //CollectionAssert.AreEqual(resultInt, result);
    }
}

}
