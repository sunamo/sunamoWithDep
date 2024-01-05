namespace SunamoShared.SE;
///// <summary>
/////     FSXlf - postfixy jsou píčovina. volám v tom metody stejné třídy. Můžu nahradit FS. v SunExc ale musel bych to
/////     zkopírovat zpět. to nese riziko že jsem přidal novou metodu kterou bych překopírováním ztratil. Krom toho to nedrží
/////     konvenci. V názvu souboru to nechám ať vidím na první dobrou co je co.
///// </summary>
//public partial class FS
//{
//    public static List<string> GetFiles(string path, string v, SearchOption topDirectoryOnly)
//    {
//        return Directory.GetFiles(path, v, topDirectoryOnly).ToList();
//    }

//    public static string Combine(params string[] c)
//    {
//        return Path.Combine(c);
//    }

//    public static void DeleteFile(string f)
//    {
//        File.Delete(f);
//    }

//    public static string GetFullPath(string path)
//    {
//        return Path.GetFullPath(path);
//    }

//    /// <summary>
//    ///     Usage: Exceptions.DirectoryExists
//    /// </summary>
//    /// <param name="nad"></param>
//    /// <returns></returns>
//    public static bool ExistsDirectory(string nad)
//    {
//        return Directory.Exists(nad);
//    }

//    /// <summary>
//    ///     Usage: Exceptions.FileWasntFoundInDirectory
//    /// </summary>
//    /// <param name="file"></param>
//    /// <returns></returns>
//    public static string GetFileName(string file)
//    {
//        return Path.GetFileName(file);
//    }

//    /// <summary>
//    ///     Usage: Exceptions.WrongExtension
//    /// </summary>
//    /// <param name="path"></param>
//    /// <returns></returns>
//    public static string GetExtension(string path)
//    {
//        return Path.GetExtension(path);
//    }

//    public static bool? ExistsDirectoryNull(string d)
//    {
//        return Directory.Exists(d);
//    }
//}
