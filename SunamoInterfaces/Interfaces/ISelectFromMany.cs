namespace SunamoInterfaces.Interfaces;

public interface ISelectFromMany<Data>
{
    void AddControl(Data data, bool b);
    void AddControls();
}
