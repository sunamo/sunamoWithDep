namespace SunamoInterfaces.Interfaces;

public interface IConvertShortcutFullName
{
    string FromShortcut(string shortcut);
    string ToShortcut(string fullName);
}
