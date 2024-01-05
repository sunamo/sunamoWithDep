namespace SunamoShared.Helpers.Runtime;

public partial class PlatformInteropHelper
{
    static bool? isUwp = null;

    /// <summary>
    /// Working excellent 11-3-19
    /// </summary>
    public static bool IsUwpWindowsStoreApp()
    {
        if (isUwp.HasValue)
        {
            return isUwp.Value;
        }

        var ass = AppDomain.CurrentDomain.GetAssemblies();
        foreach (var item in ass)
        {
            Type[] types = null;
            try
            {
                types = item.GetTypes();
            }
            catch (Exception ex)
            {
                ThrowEx.DummyNotThrow(ex);
            }

            if (types != null)
            {
                foreach (var type in types)
                {
                    if (type.Namespace != null)
                    {
                        if (type.Namespace.StartsWith("Windows.UI"))
                        {
                            isUwp = true;
                            break;
                        }
                    }
                }

                if (isUwp.HasValue)
                {
                    break;
                }
            }
        }

        if (!isUwp.HasValue)
        {
            isUwp = false;
        }

        return isUwp.Value;
    }

    public static Type GetTypeOfResources()
    {
        throw new Exception();
        return null;
        //return typeof(Resources.ResourcesDuo);
    }
}
