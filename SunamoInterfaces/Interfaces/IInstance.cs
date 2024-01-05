namespace SunamoInterfaces.Interfaces;

public interface IInstance<T>
{
    T CreateInstance(object o);
}
