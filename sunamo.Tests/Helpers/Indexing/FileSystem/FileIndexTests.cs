namespace sunamo.Tests.Indexing.FileSystem
{
    public class FileIndexTests
    {
        FileIndex fi = new FileIndex();
        readonly string folder1, folder2;
        int index1, index2;
        string f1_1, f1_2, f1_3;

        public FileIndexTests()
        {
            folder1 = @"D:\_Test\sunamo\Indexers\FileSystem\FileIndex\a\";
            folder2 = @"D:\_Test\sunamo\Indexers\FileSystem\FileIndex\b\";

            string folder1_1 = folder1 + "b\\";

             f1_1 = folder1 + "a1.txt";
             f1_2 = folder1 + "a2.txt";
             f1_3 = folder1_1 + "a3.txt";

            string f2_1 = "b1.txt";

            FS.WriteAllText(folder1_1 + f1_3, "");
            FS.WriteAllText(folder1_1 + f1_3, "");
            FS.WriteAllText(folder1_1 + f1_3, "");

            fi.AddFolderRecursively(folder1);

            // Get index
            index1 = fi.GetRelativeFolder(folder1);
            index2 = fi.GetRelativeFolder(folder2);

            Assert.Equal(index1, 0);
            Assert.Equal(index2, 1);

            string dir1 = fi.GetRelativeFolder(index1);
            string dir2 = fi.GetRelativeFolder(index2);

            Assert.Equal(dir1, folder1);
            Assert.Equal(dir2, folder2);


        }

        public void AggregateFilesFromAllFolders()
        {
            List<string> files = CA.ToListString(f1_1, f1_3);
            
            Dictionary<string, int> relativeFilePathForEveryColumn = null;
            FileIndex.AggregateFilesFromAllFolders(folder1, fi,  relativeFilePathForEveryColumn, files);
                
        }

        public void d()
        {

        }
    }
}
