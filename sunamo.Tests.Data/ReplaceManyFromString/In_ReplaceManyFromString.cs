namespace ConsoleApp1.Tests
{
    public class ConsoleApp1ResearchTests
    {
        [TestMethod]
        public void GenerateCommandForGitAddTest()
        {
            const string folder = @"D:\_Test\ConsoleApp1\ConsoleApp1\GenerateCommandForGitAdd\";
            const string extension = AllExtensions.txt;
            const string moreCandidates = "a";
            const string fileDoesntExistsOnDisc = "c";
            const string fileDoesntExistsInFolder = "a/b";


            List<string> filesOK = CA.ToListString("a/a.txt", "b/b.txt");

            string expected = GitBashBuilder.CreateGitAddForFiles(new System.Text.StringBuilder(), filesOK);

            List<string> filesBad = new List<string>();
            if (false)
            {
                filesBad.AddRange(CA.ToEnumerable(moreCandidates, fileDoesntExistsInFolder, fileDoesntExistsOnDisc));
            }
            else
            {
                filesBad.AddRange(CA.ToEnumerable("a/a.txt", "b.txt - b"));
            }

            bool anyError;
            string actual = Program.GenerateCommandForGitAdd(TypedDebugLogger.Instance, folder, filesBad, out anyError, extension);

            Assert.Equal(expected, actual);
        }

        [TestMethod]
        public void FindUniqueFilesInFoldersTest()
        {
            List<string> atLeastOneActual = new List<string>();
            List<string> noOneActual = new List<string>();
            string basePath = @"D:\_Test\ConsoleApp1\ConsoleApp1\FindUniqueFilesInFolders\";
            string okFolder = basePath + "Ok bc";
            string badFolder = basePath + "Bad ab";
            string fileWithAllFiles = basePath + "AllFiles.txt";

            Program.FindUniqueFilesInFolders(fileWithAllFiles, ref atLeastOneActual, ref noOneActual, true, okFolder, badFolder);

            string relativePathStartWith = "a App\\";

            string a = relativePathStartWith + "a.cs";
            string b = relativePathStartWith + "b.cs";
            string c = relativePathStartWith + "c.cs";
            string d = relativePathStartWith + "d.cs";

            List<string> atLeastOneExpected = CA.ToListString(a, b, c);
            List<string> noOneExpected = CA.ToListString(d);

            Assert.Equal<string>(atLeastOneActual, atLeastOneExpected);
            Assert.Equal<string>(noOneActual, noOneExpected);
        }

        [TestMethod]
        public void OccupationOfCollegeRooms()
        {
            const int numberOfRooms = 3;
            const string building = "A";

            string data = "";
            data = @"1 010
1 100";

            data = @"1 010
1 100
2 10
3 1202
4 sd
5";
            string expected = "1 110";
            string actual = Program.OccupationOfCollegeRooms(data, building, numberOfRooms);
            ClipboardHelper.SetText(actual);

            Assert.Equal(expected, actual);

        }

        [TestMethod]
        public void CalculateDifferencesBetweenTwoDateTimesAndSubstract()
        {
            //s = "17-51-20-40-3-38";
            // s = "27.9. 19:19 - 28.9. 7:19";
            //s = "1. 2 :3 ";
        }

        [TestMethod]
        public void CalculateDifferencesBetweenTwoDateTimesAndSubstract2()
        {
            //s = "27.9. 19:19 - 28.9. 7:19";
            //s = "1. 2 :3 ";
            //s = "28.9. 7:19 27.9. 19:19 27.9. 19:19";
        }
    }
}
