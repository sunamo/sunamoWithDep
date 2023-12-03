using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sunamo.Tests.Helpers.FileSystem;
/// <summary>
/// 3 možnosti:
/// 1/ zabalit do csproj archívy 
/// 2/ mockovat 
/// 3/ úplně tyhle testy smazat
/// </summary>
public class FSManipulationWithoutMockTests
{
    //[Fact]
    public async void GetFilesAsyncTest()
    {
        TestHelper.Init();

        var files = await FS.GetFilesAsync(@"D:\_Test\sunamo\sunamo\Helpers\FileSystem\FS\GetFiles\", "*", SearchOption.AllDirectories);
        var f = 0;
    }

    //[Fact]
    public void GetFilesEveryFolder()
    {
        TestHelper.Init();

        var path = @"D:\_Test\EveryLine\EveryLine\SearchCodeElementsUC\";

        var mask = "*.csproj,*.cs";

        var d = FS.GetFilesEveryFolder(path, mask, SearchOption.AllDirectories);
        int i = 0;
    }

    //[Fact]
    public void GetFilesTest()
    {
        TestHelper.Init();

        var files = FS.GetFiles(@"D:\_Test\sunamo\sunamo\Helpers\FileSystem\FS\GetFiles\", "*", true);
        var f = 0;
    }

    //[Fact]
    public void GetFilesMoreMascAsyncTest()
    {
        FS.TryDeleteDirectoryOrFile(@"E:\vs\Projects\sunamo.cz\apps.sunamo.cz\_\Content");

        var folder = @"E:\vs\Projects\sunamo.cz\";
        string mask = AllStrings.ast;
        var so = SearchOption.AllDirectories;
        var gfmo = new GetFilesMoreMascArgs { deleteFromDriveWhenCannotBeResolved = true };

        var f = FS.GetFilesMoreMasc(folder, mask, so);
        //var r = Task.Run<List<string>>(async () => FS.GetFilesMoreMasc(folder, mask, so));
        //var f = r.Result;
        f.Sort();
        int i = 0;
    }



    //[Fact]
    public void DeleteSerieDirectoryOrCreateNewTest()
    {
        string folder = @"D:\_Test\sunamo\Helpers\FileSystem\DeleteSerieDirectoryOrCreateNew\";
        FS.DeleteSerieDirectoryOrCreateNew(folder);
    }

    //[Fact]
    public void AllExtensionsInFolders()
    {
        string folder = @"D:\_Test\sunamo\Helpers\FileSystem\FS\AllExtensionsInFolders\";
        var excepted = CA.ToListString(".html", ".bowerrc", ".php");
        var actual = FS.AllExtensionsInFolders(System.IO.SearchOption.TopDirectoryOnly, folder);
        Assert.Equal<string>(excepted, actual);
    }

    //[Fact]
    public void DeleteEmptyFilesTest()
    {
        string folder = @"D:\_Test\sunamo\Helpers\FileSystem\FS\DeleteEmptyFiles\";
        FS.DeleteEmptyFiles(folder, System.IO.SearchOption.TopDirectoryOnly);
        List<string> actual = FS.OnlyNamesNoDirectEdit(FS.GetFiles(folder));
        List<string> excepted = CA.ToListString("ab.txt", "DeleteEmptyFiles.zip");
        Assert.Equal(excepted, actual);

    }

    //[Fact]
    public void DeleteFilesWithSameContent()
    {
        string folder = @"D:\_Test\sunamo\Helpers\FileSystem\FS\DeleteFilesWithSameContent\";

        var files = FS.GetFiles(folder, "*.txt", System.IO.SearchOption.AllDirectories, new GetFilesArgs { _trimA1AndLeadingBs = true });
        FS.DeleteFilesWithSameContent(files);

        files = FS.GetFiles(folder, "*.txt", System.IO.SearchOption.AllDirectories, new GetFilesArgs { _trimA1AndLeadingBs = true });

        var filesExcepted = CA.ToListString(TestDataTxt.a, TestDataTxt.ab);
        Assert.Equal<string>(filesExcepted, files);
    }

    //[Fact]
    public void DeleteFilesWithSameContentBytes()
    {
        string folder = @"D:\_Test\sunamo\Helpers\FileSystem\FS\DeleteFilesWithSameContentBytes\";

        var files = FS.GetFiles(folder, "*.txt", System.IO.SearchOption.AllDirectories, new GetFilesArgs { _trimA1AndLeadingBs = false });
        FS.DeleteFilesWithSameContentBytes(files);

        files = FS.GetFiles(folder, "*.txt", System.IO.SearchOption.AllDirectories, new GetFilesArgs { _trimA1AndLeadingBs = true });

        var filesExcepted = CA.ToListString(TestDataTxt.a, TestDataTxt.ab);
        Assert.Equal<string>(filesExcepted, files);
    }

    //[Fact]
    public void DeleteAllEmptyDirectoriesTest()
    {
        string folder = @"D:\_Test\sunamo\sunamo\Helpers\FileSystem\FS\DeleteAllEmptyDirectories\";

        FS.DeleteAllEmptyDirectories(folder);


        int actual = FS.GetFolders(folder, SearchOption.AllDirectories).Count;
        Assert.Equal(2, actual);
    }
}
