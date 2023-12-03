/// <summary>
/// Right format of paths are:
/// D:\_Test\SunamoCzAdmin\SunamoCzAdmin.Wpf\ConvertMetroCss3To4\
/// D:\_Test\SunamoCzAdmin\SunamoCzAdmin.Wpf\ConvertMetroCss3To4_Original\
/// </summary>
public class TestHelper
{
    public static void Init()
    {
        Init("sunamo");
    }

    public static void Init(string appName)
    {
        ThisApp.Name = appName;
        ThisApp.Project = appName;

        // Dont - XlfResourcesH - error 'Could not load file or assembly 'System.Security.Principal.Windows, Version=4.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a' or one of its dependencies. The system cannot find the file specified.'
        //XlfResourcesH.SaveResouresToRL(VpsHelperSunamo.SunamoProject());
        // OK XlfResourcesHSunamo
        XlfResourcesHSunamo.SaveResouresToRLSunamo(new sunamo.Data.LocalizationLanguages { });

        //AppData.ci.GetFolderWithAppsFiles();
        //AppData.ci.GetRootFolder();
        AppData.ci.CreateAppFoldersIfDontExists(new CreateAppFoldersIfDontExistsArgs { });

    }

    public static string DefaultFolderPath()
    {
        string appName = ThisApp.Name;
        string project = ThisApp.Project;

        string folderFrom = @"D:\_Test\" + appName + "\\" + project;
        return folderFrom;
    }

    /// <summary>
    /// A1 can be null, then will be joined default like D:\_Test\AllProjectsSearch\AllProjectsSearch\ by DefaultFolderPath()
    /// A2 can be slashed or backslashed. Will be appended to A1.
    /// To A2 will be add _Original automatically
    /// A3 is append after folder and folderFrom (with _Original\). can be null or SE
    ///
    /// A5 whether replace _Original in non original Folder
    /// </summary>
    /// <param name="appName"></param>
    /// <param name="featureOrType"></param>
    public static
#if ASYNC
    async Task<List<string>>
#else
    List<string>
#endif
 RefreshOriginalFiles(string baseFolder, object featureOrType, string modeOfFeature, bool copyFilesRecursively, bool replace_Original)
    {
        if (baseFolder == null)
        {
            baseFolder = DefaultFolderPath();
        }

        string feature = NameOfFeature(featureOrType);

        FS.WithoutEndSlash(ref baseFolder);
        baseFolder = baseFolder + "\\" + feature;
        var folderFrom = baseFolder + "_Original\\";
        string folder = baseFolder + "\\";

        if (!string.IsNullOrEmpty(modeOfFeature))
        {
            modeOfFeature = modeOfFeature.TrimEnd('\\') + "\\";
            folderFrom += modeOfFeature;
            folder += modeOfFeature;
        }

        FS.GetFiles(folder, copyFilesRecursively).ToList().ForEach(d => FS.TryDeleteFile(d));
        if (copyFilesRecursively)
        {
            FS.CopyAllFilesRecursively(folderFrom, folder, FileMoveCollisionOption.Overwrite);
        }
        else
        {
            FS.CopyAllFiles(folderFrom, folder, FileMoveCollisionOption.Overwrite);
        }

        var files = FS.GetFiles(folder);

        if (replace_Original)
        {
            const string _Original = "_Original";

            for (int i = 0; i < files.Count; i++)
            {
                var item = files[i];
                var item2 = item;
                var c =
#if ASYNC
    await
#endif
 TF.ReadAllText(item);
                // replace in content
                c = SH.Replace(c, _Original, string.Empty);

#if ASYNC
                await
#endif
                TF.WriteAllText(item2, c);

                if (item2.Contains(_Original))
                {
                    string newFile = item2.Replace(_Original, string.Empty);
                    FS.MoveFile(item2, newFile, FileMoveCollisionOption.Overwrite);
                    files[i] = newFile;
                }
            }
        }
        return files;
    }

    /// <summary>
    /// A1 can be Type, string or any object, then is as name take name of it's class
    /// </summary>
    /// <param name="featureOrType"></param>
    private static string NameOfFeature(object featureOrType)
    {
        string feature = null;
        if (featureOrType is Type)
        {
            feature = (featureOrType as Type).Name;
        }
        else if (featureOrType is string)
        {
            return featureOrType.ToString();
        }
        else
        {
            feature = featureOrType.GetType().Name;
        }

        return feature;
    }

    /// <summary>
    /// Get backslashed
    /// </summary>
    /// <param name="featureOrType"></param>
    public static string FolderForTestFiles(object featureOrType)
    {
        string feature = NameOfFeature(featureOrType);

        string appName = ThisApp.Name;
        string project = ThisApp.Project;

        var f = @"D:\_Test\" + appName + "\\" + project + SH.WrapWith(feature, AllChars.bs, true);
        FS.CreateFoldersPsysicallyUnlessThere(f);
        return f;
    }



    public static string TestFile(object featureOrType, string fn)
    {
        return FS.Combine(FolderForTestFiles(featureOrType), fn);
    }

    /// <summary>
    ///
    /// Path will be combined with ThisApp.Name and ThisApp.Project
    /// </summary>
    public static string GetFileInProjectsFolder(string fileRelativeToProjectPath)
    {
        return FS.Combine(DefaultPaths.vsProjects, ThisApp.Name, ThisApp.Project, fileRelativeToProjectPath);
    }
}
