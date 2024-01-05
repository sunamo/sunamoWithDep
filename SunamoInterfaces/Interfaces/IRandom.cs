namespace SunamoInterfaces.Interfaces;

public interface IRandom<T>
{
    T GetRandom();
    int LenghtOfPpk { get; }
}
