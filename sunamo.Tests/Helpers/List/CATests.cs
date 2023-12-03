namespace sunamo.Tests.Helpers.List
{
    public class CATests
    {
        [Fact]
        public void OneElementCollectionToMultiTest()
        {
            var arr = CA.ToArrayT<object>("|");
            var d = CA.OneElementCollectionToMulti(arr);
            int i = 0;
        }

        [Fact]
        public void WrapWithAndJoinTest()
        {
            List<string> input = TestData.listAB2;
            List<string> expected = new List<string>(CA.ToListString2("'a' ", "'b' "));
            var result = CA.WrapWithAndJoin(input, "'", AllStrings.space);

            Assert.Equal<string>(expected, result);
        }

        [Fact]
        public void ContainsAnyFromElementTest()
        {
            string r = "cds";
            var s = CA.ToList<string>(TestData.listABC);
            var i = CA.ContainsAnyFromElement(r, s);
        }

        [Fact]
        public void CompareListSongFromInternetTest()
        {
            List<SongFromInternet> c1 = new List<SongFromInternet>();
            c1.Add(new SongFromInternet("a-b"));
            c1.Add(new SongFromInternet("c-d"));
            c1.Add(new SongFromInternet("a-b [c]"));
            //c1.Add(new SongFromInternet("a-b"));

            List<SongFromInternet> c2 = new List<SongFromInternet>();
            c2.Add(new SongFromInternet("a-b"));
            c2.Add(new SongFromInternet("c-d"));


            var both = CA.CompareList(c1, c2);
        }

        [Fact]
        public void RemoveDuplicitiesListTest()
        {
            //cc
            List<string> foundedDuplicites;
            //c,b,a
            var list = CA.RemoveDuplicitiesList(TestData.listABCCC, out foundedDuplicites);
            int i = 0;
        }

        [Fact]
        public void GetDuplicitiesTest()
        {

            // a,b,c
            List<string> alreadyProcessed;
            // list = c
            var list = CA.GetDuplicities(TestData.listABCCC, out alreadyProcessed);
            int i = 0;
        }

        [Fact]
        public void DoubleOrMoreMultiLinesToSingleTest()
        {
            var input = @"a

b";
            var excepted = @"a

b";
            //            CA.DoubleOrMoreMultiLinesToSingle(ref input);
            //            Assert.Equal(excepted, input);

            //            input = @"a



            //b";

            CA.DoubleOrMoreMultiLinesToSingle(ref input);
            Assert.Equal(excepted, input);

            input = @"@media screen and (min-width: 1025px) and (max-width: 1280px) {
	#cd {
		width: 200px;
	}
}";
            var input2 = input;
            CA.DoubleOrMoreMultiLinesToSingle(ref input2);
            Assert.Equal(input, input2);
        }

        /// <summary>
        /// Vznikla kvůli ReplaceAll3
        /// evidentně nefunguje a teď nemám čas to opravovat, existují funkční i ReplaceAll/ReplaceAll2, ReplaceAll3 je jen performance experiment
        /// </summary>
        //[Fact]
        public void EqualRangesTest()
        {
            var input = CA.ToList<int>(5,
                1, 2, 3,

                4, 1, 2, 3, 6);
            var toFind = CA.ToList<int>(1, 2, 3);
            var excepted = CA.ToList<FromTo>(new FromTo(1, 3, FromToUse.None), new FromTo(5, 7, FromToUse.None));

            var actual = CA.EqualRanges<int>(input, toFind);
            Assert.Equal<FromTo>(excepted, actual);

        }

        //[Fact]
        public void EqualRangesTest2()
        {
            var input = CA.ToList<int>(
                1, 2, 3);
            var toFind = CA.ToList<int>(1, 2, 3);
            //var excepted = CA.ToList<FromTo>(new FromTo(1, 3, FromToUse.None), new FromTo(5, 7, FromToUse.None));

            var actual = CA.EqualRanges<int>(input, toFind);
            //Assert.Equal<FromTo>(excepted, actual);

        }

        [Fact]
        public void IndexesWithValueTest()
        {
            var c = TestData.c;

            var d = TestData.listABC;
            d.Add(c);

            var actual = CA.IndexesWithValue<string>(d, c);
            var expected = CA.ToList<int>(2, 3);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindOutLongestItemTest()
        {
            var actual = CA.FindOutLongestItem(TestData.notSortedBySize);
            Assert.Equal(TestData.abc, actual);
        }

        [Fact]
        public void ReturnWhichContainsTest()
        {
            var input = @"a b d
a b c";
            var inputLines = SH.GetLines(input);

            // first line
            var c = CA.ReturnWhichContains(inputLines, "a d", ContainsCompareMethod.SplitToWords);
            // first line
            var c2 = CA.ReturnWhichContains(inputLines, "a !c", ContainsCompareMethod.Negations);
            // nothing
            var c3 = CA.ReturnWhichContains(inputLines, "a d", ContainsCompareMethod.WholeInput);
            // second line
            var c4 = CA.ReturnWhichContains(inputLines, "a c", ContainsCompareMethod.SplitToWords);

            int i = 0;
        }

        [Fact]
        public void ToJaggedTTest()
        {
            var input = new int[2, 2] { { 0, 1 }, { 2, 3 } };

            var actual = CA.ToJagged<int>(input);

        }

        [Fact]
        public void ToJaggedTest()
        {
            var input = new bool[2, 2] { { true, false }, { false, true } };

            var actual = CA.ToJagged(input);

        }

        [Fact]
        public void RemoveWildcardTest()
        {

        }

        [Fact]
        public void DivideByPercentTest()
        {
            List<int> a = TestData._0To95;
            var actual = CA.DivideByPercent<int>(a, 10);

            Assert.Equal(TestData._0To95By10, actual);
        }
    }
}
