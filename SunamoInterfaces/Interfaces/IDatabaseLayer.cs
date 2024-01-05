namespace SunamoInterfaces.Interfaces;

/// <summary>
/// Must be in sunamo because is shared between MSSQl and SQL Server project
/// </summary>
/// <typeparam name="SqlDbType"></typeparam>
public interface IDatabaseLayer<SqlDbType>
{
    Dictionary<SqlDbType, string> usedTa { get; set; }
    Dictionary<SqlDbType, string> hiddenTa { get; set; }

}
