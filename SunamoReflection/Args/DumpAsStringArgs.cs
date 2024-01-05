using SunamoReflection.Enums;

namespace SunamoReflection.Args;

/// <summary>
/// U��v� se v SunamoReflection+SUnamoLogger
/// </summary>
public class DumpAsStringArgs : DumpAsStringHeaderArgs
{
    public string name = string.Empty;
    public object o;
    public DumpProvider d = DumpProvider.Yaml;
    /// <summary>
    /// Good for fast comparing objects
    /// </summary>
    public bool onlyValues;
    public string deli = " - ";
}
