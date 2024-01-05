namespace SunamoExceptions.InSunamoIsDerivedFrom;

public partial class TFSE
{
    public static Func<string, bool> isUsed = null;

    #region

    protected static bool LockedByBitLocker(string path)
    {
        return ThrowEx.LockedByBitLocker(path);
    }

    public static
#if ASYNC
    async Task<string>
#else
string
#endif
    ReadAllText(string path, Encoding enc)
    {
        if (isUsed != null)
            if (isUsed.Invoke(path))
                return string.Empty;

#if ASYNC
        //TFSE.await WaitD();
#endif

        //return enc == null ? File.ReadAllText(path) : File.ReadAllText(path, enc);

#if ASYNC
        return await File.ReadAllTextAsync(path, enc);
#else
return File.ReadAllText(path, enc);
#endif
    }

    #region Array

    public static
#if ASYNC
    async Task
#else
void
#endif
    WriteAllLinesArray(string path, string[] c)
    {
#if ASYNC
        await
#endif
        WriteAllLines(path, c.ToList());
    }

    public static
#if ASYNC
    async Task
#else
void
#endif
    WriteAllBytesArray(string path, byte[] c)
    {
#if ASYNC
        await
#endif
        WriteAllBytes(path, c.ToList());
    }

    public static
#if ASYNC
    async Task<byte[]>
#else
byte[]
#endif
    ReadAllBytesArray(string path)
    {
        return (
#if ASYNC
        await
#endif
        ReadAllBytes(path)).ToArray();
    }

    #endregion

    #region Bytes

    /// <summary>
    ///     Only one method where could be TFSE.ReadAllBytes
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public static
#if ASYNC
    async Task<List<byte>>
#else
List<byte>
#endif
    ReadAllBytes(string file)
    {
        if (LockedByBitLocker(file)) return new List<byte>();

#if ASYNC
        //await WaitD();
#endif

        return
#if ASYNC
        (await File.ReadAllBytesAsync(file)).ToList();
#else
File.ReadAllBytes(file).ToList();
#endif
    }

    public static
#if ASYNC
    async Task
#else
void
#endif
    WriteAllBytes(string file, List<byte> b)
    {
        if (LockedByBitLocker(file)) return;

#if ASYNC
        await File.WriteAllBytesAsync(file, b.ToArray());
#else
File.WriteAllBytes(file, b.ToArray());
#endif
    }

    #endregion

    #region Lines

    public static
#if ASYNC
    async Task
#else
void
#endif
    WriteAllLines(string file, IList<string> lines)
    {
        if (LockedByBitLocker(file)) return;

#if ASYNC
        await File.WriteAllLinesAsync
#else
File.WriteAllLines
#endif

        (file, lines.ToArray());
    }

    public static
#if ASYNC
    async Task<List<string>>
#else
List<string>
#endif
    ReadAllLines(string file, bool trim = true)

    {
        if (LockedByBitLocker(file)) return new List<string>();
#if ASYNC
        //await WaitD();
#endif

        var result =
#if ASYNC
        (await File.ReadAllLinesAsync(file)).ToList();
#else
File.ReadAllLines(file).ToList();
#endif
        if (trim) result = result.Where(d => !string.IsNullOrWhiteSpace(d)).ToList();

        return result;
    }

    #endregion

    #region Text

    public static
#if ASYNC
    async Task
#else
void
#endif
    WriteAllText(string path, string content)
    {
        if (LockedByBitLocker(path)) return;

#if ASYNC
        await File.WriteAllTextAsync(path, content);
#else
File.WriteAllText(path, content);
#endif
    }

    public static
#if ASYNC
    async Task<string>
#else
string
#endif
    ReadAllText(string f)
    {
        if (LockedByBitLocker(f)) return string.Empty;

#if ASYNC
        //await WaitD();
#endif
        try
        {
#if ASYNC
            return await File.ReadAllTextAsync(f);
#else
return File.ReadAllText(f);
#endif
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    public static
#if ASYNC
    async Task
#else
void
#endif
    AppendAllText(string path, string content)
    {
        if (LockedByBitLocker(path)) return;

#if ASYNC
        //await WaitD();
#endif
        try
        {
#if ASYNC
            await File.AppendAllTextAsync(path, content);
#else
File.AppendAllText(path, content);
#endif
        }
        catch (Exception)
        {
        }
    }

    #endregion

    #endregion

#if ASYNC
    public static async Task<string> WaitD()
    {
        /*
        Vůbec nevím proč tu mám tuto metodu
        ale protože WaitD jsem volal na více místech, nechám tu metodu tu jako prázdnou
        */
        return await Task.Run(() => "");
    }
#endif
}
