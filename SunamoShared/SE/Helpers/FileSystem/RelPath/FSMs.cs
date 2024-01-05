namespace SunamoShared.SE.Helpers.FileSystem.RelPath;

//public partial class FS
//{
//    #region

//    /// <summary>
//    /// if A3, A1 must be always file
//    /// 
//    /// Can enter with/without end backslash
//    /// 
//    ///     Create a relative path from one path to another. Paths will be resolved before calculating the difference.
//    ///     Default path comparison for the active platform will be used (OrdinalIgnoreCase for Windows or Mac, Ordinal for
//    ///     Unix).
//    /// </summary>
//    /// <param name="relativeTo">
//    ///     The source path the output should be relative to. This path is always considered to be a
//    ///     directory.
//    /// </param>
//    /// <param name="path">The destination path.</param>
//    /// <returns>The relative path or <paramref name="path" /> if the paths don't share the same root.</returns>
//    /// <exception cref="ArgumentNullException">
//    ///     Thrown if <paramref name="relativeTo" /> or <paramref name="path" /> is
//    ///     <c>null</c> or an empty string.
//    /// </exception>
//    public static string GetRelativePath(string relativeTo, string path, bool dontGoToUpFolderIfItIsNotNeeded = false)
//    {
//        var result2 = System.IO.Path.GetRelativePath(relativeTo, path);

//        if (dontGoToUpFolderIfItIsNotNeeded)
//        {
//            if (FS.IsFileHasKnownExtension(relativeTo))
//            {
//                var rp = FS.GetDirectoryName(relativeTo);
//                if (path.StartsWith(rp))
//                {
//                    path = SHReplace.ReplaceOnce(path, rp, Consts.se);
//                    return ".\\" + path;
//                }
//            }
//        }

//        return result2;

//        //SH.TrimEnd(relativeTo.)

//        var result = GetRelativePath(relativeTo, path, PathInternal.StringComparison);

//        /*
//         * 2-6-2023
//Pokud bych zadával cestu rel.ke složce, vše je oK
//Jakmile zadám cestu rel. k souboru, mám o 1 ../ navíc 
//proto vždy ořežu
//         */

//        if (FS.ExistsFile(relativeTo))
//        {
//            result = result.Substring(3);
//        }
//        return result;
//    }

//    public static readonly char DirectorySeparatorChar = PathInternal.DirectorySeparatorChar;

//    public static List<string> lse = new List<string>();


//    private static string GetRelativePath(string relativeTo, string path, StringComparison comparisonType)
//    {
//        if (relativeTo == null)
//        {
//            throw new ArgumentNullException(nameof(relativeTo));
//        }

//        if (!IsAbsolutePath(path))
//        {
//            lse.Add(path);
//            return path;
//        }

//        if (path == null)
//        {
//            throw new ArgumentNullException(nameof(path));
//        }

//        string removedFnRelativeTo = string.Empty;
//        string removedFnPath = string.Empty;

//        // TODO: nev�m jestli jsou tyhle 2 ify pot�eba. funk�nost byla ve SunamoExceptions ale proto�e jsem se ho rozhodl zm�nit z d�vodu neudr�itelnosti, u� to tam nen�
//        // pokud by to bylo nutn�, ud�lat to p�es DI
//        //if (FS.IsFileHasKnownExtension(relativeTo))
//        //{
//        //    removedFnRelativeTo = FS.GetFileName(relativeTo);
//        //    relativeTo = FS.GetDirectoryName(relativeTo);
//        //}
//        //if (FS.IsFileHasKnownExtension(path))
//        //{
//        //    removedFnPath = FS.GetFileName(path);
//        //    path = FS.GetDirectoryName(path);
//        //}

//        relativeTo = GetFullPath(relativeTo);
//        path = GetFullPath(path);

//        // Need to check if the roots are different- if they are we need to return the "to" path.
//        if (!PathInternal.AreRootsEqual(relativeTo, path, comparisonType))
//        {
//            return path;
//        }

//        int commonLength = PathInternal.GetCommonPathLength(relativeTo, path,
//            comparisonType == StringComparison.OrdinalIgnoreCase);

//        // If there is nothing in common they can't share the same root, return the "to" path as is.
//        if (commonLength == 0)
//        {
//            return Path.Combine(path.Replace(relativeTo, string.Empty).TrimStart(AllCharsSE.bs), removedFnPath);
//        }

//        // Trailing separators aren't significant for comparison
//        int relativeToLength = relativeTo.Length;
//        if (EndsInDirectorySeparator(relativeTo.AsSpan()))
//        {
//            relativeToLength--;
//        }

//        bool pathEndsInSeparator = EndsInDirectorySeparator(path.AsSpan());
//        int pathLength = path.Length;
//        if (pathEndsInSeparator)
//        {
//            pathLength--;
//        }

//        // If we have effectively the same path, return "."
//        if (relativeToLength == pathLength && commonLength >= relativeToLength)
//        {
//            return ".";
//        }

//        // We have the same root, we need to calculate the difference now using the
//        // common Length and Segment count past the length.
//        //
//        // Some examples:
//        //
//        //  C:\Foo C:\Bar L3, S1 -> ..\Bar
//        //  C:\Foo C:\Foo\Bar L6, S0 -> Bar
//        //  C:\Foo\Bar C:\Bar\Bar L3, S2 -> ..\..\Bar\Bar
//        //  C:\Foo\Foo C:\Foo\Bar L7, S1 -> ..\Bar

//        StringBuilder sb = new StringBuilder();
//        //var sb = new ValueStringBuilder(stackalloc char[260]);
//        //sb.EnsureCapacity(Math.Max(relativeTo.Length, path.Length));

//        // Add parent segments for segments past the common on the "from" path
//        if (commonLength < relativeToLength)
//        {
//            sb.Append("..");

//            for (int i = commonLength + 1; i < relativeToLength; i++)
//            {
//                if (PathInternal.IsDirectorySeparator(relativeTo[i]))
//                {
//                    sb.Append(DirectorySeparatorChar);
//                    sb.Append("..");
//                }
//            }
//        }
//        else if (PathInternal.IsDirectorySeparator(path[commonLength]))
//        {
//            // No parent segments and we need to eat the initial separator
//            //  (C:\Foo C:\Foo\Bar case)
//            commonLength++;
//        }

//        // Now add the rest of the "to" path, adding back the trailing separator
//        int differenceLength = pathLength - commonLength;
//        if (pathEndsInSeparator)
//        {
//            differenceLength++;
//        }

//        if (differenceLength > 0)
//        {
//            if (sb.Length > 0)
//            {
//                sb.Append(DirectorySeparatorChar);
//            }

//            sb.Append(path.AsSpan(commonLength, differenceLength).ToString());
//        }

//        return Path.Combine(sb.ToString(), removedFnPath);
//    }


//    public static bool IsAbsolutePath(string path)
//    {
//        return !string.IsNullOrWhiteSpace(path)
//               && path.IndexOfAny(Path.GetInvalidPathChars()) == -1
//               && Path.IsPathRooted(path)
//               && !Path.GetPathRoot(path).Equals(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal);
//    }

//    /// <summary>
//    ///     Returns true if the path ends in a directory separator.
//    /// </summary>
//    public static bool EndsInDirectorySeparator(ReadOnlySpan<char> path)
//    {
//        return PathInternal.EndsInDirectorySeparator(path);
//    }

//    //public static string Postfix(string arg1, string v)
//    //{
//    //    arg1 = arg1.TrimEnd(AllCharsSE.bs) + v + AllStringsSE.bs;
//    //    return arg1;
//    //}

//    #endregion
//}
