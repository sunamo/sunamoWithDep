namespace SunamoEnums.Enums;


/// <summary>
/// Cant name Action , in ns too. 
/// </summary>
public enum ButtonAction
{
    Nope,
    Remove,
    SaveToClipboard,
    Run
}
public delegate void VoidAction(ButtonAction action);
