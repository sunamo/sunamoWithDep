namespace SunamoPlatformUwpInterop.AppData;


public partial class AppData : AppDataAbstractBase<string, string>
{
    public static AppData ci = new AppData();
    static Type type = typeof(AppData);

    private AppData()
    {

    }

    public override string GetSunamoFolder()
    {
        return sunamoFolder;
    }

    public override string GetFileInSubfolder(AppFolders output, string subfolder, string file, string ext)
    {
        return AppData.ci.GetFile(AppFolders.Output, subfolder + @"\" + file + ext);
    }

    /// <summary>
    /// Return always in User's AppData
    /// </summary>
    /// <param name="inFolderCommon"></param>
    public override string RootFolderCommon(bool inFolderCommon)
    {
        //string appDataFolder = SpecialFO
        string sunamo2 = Path.Combine(SpecialFoldersHelper.AppDataRoaming(), Consts.@sunamo);
        var redirect = GetSunamoFolder();
        if (!string.IsNullOrEmpty(redirect))
        {
            sunamo2 = redirect;
        }
        if (inFolderCommon)
        {
            return Path.Combine(sunamo2, XlfKeys.Common);
        }

        return sunamo2;
    }

    public override string GetFileString(string af, string file, bool pa = false)
    {
        string slozka2, soubor;

        // if (Exc.aspnet)
        // {
        //     slozka2 = Path.Combine(basePath, af.ToString());
        //     soubor = Path.Combine(slozka2, file);
        //     return soubor;
        // }
        // else
        // {
        var rf = RootFolder;
        if (pa)
        {
            rf = RootFolderPa;
        }

        slozka2 = Path.Combine(rf, af.ToString());
        soubor = Path.Combine(slozka2, file);
        return soubor;
        //}
    }

    public string GetFileString(string af, string file)
    {
        return GetFileString(af, file, false);
    }

    public override string GetFile(AppFolders af, string file)
    {
        return GetFileString(af.ToString(), file);
    }

    public string GetFileAppTypeAgnostic(AppFolders af, string file)
    {
        return GetFileString(af.ToString(), file, true);
    }

    public override string GetFolder(AppFolders af)
    {
        var f = RootFolder;
        // if (Exc.aspnet)
        // {
        //     f = basePath;
        // }

        string vr = Path.Combine(f, af.ToString());
        FS.WithEndSlash(ref vr);
        return vr;
    }

    public override bool IsRootFolderOk()
    {
        if (string.IsNullOrEmpty(rootFolder))
        {
            return false;
        }

        return FS.ExistsDirectory(rootFolder);
    }






    /// <summary>
    /// Bylo by fajn si napsat kdy se rootFolder nastavuje volá abych příště mohl rychleji chybu opravit
    ///
    /// Nastvuje se v GetRootFolder jež se volá pouze v CreateAppFoldersIfDontExists
    ///
    /// </summary>
    /// <returns></returns>
    public override bool IsRootFolderNull()
    {
        var def = default(string);
        if (!EqualityComparer<string>.Default.Equals(rootFolder, def))
        {
            // is not null
            return rootFolder == string.Empty;
        }
        return true;
    }

    public override
#if ASYNC
    async Task
#else
void
#endif
    AppendAllText(string content, string sf)
    {

#if ASYNC
        await
#endif
        TFSE.AppendAllText(sf, content);
    }

    public string GetRootFolderForApp(string rootFolderFromCreatedAppData, string app)
    {
        return Path.Combine(FS.GetDirectoryName(rootFolderFromCreatedAppData), app);
    }

    public override string GetRootFolder()
    {
        rootFolder = GetSunamoFolder();

        //pa ? SH.RemoveAfterFirst(ThisApp.Name, AllChars.dot) :
        RootFolder = Path.Combine(rootFolder, ThisApp.Name);
        RootFolderPa = Path.Combine(FS.GetDirectoryName(rootFolder), SH.RemoveAfterFirstChar(ThisApp.Name, AllChars.dot));
        FS.CreateDirectory(RootFolder);
        FS.CreateDirectory(RootFolderPa);
        return RootFolder;
    }

    /// <summary>
    /// Zůstane to pojmenované SaveFile protože mám tu další metoday Save*
    /// </summary>
    /// <param name="content"></param>
    /// <param name="sf"></param>
    /// <returns></returns>
    protected override
#if ASYNC
    async Task
#else
void
#endif
    SaveFile(string content, string sf)
    {

#if ASYNC
        await
#endif
        TFSE.WriteAllText(sf, content);
    }

    public override
#if ASYNC
    async Task
#else
void
#endif
    AppendAllText(AppFolders af, string file, string value)
    {
        ThrowEx.NotImplementedMethod();
    }


    /// <summary>
    /// Dont use - instead of this GetCommonSettings
    /// Without ext because all is crypted and in bytes
    /// Folder is possible to obtain A1 = null
    /// </summary>
    /// <param name="filename"></param>
    public override string GetFileCommonSettings(string filename)
    {
        var fc = RootFolderCommon(true);
        var vr = Path.Combine(fc, AppFolders.Settings.ToString(), filename);
        return vr;
    }





    public override void SetCommonSettings(string key, string value)
    {
        var file = GetFileCommonSettings(key);
        TFSE.WriteAllBytes(file, _.RijndaelBytesEncrypt(Encoding.UTF8.GetBytes(value).ToList()));
    }


}
