namespace sunamo.Tests.Collections
{
    public class ValuesTableGridTests
    {
        [Fact]
        public void IsAllInRow()
        {
            List<List<bool>> grid = new List<List<bool>>();
            grid.Add(CA.ToList<bool>(true, true, true));
            grid.Add(CA.ToList<bool>(false, false, false));
            grid.Add(CA.ToList<bool>(true, false, true));
            grid.Add(CA.ToList<bool>(false, true, true));

            ValuesTableGrid<bool> valuesTableGrid = new ValuesTableGrid<bool>(grid);

            List<string> atLeastOne = new List<string>();
            List<string> noOne = new List<string>();

            Assert.Equal(false, valuesTableGrid.IsAllInRow(0, false));
            Assert.Equal(true, valuesTableGrid.IsAllInRow(1, false));
            Assert.Equal(false, valuesTableGrid.IsAllInRow(2, false));
            Assert.Equal(false, valuesTableGrid.IsAllInRow(3, false));

            for (int i = 0; i < grid.Count; i++)
            {
                string file = i.ToString();
                //all true(return false), all false(return true), false,true,false(if skipped, return false), true/false(return false) - everything is going fine
                if (valuesTableGrid.IsAllInRow(i, false))
                {
                    noOne.Add(file);
                }
                else
                {
                    atLeastOne.Add(file);
                }
            }

            TextOutputGenerator generator = new TextOutputGenerator();

            generator.List(noOne, "No one", new TextOutputGeneratorArgs( true, true));
            generator.List(atLeastOne, "At least one", new TextOutputGeneratorArgs( true, true));

#if DEBUG
            //DebugLogger.Instance.WriteLine(generator.ToString());
#endif
        }
    }
}
