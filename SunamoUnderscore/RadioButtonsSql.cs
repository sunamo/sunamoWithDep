namespace SunamoUnderscore;

/// < summary>
///     Musí to tu být i když to je v Sql kvůli interfacům
///     Musí být object, IDatabasesConnections je static v _
///     Tím že je static property ji nemůžu dát typové argumenty
///
/// mohl bych RadioButtonsSql přendat do desktop
/// tím bych si ale porušil název na který se odkazuje protože _ může být jen v SunamoException (je bez _)
/// Ale UseWpf nechci dávat do všech.
/// Přikloním se k variantě, že přepínat to budu ale jinak než že budu mít RB v _.
/// </summary>
public class RadioButtonsSql
{
    public bool cmd = false;
    public bool sunamoCz;
    public bool sunamoNet;
    public bool weBelieve;
}
