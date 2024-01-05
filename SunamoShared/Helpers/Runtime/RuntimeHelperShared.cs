namespace SunamoShared.Helpers.Runtime;

public partial class RuntimeHelper{ 
public static bool IsAdminUser()
    {
        return FS.ExistsDirectory(@"E:\vs\sunamo\");
    }

    
}
