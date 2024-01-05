namespace SunamoData.Data;

/// <summary>
///
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
public abstract class Parsing<T1, T2>
{
    public T1 t1 = default;
    public T2 t2 = default;
    public abstract void ParsujM(string obsah);
}
