namespace SunamoCollectionsGeneric.Collections;


/// <summary>
/// Checking whether string is already contained.
/// </summary>
public class PpkOnDrive : PpkOnDriveBase<string>
{
    public bool removeDuplicates = false;

    static PpkOnDrive wroteOnDrive = null;
    public static PpkOnDrive WroteOnDrive
    {
        get
        {
            if (wroteOnDrive == null)
            {
                wroteOnDrive = new PpkOnDrive(AppData.ci.GetFile(AppFolders.Logs, "WrittenFiles.txt"));
            }
            return wroteOnDrive;
        }
    }

    public void Load(string file)
    {
        a.file = file;
        Load();
    }

    public override
#if ASYNC
    async Task
#else
void
#endif
    Load()
    {
        if (FS.ExistsFile(a.file))
        {
            this.AddRange(
#if ASYNC
            await
#endif
            TFSE.ReadAllLines(a.file));

            CA.RemoveStringsEmpty2(this);

            if (removeDuplicates)
            {
                CAG.RemoveDuplicitiesList<string>(this);
            }
        }
    }

    public PpkOnDrive(PpkOnDriveArgs a) : base(a)
    {
    }

    public PpkOnDrive(string file2, bool load = true) : base(new PpkOnDriveArgs { file = file2, load = load })
    {
    }

    public PpkOnDrive(string file, bool load, bool save) : base(new PpkOnDriveArgs { file = file, load = load, save = save })
    {
    }
}
