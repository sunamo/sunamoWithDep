namespace SunamoShared.Value;

public class GeoCzechRegion
{
    public GeoCzechRegion(string shortcutRZ, string name, string shortcutCSU, string mainCity)
    {
        ShortcutRZ = shortcutRZ;
        ShortcutCSU = shortcutCSU;
        Name = name;
        MainCity = mainCity;
    }

    public string ShortcutRZ { get; set; }
    public string ShortcutCSU { get; set; }
    public string Name { get; set; }
    public string MainCity { get; set; }
}
