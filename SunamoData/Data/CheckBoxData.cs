namespace SunamoData.Data;

public class CheckBoxData<T>
{
    /// <summary>
    /// Set to IsChecked when TwoWayTable.DataCellWrapper == AddBeforeControl.CheckBox
    /// </summary>
    public bool? tick = false;
    /// <summary>
    /// Na to co se má zobrazit
    /// </summary>
    public T t = default;
}
