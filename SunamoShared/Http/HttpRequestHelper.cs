namespace SunamoShared.Http;


/// <summary>
/// Náhrada za třídu NetHelper
/// Can be only in shared coz is not available in standard
/// </summary>
public static partial class HttpRequestHelper
{
    public static IProgressBar clpb = null;

    public static bool IsNotFound(object uri)
    {
        HttpWebResponse r;
        var test = GetResponseText(uri.ToString(), HttpMethod.Get, null, out r);

        return HttpResponseHelper.IsNotFound(r);
    }

    public static bool SomeError(object uri)
    {
        HttpWebResponse r;
        var test = GetResponseText(uri.ToString(), HttpMethod.Get, null, out r);

        return HttpResponseHelper.SomeError(r);
    }

    static Type type = typeof(HttpRequestHelper);

    /// <summary>
    /// A2 can be null (if dont have duplicated extension, set null)
    /// </summary>
    /// <param name="hrefs"></param>
    /// <param name="DontHaveAllowedExtension"></param>
    /// <param name="folder2"></param>
    /// <param name="co"></param>
    /// <param name="ext"></param>
    public static int DownloadAll(List<string> hrefs, BoolString DontHaveAllowedExtension, string folder2, FileMoveCollisionOption co, string ext = "")
    {
        int reallyDownloaded = 0;

        clpb.LyricsHelper_OverallSongs(hrefs.Count);

        foreach (var item in hrefs)
        {
            clpb.LyricsHelper_AnotherSong();

            var tempPath = FS.GetTempFilePath();

            var partsUri = SHSplit.Split(item, AllStrings.slash);

            var to = Path.Combine(folder2, string.Join(AllStrings.bs, partsUri.TakeLast(2)) + ext);

            switch (co)
            {
                case FileMoveCollisionOption.AddSerie:
                case FileMoveCollisionOption.AddFileSize:
                case FileMoveCollisionOption.Overwrite:
                case FileMoveCollisionOption.DiscardFrom:
                case FileMoveCollisionOption.LeaveLarger:
                    break;
                case FileMoveCollisionOption.DontManipulate:
                    if (FS.ExistsFile(to))
                    {
                        continue;
                    }
                    break;
                default:
                    ThrowEx.NotImplementedCase(co);
                    break;
            }

            Download(item, DontHaveAllowedExtension, tempPath);
            reallyDownloaded++;

            FS.MoveFile(tempPath, to, co);
        }

        clpb.LyricsHelper_WriteProgressBarEnd();

        return reallyDownloaded;
    }

    /// <summary>
    /// A2 can be null (if dont have duplicated extension, set null)
    /// In earlier time return ext
    /// Now return whether was downloaded
    /// </summary>
    /// <param name = "href"></param>
    /// <param name = "DontHaveAllowedExtension"></param>
    /// <param name = "folder2"></param>
    /// <param name = "fn"></param>
    /// <param name = "ext"></param>
    public static bool Download(string href, BoolString DontHaveAllowedExtension, string folder2, string fn, int timeoutInMs, string ext = null)
    {
        // TODO: měl jsem tu arg , string fullPathForCompare
        // zkontrolovat zda se tu ta cesta skládá správně
        // přidání nového arg do prostřed to zurví spoustu dalšího kódu

        if (DontHaveAllowedExtension != null)
        {
            if (DontHaveAllowedExtension(ext))
            {
                ext += ".jpeg";
            }
        }

        if (string.IsNullOrWhiteSpace(ext))
        {
            ext = Path.GetExtension(href);
            ext = SH.RemoveAfterFirst(ext, AllChars.q);
        }

        fn = SH.RemoveAfterFirst(fn, AllChars.q);
        string path = Path.Combine(folder2, fn + ext);

        //if (path != fullPathForCompare)
        //{
        //    Debugger.Break();
        //}

        FS.CreateFoldersPsysicallyUnlessThere(folder2);

        if (!FS.ExistsFile(path) || FS.GetFileSize(path) == 0)
        {
            var c = HttpRequestHelper.GetResponseBytes(href, HttpMethod.Get, timeoutInMs);

            if (c.Length != 0)
            {
                TF.WriteAllBytesArray(path, c);
                return true;
            }
        }

        return false;
    }

    static string ShortPathFromUri(string s)
    {
        #region Nefungovalo, furt to bylo příliš dlouhé
        //s = SH.KeepAfterFirst(s, "://");
        //s = SH.KeepAfterFirst(s, "www.");
        //// Abych ušetřil ještě nějaké místo, nebudu vkládat ani host
        //s = SH.KeepAfterFirst(s, "/");

        /*
         * Z nějakého důvodu, když to dekóduji, tak mi C# nedokáže zapsat soubor s tímto názvem
         * Ale VSCode to zvládne v pohodě: \\?\D:\Documents\sunamo\ConsoleApp1\Cache\sprodejdomycena-do-1000000moravskoslezsky-krajs-qc[usableAreaMin]=40&s-qc[ownership][0]=personal&s-qc[condition][0]=new&s-qc[condition][1]=good-condition&s-qc[condition][2]=maintained&s-qc[condition][3]=after-reconstruction.html
         * Píše to že část cesty neexistuje ale žádné \ ani / v tom není a D:\Documents\sunamo\ConsoleApp1\Cache\ existuje
         *
         * Kdybych měl s tím znovu problemy, udělat to že string se převede na hash
         * Případně že se zapíšou jen hodnoty parametrů, nikoliv jejich názvy, oddělené ,
         * */
        //s = UH.UrlDecode(s);

        //s = FS.ReplaceInvalidFileNameChars(s);
        #endregion

        #region Část kódu kretá se používala když jsem vracel fn
        var v = UH.GetFileNameWithoutExtension(s);
        var qs = UH.GetQueryAsHttpRequest(new Uri(s));

        StringBuilder sb = new StringBuilder();
        var p = SHSplit.Split(qs, "&");
        foreach (var item in p)
        {
            sb.Append(SHSplit.Split(item, "=")[1] + ",");
        }

        s = FS.ReplaceInvalidFileNameChars(v + sb.ToString());
        #endregion

        return s;
    }

    /// <summary>
    /// In earlier time return ext
    /// Now return whether was downloaded
    /// </summary>
    /// <param name="uri"></param>
    /// <param name="DontHaveAllowedExtension"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public static bool Download(string uri, BoolString DontHaveAllowedExtension, string path)
    {
        string p, fn, ext;

        FS.GetPathAndFileNameWithoutExtension(path, out p, out fn, out ext);

        var ext2 = Path.GetExtension(path);
        var downloaded = Download(uri, /*path,*/ null, p, fn, 1000, ext2);

        // TODO: měl jsem tu arg , string fullPathForCompare
        // zkontrolovat zda se tu ta cesta skládá správně
        // přidání nového arg do prostřed to zurví spoustu dalšího kódu

        return downloaded;
    }
}
