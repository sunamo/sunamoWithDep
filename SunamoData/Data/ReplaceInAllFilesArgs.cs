namespace SunamoData.Data;

/// <summary>
/// Is passed into ReplaceInAllFilesWorker
/// </summary>
public class ReplaceInAllFilesArgs : ReplaceInAllFilesArgsBase
{
    public string from;
    public string to;
    public bool pairLinesInFromAndTo;
    public bool replaceWithEmpty;
    public bool isNotReplaceInTemporaryFiles;

    public ReplaceInAllFilesArgs()
    {

    }

    public ReplaceInAllFilesArgs(ReplaceInAllFilesArgsBase b)
    {
        files = b.files;
        isMultilineWithVariousIndent = b.isMultilineWithVariousIndent;

        writeEveryReadedFileAsStatus = b.writeEveryReadedFileAsStatus;
        writeEveryWrittenFileAsStatus = b.writeEveryWrittenFileAsStatus;
        fasterMethodForReplacing = b.fasterMethodForReplacing;

        inGitFiles = b.inGitFiles;
        inDownloadedFolders = b.inDownloadedFolders;
        inFoldersToDelete = b.inFoldersToDelete;

        dRemoveGitFiles = b.dRemoveGitFiles;
    }
}

/// <summary>
/// Is passed into ReplaceInAllFiles
/// </summary>
public class ReplaceInAllFilesArgsBase
{
    public List<string> files;
    public bool isMultilineWithVariousIndent;

    public bool writeEveryReadedFileAsStatus;
    public bool writeEveryWrittenFileAsStatus;
    public Func<StringBuilder, IList<string>, IList<string>, StringBuilder> fasterMethodForReplacing;

    public bool inGitFiles;
    public bool inDownloadedFolders;
    public bool inFoldersToDelete;

    public Action<List<string>, bool, bool, bool> dRemoveGitFiles;
}
