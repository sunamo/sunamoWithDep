namespace SunamoValues.Values;

public class TypesControlsSunamo
{
    /// <summary>
    /// Is initialized directly in PathEditor to avoid referencing not used assembly
    /// In default is type's object to avoid exception in waterfall type checking
    /// </summary>
    public static Type tPathEditor = typeof(object);
    public const string CheckBoxListUC = "desktop.Controls.Collections.CheckBoxListUC";
}
