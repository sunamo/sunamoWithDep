namespace SunamoShared.Essential;



public class WebApp
{
    public static Langs l = Langs.en;
    public static ResourcesHelper Resources;
    public static string Name;
    public static readonly bool initialized = false;
    public static string Namespace = "";
    public static event SetStatusDelegate StatusSetted;



    public static void SetStatus(TypeOfMessage st, string status, params string[] args)
    {
        StatusSetted(st, SH.Format2(status, args));
    }
}
