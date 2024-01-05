namespace SunamoShared.Helpers.DataTypes;



public class SelectedCastHelper<T> : ISelectedT<T>
{
    private ISelectedT<T> _selected = null;

    public SelectedCastHelper(ISelectedT<T> selected)
    {
        _selected = selected;
    }

    public T SelectedItem => (T)_selected.SelectedItem;
}
