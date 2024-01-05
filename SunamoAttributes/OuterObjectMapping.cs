namespace SunamoAttributes;

public class OuterObjectMapping  //: Dictionary<Type, string>
{
    /// <summary>
    /// DB can't have primary key, it's only indicator that any other element in DB is not the same as primary key.
    /// </summary>
    public PropertyInfo primaryKey = null;
    public List<PropertyInfo> propertyInfos = new List<PropertyInfo>();
}
