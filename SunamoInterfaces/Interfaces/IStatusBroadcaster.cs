namespace SunamoInterfaces.Interfaces;

public interface IStatusBroadcaster
{
    event Action<object, Object[]> NewStatus;
    void OnNewStatus(string s, params string[] p);
}

/// <summary>
/// Dědí zároveň rozhraní IStatusBroadcaster, jen k němu přidává metodu a událost pro přidání ke stávajícímu obsahu statusu
/// </summary>
public interface IStatusBroadcasterAppend : IStatusBroadcaster
{
    event Action<object, Object[]> NewStatusAppend;
    void OnNewStatusAppend(string s, params string[] p);
}
